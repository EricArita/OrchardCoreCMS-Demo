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
using System.Collections.Generic;
using AAVModule.Models;
using System.Linq;

namespace FuturifySite
{
    public class Program
    {
        public static Task Main(string[] args)
        {
            //Console.WriteLine(outputFile);
            //AutoGenerateIndexModelCode();
            //AutoGeneratePartModelCode();
            //AutoGenerateRegisterCode();
            //();

            return BuildHost(args).RunAsync();
        }

        public static IHost BuildHost(string[] args)
            => Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                    webBuilder.UseStartup<Startup>())
                .Build();

        private static string outputFile = @$"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\auto_generated_code.txt";

        private static void AutoGenerateIndexModelCode()
        {
            foreach (var contentType in ContentConfig.ContentTypes)
            {
                string fieldsTemplate = @$"
                            public string ContentItemId {{ get; set; }}";

                foreach (var contentField in contentType.DefaultContentPart.ContentFields)
                {
                    if (contentField.Name == "Description") continue;

                    string type = "string";
                    if (contentField.Type == ContentFieldTypes.TextField) type = "string";
                    else if (contentField.Type == ContentFieldTypes.DateField || contentField.Type == ContentFieldTypes.DateTimeField) type = "DateTime";
                    else if (contentField.Type == ContentFieldTypes.BooleanField) type = "bool";
                    else if (contentField.Type == ContentFieldTypes.NumericField) type = "int";
                    else if (contentField.Type == ContentFieldTypes.ContentPickerField) type = "string";

                    fieldsTemplate += @$"
                            public {type} {contentField.Name} {{ get; set; }}";
                }

                foreach(var reg in ContentConfig.ContentPartRegisters)
                {
                    if (reg.ContentType == contentType.Name) {
                        var contentPart = ContentConfig.ContentParts.FirstOrDefault(x => x.Name == reg.ContentPart);

                        foreach (var contentField in contentPart.ContentFields)
                        {
                            if (contentField.Name == "Description") continue;

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
                }
              
                var template = @$"
                        public class {contentType.Name}Index : MapIndex {{" + fieldsTemplate + @"
                        }" + Environment.NewLine;

                File.AppendAllText(outputFile, template);
            }

            File.AppendAllText(outputFile, "---------------------------------------------------------" + Environment.NewLine);
        }

        private static void AutoGeneratePartModelCode()
        {
            //Collection of Content Part, bool value indicates that a content part is a default one of a content type or not
            var configs = new Dictionary<ContentPartDefinition, bool>();

            foreach (var contentType in ContentConfig.ContentTypes)
            {
                configs.Add(contentType.DefaultContentPart, true);
            }

            foreach (var contentPart in ContentConfig.ContentParts)
            {
                configs.Add(contentPart, false);
            }

            foreach (var config in configs)
            {
                string fieldsTemplate = "";
                var contentPart = config.Key;
                var isDefaultContentPart = config.Value;

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
                    public class {contentPart.Name}{(isDefaultContentPart ? "" : "Part")} : ContentPart {{" + fieldsTemplate + @"
                    }" + Environment.NewLine;

                File.AppendAllText(outputFile, template);
            }

            File.AppendAllText(outputFile, "---------------------------------------------------------" + Environment.NewLine);
        }

        private static void AutoGenerateRegisterCode()
        {
            var configs = new Dictionary<ContentPartDefinition, bool>();

            foreach (var contentType in ContentConfig.ContentTypes)
            {
                configs.Add(contentType.DefaultContentPart, true);
            }

            foreach (var contentPart in ContentConfig.ContentParts)
            {
                configs.Add(contentPart, false);
            }

            foreach (var config in configs)
            {
                var contentPart = config.Key;
                var isDefaultContentPart = config.Value;

                var template = $"services.AddContentPart<{contentPart.Name}{(isDefaultContentPart ? "" : "Part")}>();" + Environment.NewLine;

                File.AppendAllText(outputFile, template);
            }

            File.AppendAllText(outputFile, "---------------------------------------------------------" + Environment.NewLine);

            foreach (var contentType in ContentConfig.ContentTypes)
            {
                var template = $"services.AddSingleton<IIndexProvider, {contentType.Name}IndexProvider>();" + Environment.NewLine;

                File.AppendAllText(outputFile, template);
            }

            File.AppendAllText(outputFile, "---------------------------------------------------------" + Environment.NewLine);
        }

        private static void AutoGenerateIndexProviderCode()
        {
            foreach (var contentType in ContentConfig.ContentTypes)
            {
                var fieldsTemplate = "";
                var asPartContent = @$"
                               var {contentType.DefaultContentPart.Name.ToLower()}PartContent = contentItem.As<{contentType.DefaultContentPart.Name}>();" + Environment.NewLine;
                var nullContentCondition = $@"{contentType.DefaultContentPart.Name.ToLower()}PartContent == null";

                foreach (var contentField in contentType.DefaultContentPart.ContentFields)
                {
                    if (contentField.Name == "Description") continue;
                   
                    string type = "Text";
                    if (contentField.Type == ContentFieldTypes.TextField) type = "Text";
                    else if (contentField.Type == ContentFieldTypes.DateField || contentField.Type == ContentFieldTypes.DateTimeField) type = "Value.Value";
                    else if (contentField.Type == ContentFieldTypes.BooleanField) type = "Value";
                    else if (contentField.Type == ContentFieldTypes.NumericField) type = "Value.Value";
                    else if (contentField.Type == ContentFieldTypes.ContentPickerField) type = "ContentItemIds";

                    fieldsTemplate += @$"
                                    {contentField.Name} = " + (contentField.Type == ContentFieldTypes.NumericField ? "(int)" : "") 
                                      + $"{contentType.DefaultContentPart.Name.ToLower()}PartContent.{contentField.Name}.{type}" + (contentField.Type == ContentFieldTypes.ContentPickerField ? "[0]," : ",") + Environment.NewLine;
                }

                foreach (var reg in ContentConfig.ContentPartRegisters)
                {
                    if (reg.ContentType == contentType.Name)
                    {
                        var contentPart = ContentConfig.ContentParts.FirstOrDefault(x => x.Name == reg.ContentPart);
                        asPartContent += @$"
                               var {contentPart.Name.ToLower()}PartContent = contentItem.As<{contentPart.Name}Part>();" + Environment.NewLine;
                        nullContentCondition += $" || {contentPart.Name.ToLower()}PartContent == null";

                        foreach (var contentField in contentPart.ContentFields)
                        {
                            if (contentField.Name == "Description") continue;

                            string type = "Text";
                            if (contentField.Type == ContentFieldTypes.TextField) type = "Text";
                            else if (contentField.Type == ContentFieldTypes.DateField || contentField.Type == ContentFieldTypes.DateTimeField) type = "Value.Value";
                            else if (contentField.Type == ContentFieldTypes.BooleanField) type = "Value";
                            else if (contentField.Type == ContentFieldTypes.NumericField) type = "Value.Value";
                            else if (contentField.Type == ContentFieldTypes.ContentPickerField) type = "ContentItemIds";

                            fieldsTemplate += @$"
                                    {contentField.Name} = " + (contentField.Type == ContentFieldTypes.NumericField ? "(int)" : "")
                                     + $"{contentPart.Name.ToLower()}PartContent.{contentField.Name}.{type}" + (contentField.Type == ContentFieldTypes.ContentPickerField ? "[0]," : ",") + Environment.NewLine;
                        }
                    }
                }

                var template = @$"
                    public class {contentType.Name}IndexProvider : IndexProvider<ContentItem> {{
                        public override void Describe(DescribeContext<ContentItem> context)
                        {{
                           context.For<{contentType.Name}Index>().Map(contentItem =>
                           {{
                               {asPartContent}
                               return {nullContentCondition} ? null : new {contentType.Name}Index
                               {{
                                    ContentItemId = contentItem.ContentItemId,
                                   {fieldsTemplate}
                               }};
                           }});
                        }}
                    }}" + Environment.NewLine;


                File.AppendAllText(outputFile, template);
            }

            File.AppendAllText(outputFile, "---------------------------------------------------------" + Environment.NewLine);
        }
    }
}
