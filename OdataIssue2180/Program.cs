using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OdataIssue2180.Code;

namespace OdataIssue2180
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().MigrateDatabase().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }

    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            using var appContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            appContext.Database.Migrate();

            //This is not a place to seed data.. i feel as disgusted as you are.
            SeedData(appContext);

            return host;
        }

        private static void SeedData(AppDbContext appContext)
        {
            if (!appContext.Customers.Any())
            {
                appContext.Customers.AddRange(new List<Customer>
                {
                    new Customer
                    {
                        Id = 1,
                        Color = Color.Red
                    },
                    new Customer
                    {
                        Id = 2,
                        Color = Color.Blue
                    },
                    new Customer
                    {
                        Id = 3,
                        Color = Color.Green
                    },
                });
                appContext.SaveChanges();

            }
        }
    }
}
