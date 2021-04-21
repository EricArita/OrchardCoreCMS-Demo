using FuturifyModule.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuturifyModule.GraphQL
{
    public class ProductQueryObjectType : ObjectGraphType<Product>
    {
        public ProductQueryObjectType()
        {
            Name = "ProductPart";

            // Map the fields you want to expose
            Field(x => x.CategoryId.ContentItemIds, type: typeof(ListGraphType<StringGraphType>));
        }
    }
}
