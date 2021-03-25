using OrchardCore.ContentManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuturifyModule.Models
{
    public class OrderDetailPart : ContentPart
    {
        public ProductContentField ProductContentField { get; set; }
        public OrderContentField OrderContentField { get; set; }

        public QuantityContentField QuantityContentField { get; set; }
    }

    public class ProductContentField
    {
        public string[] ContentItemIds { get; set; }
    }

    public class OrderContentField
    {
        public string[] ContentItemIds { get; set; }
    }

    public class QuantityContentField
    {
        public double Value { get; set; }
    }
}
