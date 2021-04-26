using FuturifyModule.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuturifyModule.GraphQL
{
    public class CategoryInputObjectGraphType : InputObjectGraphType<CategoryFilterModel>
    {
        public CategoryInputObjectGraphType()
        {
            Name = "ProductInput";

            Field(x => x.Name, type: typeof(StringGraphType), nullable: true).Description("the name of category to filter");
            Field(x => x.CategoryId, type: typeof(StringGraphType), nullable: true).Description("the categoryId to filter");
        }
    }
}
