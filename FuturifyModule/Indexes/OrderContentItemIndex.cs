using FuturifyModule.Models;
using OrchardCore.ContentManagement;
using System;
using YesSql.Indexes;

namespace FuturifyModule.Indexes
{
    public class OrderContentItemIndex : MapIndex
    {
        public string OrderContentItemId { get; set; }
        public DateTime? Date { get; set; }
    }

    public class OrderContentItemIndexProvider : IndexProvider<ContentItem>
    {
        public override void Describe(DescribeContext<ContentItem> context)
        {
            context.For<OrderContentItemIndex>().Map(contentItem =>
            {
                var orderContent = contentItem.As<OrdersPart>();

                return orderContent == null ? null : new OrderContentItemIndex
                {
                    OrderContentItemId = contentItem.ContentItemId,
                    Date = orderContent.OrderDateContentField.Value
                };
            });
        }
    }
}
