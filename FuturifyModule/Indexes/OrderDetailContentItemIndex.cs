using FuturifyModule.Models;
using OrchardCore.ContentManagement;
using System;
using YesSql.Indexes;

namespace FuturifyModule.Indexes
{
    public class OrderDetailContentItemIndex : MapIndex
    {
        public string OrderContentItemId { get; set; }
        public string ProductContentItemId { get; set; }
    }

    public class OrderDetailContentItemIndexProvider : IndexProvider<ContentItem>
    {
        public override void Describe(DescribeContext<ContentItem> context)
        {
            context.For<OrderDetailContentItemIndex>().Map(contentItem => {
                var orderDetaiContent = contentItem.As<AnotherOrderDetailPart>();

                return orderDetaiContent == null ? null : new OrderDetailContentItemIndex
                {
                    OrderContentItemId = orderDetaiContent.OrderContentField.ContentItemIds[0],
                    ProductContentItemId = orderDetaiContent.ProductContentField.ContentItemIds[0]
                };
            });
        }
    }
}
