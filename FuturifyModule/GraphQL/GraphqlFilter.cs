using FuturifyModule.Models;
using GraphQL.Types;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.GraphQL.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesSql;
using Task = System.Threading.Tasks.Task;

namespace FuturifyModule.GraphQL
{
    public class AutoroutePartGraphQLFilter : GraphQLFilter<ContentItem>
    {
        public override Task<IQuery<ContentItem>> PreQueryAsync(IQuery<ContentItem> query, ResolveFieldContext context)
        {
            if (!context.HasArgument("productPart"))
            {
                return Task.FromResult(query);
            }

            var part = context.GetArgument<Product>("productPart");

            if (part == null)
            {
                return Task.FromResult(query);
            }

            var productQuery = query.With<ProductIndex>();

            if (part.CategoryId.ContentItemIds.Length != 0)
            {
                return Task.FromResult(productQuery.Where(index => index.CategoryId == part.CategoryId.ContentItemIds[0])..ListAsync().Result);
            }

            return Task.FromResult(query);
        }
    }
}
}
