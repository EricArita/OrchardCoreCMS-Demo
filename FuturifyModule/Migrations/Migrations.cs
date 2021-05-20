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
using System.Linq;
using YesSql;
using YesSql.Sql.Schema;

public class Migrations : DataMigration
{
    private readonly IContentDefinitionManager _contentDefinitionManager;
    private readonly IStore _store;

    public Migrations(IContentDefinitionManager contentDefinitionManager, IStore store)
    {
        _contentDefinitionManager = contentDefinitionManager;
        _store = store;
    }

    public int Create()
    {
        DefineContents(ContentConfig.ContentTypes, ContentConfig.ContentParts, ContentConfig.ContentPartRegisters);
        CreateIndexTables(ContentConfig.ContentTypes, ContentConfig.ContentParts, ContentConfig.ContentPartRegisters);

        Console.WriteLine("Migration run successfully !!!");
        return 1;
    }

    private void DefineContents(IEnumerable<ContentTypeDefinition> typeDefinitions,
                                IEnumerable<ContentPartDefinition> partDefinitions,
                                IEnumerable<ContentPartRegisterModel> contentPartRegisters)
    {
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

                DefineContentPart(typeDefinition.DefaultContentPart, true);
            });
        }

        //Define all content parts
        foreach (var partDefinition in partDefinitions)
        {
            DefineContentPart(partDefinition);
        }
    }

    private void DefineContentPart(ContentPartDefinition partDefinition, bool isDefaultPart = false)
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

                    if (fieldDefinition.Settings is object)
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
                        else if (fieldDefinition.Type == ContentFieldTypes.BooleanField)
                        {
                            field.WithSettings((BooleanFieldSettings)fieldDefinition.Settings);
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

    private void CreateIndexTables(IEnumerable<ContentTypeDefinition> typeDefinitions,
                                   IEnumerable<ContentPartDefinition> partDefinitions,
                                   IEnumerable<ContentPartRegisterModel> contentPartRegisters)
    {
        foreach (var typeDefinition in typeDefinitions)
        {
            if (!typeDefinition.InBagPart)
            {
                SchemaBuilder.CreateMapIndexTable($"{typeDefinition.Name}Index", table =>
                {
                    table.Column<string>("ContentItemId"); // Default column for all index tables
                    AddIndexColumns(table, typeDefinition.DefaultContentPart.ContentFields);

                    var typeHasParts = contentPartRegisters.Where(x => x.ContentType == typeDefinition.Name).Select(x => x.ContentPart);

                    foreach (var contentPart in partDefinitions)
                    {
                        if (typeHasParts.Contains(contentPart.Name))
                        {
                            AddIndexColumns(table, contentPart.ContentFields);
                        }
                    }
                });
            }
        }
    }

    private void AddIndexColumns(ICreateTableCommand table, List<ContentFieldDefinition> fieldDefinitions)
    {
        foreach (var fieldDefinition in fieldDefinitions)
        {
            if (fieldDefinition.Type == ContentFieldTypes.TextField || fieldDefinition.Type == ContentFieldTypes.ContentPickerField)
            {
                table.Column<string>(fieldDefinition.Name);
            }
            else if (fieldDefinition.Type == ContentFieldTypes.NumericField)
            {
                table.Column<int>(fieldDefinition.Name);
            }
            else if (fieldDefinition.Type == ContentFieldTypes.BooleanField)
            {
                table.Column<bool>(fieldDefinition.Name);
            }
            else if (fieldDefinition.Type == ContentFieldTypes.DateField || fieldDefinition.Type == ContentFieldTypes.DateField)
            {
                table.Column<DateTime>(fieldDefinition.Name);
            }
        }
    }
}