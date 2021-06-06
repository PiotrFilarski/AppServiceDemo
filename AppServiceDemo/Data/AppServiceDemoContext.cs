using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppServiceDemo.Models;

namespace AppServiceDemo.Data
{
    public class AppServiceDemoContext : DbContext
    {
        public AppServiceDemoContext (DbContextOptions<AppServiceDemoContext> options)
            : base(options)
        {
        }

        public DbSet<AppServiceDemo.Models.DemoTable> DemoTable { get; set; }
    }
}
