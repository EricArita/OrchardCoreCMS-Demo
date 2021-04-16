using Microsoft.AspNetCore.Mvc;
using OrchardCore;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Records;
using OrchardCore.ContentTypes.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using YesSql;
using YesSql.Services;
using System.Linq;
using FuturifyModule.Models;
using System;
using System.Diagnostics;
using FuturifyModule.Indexes;
using OrchardCore.ContentManagement.Metadata;
using Microsoft.AspNetCore.Authorization;
using OrchardCore.Roles;
using OrchardCore.Security.Services;
using OrchardCore.Roles.ViewModels;
using OrchardCore.Security;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using OrchardCore.Data.Migration;
using OrchardCore.Security.Permissions;
using System.Security.Claims;
using OrchardCore.ContentFields;

namespace FuturifyModule.Controllers
{
    [Route("api/document")]
    [Authorize(AuthenticationSchemes = "Api"), IgnoreAntiforgeryToken]
    public class DocumentController : Controller
    {
        private readonly IStore _store;
        private readonly ISession _session;
        private readonly IContentManager _contentManager;
        private readonly IOrchardHelper _orchardHelper;
        private readonly IContentDefinitionService _contentDefinitionService;
        private readonly IContentDefinitionManager _contentDefinitionManager;
        private readonly IAuthorizationService _authorizationService;
        private readonly IRoleService _roleService;
        private readonly RoleManager<IRole> _roleManager;
        private readonly IEnumerable<IPermissionProvider> _permissionProviders;


        public DocumentController(IStore store, ISession session, IContentManager contentManager, IOrchardHelper orchardHelper, 
                                  IContentDefinitionService contentDefinitionService,
                                  IContentDefinitionManager contentDefinitionManager,
                                  IRoleService roleService,
                                  RoleManager<IRole> roleManager,
                                  IEnumerable<IPermissionProvider> permissionProviders,
                                  IAuthorizationService authorizationService)
        {
            _store = store;
            _session = session;
            _contentManager = contentManager;
            _orchardHelper = orchardHelper;
            _contentDefinitionService = contentDefinitionService;
            _contentDefinitionManager = contentDefinitionManager;
            _authorizationService = authorizationService;
            _roleService = roleService;
            _roleManager = roleManager;
            _permissionProviders = permissionProviders;
        }

        [HttpGet]
        [Route("list-contentitems/{contentType}")]
        public async Task<IActionResult> Index(string contentType)
        {
            IEnumerable<ContentItem> contentItems = null;

            contentItems = await _session.Query<ContentItem>()
                               .With<ContentItemIndex>().Where(x => x.ContentType == contentType)
                               .ListAsync();
            //return View(contentItems);
            return Ok(contentItems);
        }

        [HttpGet]
        [Route("content-type/all")]
        public async Task<IActionResult> GetAllContentType()
        {
            //var t = _contentDefinitionService.GetParts(true);
            //var d = _contentDefinitionManager.LoadPartDefinitions();

            var contentTypes = _contentDefinitionManager.ListTypeDefinitions().Select(x =>
            {
                var words = x.DisplayName.Split(' ');
                var res = words[0].ToLower();

                for (int i = 1; i < words.Length; i++)
                {
                    res += char.ToUpper(words[i].First()) + words[i].Substring(1);
                }

                return res;
            });

            return Ok(contentTypes);
        }

        [HttpGet]
        [Route("report")]
        public async Task<IActionResult> ReportData()
        {
            var res = new ReportModel();
            var sw = new Stopwatch();


            #region Report product category that has the most products
            //sw.Start();

            //using (var session = _store.CreateSession())
            //{
            //    var productContentItems = await session.Query<ContentItem>()
            //                   .With<ContentItemIndex>().Where(x => x.ContentType == "Product")
            //                   .ListAsync();

            //    var productCategoryIdWithCount = productContentItems.Select(x => x.Content.ContentMenuItemPart.SelectedContentItem.ContentItemIds.ToObject<string[]>()[0])
            //                                            .GroupBy(e => e)
            //                                            .Select(group => new
            //                                            {
            //                                                productCategoryId = (string)group.Key,
            //                                                Count = group.Count()
            //                                            })
            //                                            .OrderByDescending(x => x.Count).FirstOrDefault();

            //    res.ProductCategoryHasTheMostProducts = new ProductCategoryHasTheMostProducts
            //    {
            //        ProductCategoryName = (await _orchardHelper.GetContentItemByIdAsync(productCategoryIdWithCount.productCategoryId)).DisplayText,
            //        Amount = productCategoryIdWithCount.Count,
            //    };
            //}

            //sw.Stop();
            //res.ProductCategoryHasTheMostProducts.ElapseTime = sw.Elapsed.TotalMilliseconds;
            #endregion

            #region Report the best selling product of last month
            sw.Start();

            var firstDayOfCurrentMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            var firstDayOfLastMonth = firstDayOfCurrentMonth.AddMonths(-1);

            var ordersInLastMonth = _session.Query<ContentItem, ContentItemIndex>(x => x.ContentType == "Order")
                                                  .With<OrderContentItemIndex>(x => x.Date >= firstDayOfLastMonth && x.Date < firstDayOfCurrentMonth)
                                                  .ListAsync()
                                                  .Result
                                                  .Select(x => x.ContentItemId);
                                                  
            var orderDetailInLastMonth = await _session
                                                 .Query<ContentItem, ContentItemIndex>(x => x.ContentType == "OrderDetail")
                                                 .With<OrderDetailContentItemIndex>(x => x.OrderContentItemId.IsIn(ordersInLastMonth))
                                                 .ListAsync();

            var bestSellingProductItem = orderDetailInLastMonth
                                            .GroupBy(x => x.As<OrderDetailPart>().ProductContentField.ContentItemIds[0])
                                            .Select(group => new
                                            {
                                                ProductContentItemId = (string)group.Key,
                                                ListOrderDetailContentItem = group.AsEnumerable()
                                            })
                                            .OrderByDescending(x => x.ListOrderDetailContentItem.Sum(y => y.As<OrderDetailPart>().QuantityContentField.Value))
                                            .FirstOrDefault();

            res.TheBestSellingOfLastMonth = new TheBestSellingProductOfLastMonth
            {
                ProductName = (await _orchardHelper.GetContentItemByIdAsync(bestSellingProductItem.ProductContentItemId)).DisplayText,
                Amount = bestSellingProductItem.ListOrderDetailContentItem.Sum(x => x.As<OrderDetailPart>().QuantityContentField.Value),
            };
            sw.Stop();
            res.TheBestSellingOfLastMonth.ElapseTime = sw.Elapsed.TotalMilliseconds;
            #endregion

            //return View(res);
            return Ok(res);
        }

