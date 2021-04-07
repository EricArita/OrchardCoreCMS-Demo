using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using System;
using YesSql;
using YesSql.Sql;

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
       _contentDefinitionManager.AlterTypeDefinition("StaffAAV", type => type
               // content items of this type can have drafts
               .Draftable()
               // content items versions of this type have saved
               .Versionable()
               // this content type appears in the New menu section
               .Creatable()
               // permissions can be applied specifically to instances of this type
               .Securable()
               .WithPart("TitlePart", part => part.WithDescription("Title of this content type"))
               .WithPart("StaffAAV")
       );

        _contentDefinitionManager.AlterPartDefinition("StaffAAV", part => part
                .WithField("FullName", field => field
                    .OfType("TextField")
                    .WithDisplayName("Full Name")
                    .WithDescription("Full name of staff")
                )
                .WithField("Age", field => field
                    .OfType("NumericField")
                    .WithDisplayName("Age")
                    .WithDescription("Age of staff")
                )
        );

        Console.WriteLine("Migration run successfully !!!");

        return 1;
    }

    public int UpdateFrom2()
    {
        _contentDefinitionManager.AlterPartDefinition("StaffAAV", part => part
               .WithField("DOB", field => field
                   .OfType("DateField")
                   .WithDisplayName("Birth day")
                   .WithDescription("Birth day of staff")
               )
        );

        return 3;
    }

    public int UpdateFrom3()
    {
        _contentDefinitionManager.AlterPartDefinition("StaffAAV", part => part
               .WithField("DOB", field => field
                   .OfType("TextField")
                   .WithDisplayName("Birth day")
                   .WithDescription("Birth day of staff")
               )
        );

        return 4;
    }

    public int UpdateFrom4()
    {
        _contentDefinitionManager.AlterPartDefinition("StaffAAV", part => part
               .WithField("DOB", field => field
                   .OfType("TextField")
                   .WithDisplayName("Birth day")
                   .WithDescription("Birth day of staff")
               )
        );

        return 5;
    }

    public int UpdateFrom5()
    {
        _contentDefinitionManager.AlterPartDefinition("StaffAAV", part => part
               .WithField("DOB", field => field
                   .OfType("TextField")
                   .WithDisplayName("Birth day")
                   .WithDescription("Birth day of staff")
               )
        );

        return 6;
    }

    public int UpdateFrom6()
    {

        _contentDefinitionManager.AlterPartDefinition("StaffAAV", part => part
               .RemoveField("DOB")
               .WithField("DOB", field => field
                   .OfType("TextField")
                   .WithDisplayName("Birth day")
                   .WithDescription("Birth day of staff")
               )
        );

        return 7;
    }

    public int UpdateFrom7()
    {
        SchemaBuilder.CreateMapIndexTable("StaffAAVIndex", table => table
                           .Column<DateTime>("DOB")
                           .Column<string>("FullName")
                           .Column<int>("Age")
                      )
                      .CreateMapIndexTable("StaffAAVIndex_1", table => table
                           .Column<DateTime>("DOB")
                           .Column<string>("FullName")
                           .Column<int>("Age")
                      );

        return 8;
    }

    public int UpdateFrom8()
    {
        SchemaBuilder.CreateTable("TEST_TABLE", table => table
                          .Column<DateTime>("DOB")
                          .Column<string>("FullName")
                          .Column<int>("AgeEEEEE")
                     );

        return 9;
    }

    public int UpdateFrom9()
    {
        SchemaBuilder.AlterTable("TEST_TABLE", table =>
        {
            table.AddColumn<string>("HelloWord");
        });

        return 10;
    }
}