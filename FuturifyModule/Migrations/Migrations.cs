using AAVModule.Constants;
using AAVModule.Migrations;
using AAVModule.Models;
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
        DefineContents(ContentConfig.ContentTypes);

        Console.WriteLine("Migration run successfully !!!");

        return 1;
    }

    private void DefineContents(List<ContentTypeDefinition> typeDefinitions)
    {
        foreach (var typeDefinition in typeDefinitions)
        {
            //define a content type with its content parts
            _contentDefinitionManager.AlterTypeDefinition(typeDefinition.Name, type =>
            {
                type = type.Draftable(typeDefinition.Draftable)
                           .Versionable(typeDefinition.Versionable)
                           .Creatable(typeDefinition.Creatable)
                           .Securable(typeDefinition.Securable)
                           .Listable(typeDefinition.Listable);

                foreach (var contentPart in typeDefinition.ContentParts)
                {
                    type.WithPart(contentPart.Name);
                }
            });

            //define content fields for each content parts of the defined content type above
            foreach (var contentPart in typeDefinition.ContentParts)
            {
                _contentDefinitionManager.AlterPartDefinition(contentPart.Name, part =>
                {
                    foreach (var fieldDefinition in contentPart.ContentFields)
                    {
                        part = part.WithField(fieldDefinition.Name, field =>
                        {
                            field.OfType(fieldDefinition.Type);

                            if (!String.IsNullOrEmpty(fieldDefinition.DisplayName))
                            {
                                field = field.WithDisplayName(fieldDefinition.DisplayName);
                            }

                            if (!String.IsNullOrEmpty(fieldDefinition.Description))
                            {
                                field = field.WithDescription(fieldDefinition.Description);
                            }

                            if (!Object.ReferenceEquals(null, fieldDefinition.Settings))
                            {
                                if (fieldDefinition.Type == ContentFieldTypes.TextField)
                                {
                                    field = field.WithSettings((TextFieldSettings)fieldDefinition.Settings);
                                }
                                else if (fieldDefinition.Type == ContentFieldTypes.DateField)
                                {
                                    field = field.WithSettings((DateFieldSettings)fieldDefinition.Settings);
                                }
                                else if (fieldDefinition.Type == ContentFieldTypes.DateTimeField)
                                {
                                    field = field.WithSettings((DateTimeFieldSettings)fieldDefinition.Settings);
                                }
                                else if (fieldDefinition.Type == ContentFieldTypes.ContentPickerField)
                                {
                                    field = field.WithSettings((ContentPickerFieldSettings)fieldDefinition.Settings);
                                }
                            }
                        });
                    }
                });
            }
        }
    }
}