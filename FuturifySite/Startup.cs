using FuturifyModule.Indexes;
using FuturifyModule.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrchardCore.ContentManagement;
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

            services.AddSingleton<IIndexProvider, OrderContentItemIndexProvider>();
            services.AddSingleton<IIndexProvider, OrderDetailContentItemIndexProvider>();

            services.AddContentPart<OrderPart>();
            services.AddContentPart<AnotherOrderDetailPart>();

            #region Use this code only when calling InitialDb method in Configure. Because DI will generate an instance of IStore that will be passed as an argument into Configure to initalize Db
            //@"Server=127.0.0.1;Database=yessql_db;Uid=root;Pwd=futurify@2021"
            //services.AddSingleton(serviceProvider =>
            //   StoreFactory.CreateAsync(
            //       new Configuration().UseMySql(@"Server=127.0.0.1;Database=yessql_crud;Uid=root;Pwd=admin")
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
                       .AlterTable("OrderDetailContentItemIndex", table => {
                           table.AddColumn<double>("Quantity");
                           table.AddColumn<string>("ProductContentItemId");
                        })
                        .CreateMapIndexTable("OrderContentItemIndex", table => table
                            .Column<DateTime>("Date")
                        )
                        .CreateMapIndexTable("OrderDetailContentItemIndex", table => table
                            .Column<string>("OrderContentItemId")
                        );

                    transaction.Commit();
                }
            };
        }
    }
}
