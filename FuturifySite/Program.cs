using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using YesSql;
using YesSql.Provider.MySql;
using YesSql.Sql;

namespace FuturifySite
{
    public class Program
    {
        public static Task Main(string[] args)
        {
            InitialDb();
            return BuildHost(args).RunAsync();
        }

        public static IHost BuildHost(string[] args)
            => Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                    webBuilder.UseStartup<Startup>())
                .Build();

        private static async void InitialDb()
        {
            var store = await StoreFactory.CreateAsync(
               new Configuration()
                   .UseMySql(@"Server=localhost;Database=futurifyorchard;Uid=root;Pwd=futurify@2021")
                   .SetTablePrefix("futurify")
               ); ;

            using (var connection = store.Configuration.ConnectionFactory.CreateConnection())
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction(store.Configuration.IsolationLevel))
                {
                    new SchemaBuilder(store.Configuration, transaction)
                        .CreateMapIndexTable("ProjectIndex", table => table
                            .Column<string>("Code")
                            .Column<string>("Name")
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
