using System;
using System.Collections.Generic;
using System.Text;

namespace FuturifyModule.Models
{
    public class ReportModel
    {
        public ProductCategoryHasTheMostProducts ProductCategoryHasTheMostProducts { get; set; }
        public TheBestSellingProductOfLastMonth TheBestSellingOfLastMonth { get; set; }
    }

    public class ProductCategoryHasTheMostProducts : ExecutionTime
    {
        public string ProductCategoryName { get; set; }
        public int Amount { get; set; }
    }

    public class TheBestSellingProductOfLastMonth : ExecutionTime
    {
        public string ProductName { get; set; }
        public double Amount { get; set; }
    }

    public class ExecutionTime
    {
        public double ElapseTime { get; set; }
    }
}
