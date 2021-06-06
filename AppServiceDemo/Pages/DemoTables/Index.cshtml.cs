using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppServiceDemo.Data;
using AppServiceDemo.Models;

namespace AppServiceDemo.Pages.DemoTables
{
    public class IndexModel : PageModel
    {
        private readonly AppServiceDemo.Data.AppServiceDemoContext _context;

        public IndexModel(AppServiceDemo.Data.AppServiceDemoContext context)
        {
            _context = context;
        }

        public IList<DemoTable> DemoTable { get;set; }

        public async Task OnGetAsync()
        {
            DemoTable = await _context.DemoTable.ToListAsync();
        }
    }
}
