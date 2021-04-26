using AAVModule.Constants;
using AAVModule.Migrations;
using AAVModule.Models;
using FuturifyModule.Models;
using OrchardCore.ContentFields.Settings;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using System;
using System.Collections.Generic;
using YesSql;

public class Migrations : DataMigration
{
    IContentDefinitionManager _contentDefinitionManager;
    IStore _store;

    public Migrations(IContentDefinitionManager contentDefinitionManager, IStore store)
    {
        _contentDefinitionManager = contentDefinitionManager;
        _store = store;
    }

    public int Create()
    {
        //This code will be run when the feature is enabled
        DefineContents(ContentConfig.ContentTypes, ContentConfig.ContentParts, ContentConfig.ContentPartRegisters);
        Console.WriteLine("Migration run successfully !!!");

        return 1;
    }

    public int UpdateFrom1()
    {
        SchemaBuilder.CreateMapIndexTable("ProductIndex", table => table
                            .Column<string>("Name")
                            .Column<string>("CategoryId")
                      );

        return 2;
    }

    public int UpdateFrom2()
    {
        SchemaBuilder.AlterTable("ProductIndex", table => table
                            .AddColumn<string>("ContentItemId")
                      );

        return 3;
    }

    public int UpdateFrom3()
    {
        SchemaBuilder.CreateMapIndexTable("CategoryIndex", table => table
                           .Column<string>("Name")
                     );

        return 4;
    }

    public int UpdateFrom4()
    {
        SchemaBuilder.AlterTable("CategoryIndex", table => table
                            .AddColumn<string>("ContentItemId")
                      );

        return 5;
    }

    private void DefineContents(IEnumerable<ContentTypeDefinition> typeDefinitions,
                                IEnumerable<ContentPartDefinition> partDefinitions,
                                IEnumerable<ContentPartRegisterModel> contentPartRegisters)
    {
        //Define all content types with their default content part
        foreach (var typeDefinition in typeDefinitions)
        {
            //define a content type with its content parts
            _contentDefinitionManager.AlterTypeDefinition(typeDefinition.Name, type =>
            {
                type.Draftable(typeDefinition.Draftable)
                    .Versionable(typeDefinition.Versionable)
                    .Creatable(typeDefinition.Creatable)
                    .Securable(typeDefinition.Securable)
                    .Listable(typeDefinition.Listable)
                    .WithPart(typeDefinition.DefaultContentPart.Name);

                foreach (var register in contentPartRegisters)
                {
                    if (register.ContentType == typeDefinition.Name)
                    {
                        type.WithPart($"{register.ContentPart}Part");
                    }
                }

                DefineContentPart(typeDefinition.DefaultContentPart);
            });
        }

        //Define all content parts
        foreach (var partDefinition in partDefinitions)
        {
            DefineContentPart(partDefinition, false);
        }
    }

    private void DefineContentPart(ContentPartDefinition partDefinition, bool isDefaultPart = true)
    {
        _contentDefinitionManager.AlterPartDefinition($"{partDefinition.Name}{(isDefaultPart ? "" : "Part")}", part =>
        {
            foreach (var fieldDefinition in partDefinition.ContentFields)
            {
                part.WithField(fieldDefinition.Name, field =>
                {
                    field.OfType(fieldDefinition.Type);

                    if (!String.IsNullOrEmpty(fieldDefinition.DisplayName))
                    {
                        field.WithDisplayName(fieldDefinition.DisplayName);
                    }

                    if (!String.IsNullOrEmpty(fieldDefinition.Description))
                    {
                        field.WithDescription(fieldDefinition.Description);
                    }

                    if (!Object.ReferenceEquals(null, fieldDefinition.Settings))
                    {
                        if (fieldDefinition.Type == ContentFieldTypes.TextField)
                        {
                            field.WithSettings((TextFieldSettings)fieldDefinition.Settings);
                        }
                        else if (fieldDefinition.Type == ContentFieldTypes.DateField)
                        {
                            field.WithSettings((DateFieldSettings)fieldDefinition.Settings);
                        }
                        else if (fieldDefinition.Type == ContentFieldTypes.DateTimeField)
                        {
                            field.WithSettings((DateTimeFieldSettings)fieldDefinition.Settings);
                        }
                        else if (fieldDefinition.Type == ContentFieldTypes.ContentPickerField)
                        {
                            field.WithSettings((ContentPickerFieldSettings)fieldDefinition.Settings);
                        }
                    }
                });
            }
        });
    }
}