        [HttpGet]
        [Route("roles/all")]
        public async Task<IActionResult> Index()
        {
            var roles = await _roleService.GetRolesAsync();
            var res = roles.Select(BuildRoleEntry).ToList();

            return Ok(res);
        }


        [HttpPost]
        [Route("role/create-new-role")]
        //[IgnoreAntiforgeryToken]
        public async  Task<IActionResult> CreateNewRole([FromBody] CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.RoleName = model.RoleName.Trim();

                if (model.RoleName.Contains('/'))
                {
                    return BadRequest("Invalid role name");
                }

                if (await _roleManager.FindByNameAsync(_roleManager.NormalizeKey(model.RoleName)) != null)
                {
                    return BadRequest("The role is already used.");
                }
            }

            if (ModelState.IsValid)
            {
                var role = new Role { RoleName = model.RoleName, RoleDescription = model.RoleDescription };
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return Ok();
                }

                return BadRequest(result.Errors.Select(e => e.Description));
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("role/get-permissions/{roleName}")]
        public async Task<IActionResult> GetPermissionsOfRole(string roleName)
        {
            if (!await _authorizationService.AuthorizeAsync(User, Permissions.ManageRoles))
            {
                return Forbid();
            }

            //var roleName = User.FindFirst(ClaimTypes.Role).Value;
            var role = (Role)await _roleManager.FindByNameAsync(_roleManager.NormalizeKey(roleName));

            if (role == null)
            {
                return NotFound();
            }

            var installedPermissions = await GetInstalledPermissionsAsync();
            var allPermissions = installedPermissions.SelectMany(x => x.Value);

            var model = new EditRoleViewModel
            {
                Role = role,
                Name = role.RoleName,
                RoleDescription = role.RoleDescription,
                EffectivePermissions = await GetEffectivePermissions(role, allPermissions),
                RoleCategoryPermissions = installedPermissions
            };

            return Ok(model);
        }

        [HttpPost]
        [Route("role/update")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> SaveEditRolePermissions([FromBody] UpdateRoleViewModel viewModel)
        {
            if (!await _authorizationService.AuthorizeAsync(User, Permissions.ManageRoles))
            {
                return Forbid();
            }

            var role = (Role)await _roleManager.FindByNameAsync(_roleManager.NormalizeKey(viewModel.RoleName));

            if (role == null)
            {
                return NotFound();
            }

            role.RoleDescription = viewModel.RoleDescription;

            var rolePermissions = new List<RoleClaim>();

            //Current, permissions of role are updated from a UI, maybe we can setup it inside code instead of using UI
            foreach (string permissionName in viewModel.SelectedPermissions)
            {
                rolePermissions.Add(new RoleClaim { ClaimType = Permission.ClaimType, ClaimValue = permissionName });
            }

            role.RoleClaims.RemoveAll(c => c.ClaimType == Permission.ClaimType);
            role.RoleClaims.AddRange(rolePermissions);

            await _roleManager.UpdateAsync(role);

            return Ok("Save permissions of role successfully");
        }

        private async Task<IDictionary<string, IEnumerable<Permission>>> GetInstalledPermissionsAsync()
        {
            var installedPermissions = new Dictionary<string, IEnumerable<Permission>>();
            foreach (var permissionProvider in _permissionProviders)
            {
                //var feature = _typeFeatureProvider.GetFeatureForDependency(permissionProvider.GetType());
                //var featureName = feature.Id;

                var permissions = await permissionProvider.GetPermissionsAsync();

                foreach (var permission in permissions)
                {
                    var category = String.IsNullOrWhiteSpace(permission.Category) ? "No name" : permission.Category;

                    if (installedPermissions.ContainsKey(category))
                    {
                        installedPermissions[category] = installedPermissions[category].Concat(new[] { permission });
                    }
                    else
                    {
                        installedPermissions.Add(category, new[] { permission });
                    }
                }
            }

            return installedPermissions;
        }

        private async Task<IEnumerable<string>> GetEffectivePermissions(Role role, IEnumerable<Permission> allPermissions)
        {
            var fakeUser = new ClaimsPrincipal(
              new ClaimsIdentity(new[] { new Claim(ClaimTypes.Role, role.RoleName) },
              role.RoleName != "Anonymous" ? "FakeAuthenticationType" : null)
          );
            var result = new List<string>();

            foreach (var permission in allPermissions)
            {
                if (await _authorizationService.AuthorizeAsync(fakeUser, permission))
                {
                    result.Add(permission.Name);
                }
            }

            return result;
        }

        private RoleEntry BuildRoleEntry(IRole role)
        {
            return new RoleEntry
            {
                Name = role.RoleName,
                Description = role.RoleDescription,
                Selected = false
            };
        }
    }
}
