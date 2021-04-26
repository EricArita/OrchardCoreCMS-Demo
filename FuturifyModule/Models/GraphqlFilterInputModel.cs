using OrchardCore.ContentManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuturifyModule.Models
{
    public class CategoryFilterModel : ContentPart
    { 
        public string Name { get; set; }
        public string CategoryId { get; set; }
    }
}
