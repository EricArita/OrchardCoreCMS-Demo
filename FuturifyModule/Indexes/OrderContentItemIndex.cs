using FuturifyModule.Models;
using OrchardCore.ContentManagement;
using System;
using YesSql.Indexes;

namespace FuturifyModule.Indexes
{
    public class OrderContentItemIndex : MapIndex
    {
        public DateTime? Date { get; set; }
    }

    public class OrderContentItemIndexProvider : IndexProvider<ContentItem>
    {
        public override void Describe(DescribeContext<ContentItem> context)
        {
            context.For<OrderContentItemIndex>().Map(contentItem =>
            {
                var orderContent = contentItem.As<OrderPart>();

                return orderContent == null ? null : new OrderContentItemIndex
                {
                    Date = orderContent.OrderDateContentField.Value
                };
            });
        }
    }
}
