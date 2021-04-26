using FuturifyModule.Models;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OrchardCore.Apis.GraphQL;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.GraphQL.Options;
using OrchardCore.ContentManagement.GraphQL.Queries;
using OrchardCore.ContentManagement.GraphQL.Queries.Types;
using OrchardCore.ContentManagement.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YesSql;
using YesSql.Services;

namespace FuturifyModule.GraphQL
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType(IServiceProvider services)
        {
            Field<ListGraphType<CustomContentItemType>>(
                 "productsByCategoryName",
                 arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "categoryName" }),
                 resolve: context =>
                 {
                     var graphContext = (GraphQLContext)context.UserContext;
                     var contentManager = graphContext.ServiceProvider.GetRequiredService<IContentManager>();
                     var session = graphContext.ServiceProvider.GetService<ISession>();

                     var categoryName = context.GetArgument<string>("categoryName");
                     if (String.IsNullOrEmpty(categoryName)) return null;

                     var categories = session.Query<ContentItem, ContentItemIndex>(x => x.ContentType == "Category")
                                             .With<CategoryIndex>(x => x.Name.Contains(categoryName))
                                             .ListAsync().Result;

                     var recruiments = session.Query<ContentItem, ContentItemIndex>(x => x.ContentType == "Product")
                                              .With<ProductIndex>(x => x.CategoryId.IsIn(categories))
                                              .ListAsync().Result;                                            
                     return null;
                 }
             );
        }
    }

    public class CategoryType : ObjectGraphType<Category>
    {
        public CategoryType()
        {
            Field(x => x.Name.Text);
            Field<CustomContentItemType>("ContentItemCommonField");
        }
    }

    public class CustomContentItemType : ObjectGraphType<ContentItem>
    {
        public CustomContentItemType(IOptions<GraphQLContentOptions> optionsAccessor)
        {
            Name = "CustomContentItemType";

            Field(ci => ci.ContentItemId).Description("Content item id");
            Field(ci => ci.ContentItemVersionId).Description("The content item version id");
            Field(ci => ci.ContentType).Description("Type of content");
            Field(ci => ci.DisplayText, nullable: true).Description("The display text of the content item");
            Field(ci => ci.Published).Description("Is the published version");
            Field(ci => ci.Latest).Description("Is the latest version");
            Field<DateTimeGraphType>("modifiedUtc", resolve: ci => ci.Source.ModifiedUtc, description: "The date and time of modification");
            Field<DateTimeGraphType>("publishedUtc", resolve: ci => ci.Source.PublishedUtc, description: "The date and time of publication");
            Field<DateTimeGraphType>("createdUtc", resolve: ci => ci.Source.CreatedUtc, description: "The date and time of creation");
            Field(ci => ci.Owner).Description("The owner of the content item");
            Field(ci => ci.Author).Description("The author of the content item");

            //Interface<ContentItemInterface>();
            //IsTypeOf = IsContentType;
        }

        //private bool IsContentType(object obj)
        //{
        //    return obj is ContentItem && ((ContentItem)obj).ContentType == Name;
        //}
    }
}
