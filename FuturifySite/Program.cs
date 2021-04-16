using System;
using System.IO;
using System.Threading.Tasks;
using AAVModule.Constants;
using AAVModule.Migrations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using YesSql;
using YesSql.Provider.MySql;
using YesSql.Sql;
using OrchardCore.ContentFields.Fields;

namespace FuturifySite
{
    public class Program
    {
        public static Task Main(string[] args)
        {
            //AutoGenerateIndexModelCode();
            //AutoGeneratePartModelCode();
            //AutoGenerateRegisterCode();
            //AutoGenerateIndexProviderCode();

            return BuildHost(args).RunAsync();
        }

        public static IHost BuildHost(string[] args)
            => Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                    webBuilder.UseStartup<Startup>())
                .Build();

        private static void AutoGenerateIndexModelCode()
        {
            foreach (var contentType in ContentConfig.ContentTypes)
            {
                string fieldsTemplate = @$"
                    public string ContentItemId {{ get; set; }}";

                foreach (var contentPart in contentType.ContentParts)
                {
                    foreach (var contentField in contentPart.ContentFields)
                    {
                        string type = "string";
                        if (contentField.Type == ContentFieldTypes.TextField) type = "string";
                        else if (contentField.Type == ContentFieldTypes.DateField || contentField.Type == ContentFieldTypes.DateTimeField) type = "DateTime";
                        else if (contentField.Type == ContentFieldTypes.BooleanField) type = "bool";
                        else if (contentField.Type == ContentFieldTypes.NumericField) type = "int";
                        else if (contentField.Type == ContentFieldTypes.ContentPickerField) type = "string";

                        fieldsTemplate += @$"
                    public {type} {contentField.Name} {{ get; set; }}";
                    }
                }

                var template = @$"
                public class {contentType.Name}Index : MapIndex {{" + fieldsTemplate + @"
                }" + Environment.NewLine;

                File.AppendAllText(@"D:\ThoBui\auto_generated_code.txt", template);
            }
        }

        private static void AutoGeneratePartModelCode()
        {
            foreach (var contentType in ContentConfig.ContentTypes)
            {
                string fieldsTemplate = "";

                foreach (var contentPart in contentType.ContentParts)
                {
                    fieldsTemplate = "";

                    foreach (var contentField in contentPart.ContentFields)
                    {
                        string type = "TextField";
                        if (contentField.Type == ContentFieldTypes.TextField) type = "TextField";
                        else if (contentField.Type == ContentFieldTypes.DateField || contentField.Type == ContentFieldTypes.DateTimeField) type = "DateField";
                        else if (contentField.Type == ContentFieldTypes.DateTimeField) type = "DateTimeField";
                        else if (contentField.Type == ContentFieldTypes.BooleanField) type = "BooleanField";
                        else if (contentField.Type == ContentFieldTypes.NumericField) type = "NumericField";
                        else if (contentField.Type == ContentFieldTypes.ContentPickerField) type = "ContentPickerField";

                        fieldsTemplate += @$"
                        public {type} {contentField.Name} {{ get; set; }}";
                    }

                    var template = @$"
                    public class {contentPart.Name}Part : ContentPart {{" + fieldsTemplate + @"
                    }" + Environment.NewLine;

                    File.AppendAllText(@"D:\ThoBui\auto_generated_code.txt", template);
                }
            }
        }

        private static void AutoGenerateRegisterCode()
        {
            foreach (var contentType in ContentConfig.ContentTypes)
            {
                //services.AddContentPart<OrdersPart>();

                foreach (var contentPart in contentType.ContentParts)
                {
                    var template = $"services.AddContentPart<{contentPart.Name}Part>();" + Environment.NewLine;

                    File.AppendAllText(@"D:\ThoBui\auto_generated_code.txt", template);
                }
            }

            File.AppendAllText(@"D:\ThoBui\auto_generated_code.txt", "---------------------------------------------------------" + Environment.NewLine);

            foreach (var contentType in ContentConfig.ContentTypes)
            {
                //services.AddSingleton<IIndexProvider, OrderContentItemIndexProvider>();
                var template = $"services.AddSingleton<IIndexProvider, {contentType.Name}IndexProvider>();" + Environment.NewLine;

                File.AppendAllText(@"D:\ThoBui\auto_generated_code.txt", template);
            }
        }

        private static void AutoGenerateIndexProviderCode()
        {
            foreach (var contentType in ContentConfig.ContentTypes)
            {
                var fieldsTemplate = "";
                var contentPart = contentType.ContentParts.Find(x => x.Name == contentType.Name);

                foreach (var contentField in contentPart.ContentFields)
                {
                    string type = "Text";
                    if (contentField.Type == ContentFieldTypes.TextField) type = "Text";
                    else if (contentField.Type == ContentFieldTypes.DateField || contentField.Type == ContentFieldTypes.DateTimeField) type = "Value.Value";
                    else if (contentField.Type == ContentFieldTypes.BooleanField) type = "Value";
                    else if (contentField.Type == ContentFieldTypes.NumericField) type = "Value.Value";
                    else if (contentField.Type == ContentFieldTypes.ContentPickerField) type = "ContentItemIds";

                    fieldsTemplate += @$"
                                    {contentField.Name} = " + (contentField.Type == ContentFieldTypes.NumericField ? "(int)" : "") 
                                      + $"content.{contentField.Name}.{type}" + (contentField.Type == ContentFieldTypes.ContentPickerField ? "[0]," : ",") + Environment.NewLine;
                }

                var template = @$"
                    public class {contentType.Name}IndexProvider : IndexProvider<ContentItem> {{
                        public override void Describe(DescribeContext<ContentItem> context)
                        {{
                           context.For<{contentType.Name}Index>().Map(contentItem =>
                           {{
                               var content = contentItem.As<{contentType.Name}Part>();

                               return content == null ? null : new {contentType.Name}Index
                               {{
                                    ContentItemId = contentItem.ContentItemId,
                                   {fieldsTemplate}
                               }};
                           }});
                        }}
                    }}" + Environment.NewLine;


                File.AppendAllText(@"D:\ThoBui\auto_generated_code.txt", template);
            }
        }
    }
}
