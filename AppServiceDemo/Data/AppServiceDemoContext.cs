using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppServiceDemo.Models;
using Microsoft.Data.SqlClient;

namespace AppServiceDemo.Data
{
    public class AppServiceDemoContext : DbContext
    {
        public AppServiceDemoContext (DbContextOptions<AppServiceDemoContext> options)
            : base(options)
        {
            var connection = (SqlConnection)Database.GetDbConnection();
            connection.AccessToken = (new Microsoft.Azure.Services.AppAuthentication.AzureServiceTokenProvider()).GetAccessTokenAsync("https://database.windows.net/", "72f988bf-86f1-41af-91ab-2d7cd011db47").Result;
        }

        public DbSet<AppServiceDemo.Models.DemoTable> DemoTable { get; set; }
    }
}
