using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AppServiceDemo.Data;
using AppServiceDemo.Models;

namespace AppServiceDemo.Pages.DemoTables
{
    public class CreateModel : PageModel
    {
        private readonly AppServiceDemo.Data.AppServiceDemoContext _context;

        public CreateModel(AppServiceDemo.Data.AppServiceDemoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public DemoTable DemoTable { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DemoTable.Add(DemoTable);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
