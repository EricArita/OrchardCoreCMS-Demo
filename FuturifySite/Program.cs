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
            return BuildHost(args).RunAsync();
        }

        public static IHost BuildHost(string[] args)
            => Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                    webBuilder.UseStartup<Startup>())
                .Build();
    }
}
