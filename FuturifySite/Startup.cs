using FuturifyModule.Drivers;
using FuturifyModule.Indexes;
using FuturifyModule.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.Data.Migration;
using OrchardCore.Security.Permissions;
using System;
using YesSql;
using YesSql.Indexes;
using YesSql.Provider.MySql;
using YesSql.Sql;

namespace FuturifySite
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOrchardCms();
            services.AddOrchardCore();

            services.AddCors();
            services.AddHttpClient();

            //services.AddMvc().AddNewtonsoftJson(options => 
            //    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            //);

            //services.AddSingleton<IIndexProvider, OrderContentItemIndexProvider>();
            //services.AddSingleton<IIndexProvider, OrderDetailContentItemIndexProvider>();

            //services.AddContentPart<OrderDetailPart>();


            #region Use this code only when calling InitialDb method in Configure. Because DI will generate an instance of IStore that will be passed as an argument into Configure to initalize Db
            //@"Server=127.0.0.1;Database=futurify_db;Uid=root;Pwd=futurify@2021"
            //@"Server=127.0.0.1;Database=futurify_db;Uid=root;Pwd=admin"
            //services.AddSingleton(serviceProvider =>
            //   StoreFactory.CreateAsync(
            //       new Configuration().UseMySql(@"Server=127.0.0.1;Database=futurify_db;Uid=root;Pwd=futurify@2021")
            //                          .SetTablePrefix("futurify_")
            //        ).Result
            //);
            #endregion
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env/*, IStore store*/)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder.AllowAnyOrigin()
                                          .AllowAnyMethod()
                                          .AllowAnyHeader()
            );

            app.UseOrchardCore();

            app.UseStaticFiles();

            //InitialDb(store);
        }


        private static void InitialDb(IStore store)
        {
            using (var connection = store.Configuration.ConnectionFactory.CreateConnection())
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction(store.Configuration.IsolationLevel))
                {
                    new SchemaBuilder(store.Configuration, transaction)
                       .AlterTable("OrderContentItemIndex", table =>
                       {
                           table.AddColumn<string>("OrderContentItemId");
                       });
                       //.AlterTable("OrderDetailContentItemIndex", table =>
                       //{
                       //    table.AddColumn<double>("Quantity");
                       //    table.AddColumn<string>("ProductContentItemId");
                       //})
                       //.CreateMapIndexTable("OrderContentItemIndex", table => table
                       //     .Column<DateTime>("Date")
                       //)
                       //.CreateMapIndexTable("OrderDetailContentItemIndex", table => table
                       //     .Column<string>("OrderContentItemId")
                       //     .Column<double>("Quantity")
                       //     .Column<string>("ProductContentItemId")
                       //);

                    transaction.Commit();
                }
            };
        }
    }
}
