//using FuturifyModule.Models;
//using GraphQL.Types;
//using OrchardCore.ContentManagement;
//using OrchardCore.ContentManagement.GraphQL.Queries;
//using OrchardCore.ContentManagement.Records;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using YesSql;
//using Task = System.Threading.Tasks.Task;

//namespace FuturifyModule.GraphQL
//{
//    public class CategoryGraphQLFilter : GraphQLFilter<ContentItem>
//    {
//        public override Task<IQuery<ContentItem>> PreQueryAsync(IQuery<ContentItem> query, ResolveFieldContext context)
//        {
//            if (!context.HasArgument("category"))
//            {
//                return Task.FromResult(query);
//            }

//            var filterInput = context.GetArgument<CategoryFilterModel>("category");

//            if (filterInput == null)
//            {
//                return Task.FromResult(query);
//            }

//            var productQuery = query.With<ProductIndex>();

//            if (!String.IsNullOrEmpty(filterInput.CategoryId))
//            {
//                return Task.FromResult((IQuery<ContentItem>)productQuery.Where(index => index.CategoryId == filterInput.CategoryId));
//            }

//            return Task.FromResult(query);
//        }
//    }
//}
