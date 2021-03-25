using Microsoft.AspNetCore.Mvc;
using OrchardCore;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Records;
using System.Collections.Generic;
using System.Threading.Tasks;
using YesSql;
using YesSql.Services;
using System.Linq;
using FuturifyModule.Models;
using System;
using System.Diagnostics;
using FuturifyModule.Indexes;

namespace FuturifyModule.Controllers
{
    [Produces("application/json")]
    [Route("api/document")]
    public class DocumentController : Controller
    {
        private readonly IStore _store;
        private readonly ISession _session;
        private readonly IContentManager _contentManager;
        private readonly IOrchardHelper _orchardHelper;

        public DocumentController(IStore store, ISession session, IContentManager contentManager, IOrchardHelper orchardHelper)
        {
            _store = store;
            _session = session;
            _contentManager = contentManager;
            _orchardHelper = orchardHelper;
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
    }
}
