using FuturifyModule.Indexes;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using YesSql;
using YesSql.Provider.MySql;
using YesSql.Sql;

namespace FuturifySite
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOrchardCms().AddMvc();
            services.AddSingleton(serviceProvider =>
               StoreFactory.CreateAsync(
                   new Configuration().UseMySql(@"Server=localhost;Database=futurifyorchard;Uid=root;Pwd=admin")
                                      .SetTablePrefix("futurify_")
                    ).Result
            );
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env, IStore store)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseOrchardCore();

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
                        .CreateMapIndexTable("ProjectIndex", table => table
                            .Column<string>("Code")
                            .Column<string>("Name")
                            .Column<bool>("IsDeleted")
                        )
                        .CreateReduceIndexTable("ProjectDeadlineIndex", table => table
                            .Column<int>("Count")
                            .Column<int>("Deadline")
                    );

                    transaction.Commit();
                }
            };
        }
    }
}
