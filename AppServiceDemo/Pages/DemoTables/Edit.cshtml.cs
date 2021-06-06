using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppServiceDemo.Data;
using AppServiceDemo.Models;

namespace AppServiceDemo.Pages.DemoTables
{
    public class EditModel : PageModel
    {
        private readonly AppServiceDemo.Data.AppServiceDemoContext _context;

        public EditModel(AppServiceDemo.Data.AppServiceDemoContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DemoTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DemoTableExists(DemoTable.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DemoTableExists(int id)
        {
            return _context.DemoTable.Any(e => e.Id == id);
        }
    }
}
