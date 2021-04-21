﻿using FuturifyModule.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuturifyModule.GraphQL
{
    public class ProductInputObjectType : InputObjectGraphType<Product>
    {
        public ProductInputObjectType()
        {
            Name = "ProductPartInput";

            Field(x => x.CategoryId.ContentItemIds, type: typeof(ListGraphType<StringGraphType>), nullable: false).Description("the categoryId of the content item to filter");
        }
    }
}
