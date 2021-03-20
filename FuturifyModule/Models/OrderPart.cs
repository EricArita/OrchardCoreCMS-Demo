using OrchardCore.ContentManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuturifyModule.Models
{
    public class OrderPart : ContentPart
    {
        public OrderDateContentField OrderDateContentField { get; set; }
    }

    public class OrderDateContentField
    {
       public DateTime? Value { get; set; }
    }
}
