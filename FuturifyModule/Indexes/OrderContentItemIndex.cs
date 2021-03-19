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
            context.For<OrderContentItemIndex>().Map(item => new OrderContentItemIndex
            {
                Date = (DateTime?)item.Content.Order.Date.Value
            });
        }
    }
}
