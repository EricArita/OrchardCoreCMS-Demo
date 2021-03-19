using Microsoft.AspNetCore.Mvc;
using OrchardCore;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Records;
using System.Collections.Generic;
using System.Threading.Tasks;
using YesSql;
using System.Linq;
using OrchardCore.Content;
using FuturifyModule.Models;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using FuturifyModule.Indexes;

namespace FuturifyModule.Controllers
{

    public class DocumentController : Controller
    {
        private readonly IStore _store;
        private readonly IContentManager _contentManager;
        private readonly IOrchardHelper _orchardHelper;

        public DocumentController(IStore store, IContentManager contentManager, IOrchardHelper orchardHelper)
        {
            _store = store;
            _contentManager = contentManager;
            _orchardHelper = orchardHelper;
        }

        public async Task<IActionResult> Index(string contentType)
        {
            IEnumerable<ContentItem> contentItems = null;

            using (var session = _store.CreateSession())
            {
                contentItems = await session.Query<ContentItem>()
                               .With<ContentItemIndex>().Where(x => x.ContentType == contentType)
                               .ListAsync();
            }
            return View(contentItems);
        }

        public async Task<IActionResult> ReportData()
        {
            var res = new ReportModel();
            var sw = new Stopwatch();

            #region Report product category that has the most products
            sw.Start();

            using (var session = _store.CreateSession())
            {
                var productContentItems = await session.Query<ContentItem>()
                               .With<ContentItemIndex>().Where(x => x.ContentType == "Product")
                               .ListAsync();

                var productCategoryIdWithCount = productContentItems.Select(x => x.Content.ContentMenuItemPart.SelectedContentItem.ContentItemIds.ToObject<string[]>()[0])
                                                        .GroupBy(e => e)
                                                        .Select(group => new
                                                        {
                                                            productCategoryId = (string)group.Key,
                                                            Count = group.Count()
                                                        })
                                                        .OrderByDescending(x => x.Count).FirstOrDefault();

                res.ProductCategoryHasTheMostProducts = new ProductCategoryHasTheMostProducts
                {
                    ProductCategoryName = (await _orchardHelper.GetContentItemByIdAsync(productCategoryIdWithCount.productCategoryId)).DisplayText,
                    Amount = productCategoryIdWithCount.Count,
                };
            }

            sw.Stop();
            res.ProductCategoryHasTheMostProducts.ElapseTime = sw.Elapsed.TotalMilliseconds;
            #endregion

            #region Report the best selling product of last month
            sw.Start();
            _store.RegisterIndexes<OrderContentItemIndexProvider>();

            using (var session = _store.CreateSession())
            {
                var ordersInLastMonth = await session.Query<ContentItem>()
                                                     .With<ContentItemIndex>()
                                                     .Where(x => x.ContentType == "Order")
                                                     .With<OrderContentItemIndex>()
                                                     .Where(x => x.Date.HasValue && x.Date.Value.Month == DateTime.Now.Month - 1)
                                                     .ListAsync();

                var orderDetailInLastMonth = await session.Query<ContentItem>()
                                                       .With<ContentItemIndex>()
                                                       .Where(x => x.ContentType == "OrderDetail")
                                                       .With<OrderDetailContentItemIndex>()
                                                       .Where(x => ordersInLastMonth.Any(y => y.ContentItemId == x.OrderContentItemId))
                                                       .ListAsync();

                var bestSellingProductItem = orderDetailInLastMonth.GroupBy(x => x.Content.ProductList.ProductContentItems.ContentItemIds.ToObject<string[]>()[0])
                                                .Select(group => new
                                                {
                                                    ProductContentItemId = (string)group.Key,
                                                    ListOrderDetailContentItem = group.AsEnumerable()
                                                })
                                                .OrderByDescending(x => x.ListOrderDetailContentItem.Sum(y => y.Content.OrderDetail.Quantity.Value))
                                                .FirstOrDefault();
            }

            sw.Stop();
            #endregion


            return View(res);
        }
    }
}
