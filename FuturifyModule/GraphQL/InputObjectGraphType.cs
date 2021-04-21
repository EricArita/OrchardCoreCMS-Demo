using FuturifyModule.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuturifyModule.GraphQL
{
    public class ProductInputObjectType : InputObjectGraphType<ProductPart>
    {
        public ProductInputObjectType()
        {
            Name = "ProductPartInput";

            Field(x => x.CategoryId, nullable: true).Description("the categoryId of the content item to filter");
        }
    }
}
