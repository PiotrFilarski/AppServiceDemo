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
    public class DetailsModel : PageModel
    {
        private readonly AppServiceDemo.Data.AppServiceDemoContext _context;

        public DetailsModel(AppServiceDemo.Data.AppServiceDemoContext context)
        {
            _context = context;
        }

        public DemoTable DemoTable { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DemoTable = await _context.DemoTable.FirstOrDefaultAsync(m => m.Id == id);

            if (DemoTable == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
