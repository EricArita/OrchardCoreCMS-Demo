using OrchardCore.ContentManagement;
using System;
using YesSql.Indexes;

namespace FuturifyModule.Indexes
{
    public class OrderDetailContentItemIndex : MapIndex
    {
        public string OrderContentItemId { get; set; }
    }

    public class OrderDetailContentItemIndexProvider : IndexProvider<ContentItem>
    {
        public override void Describe(DescribeContext<ContentItem> context)
        {
            context.For<OrderDetailContentItemIndex>().Map(item => new OrderDetailContentItemIndex
            {
                OrderContentItemId = (string)item.Content.OrderList.Orders.ContentItemIds[0]
            });
        }
    }
}
