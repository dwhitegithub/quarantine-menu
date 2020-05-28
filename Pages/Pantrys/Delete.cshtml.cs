using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuarantineMenu.Data;
using QuarantineMenu.Models;

namespace QuarantineMenu.Pages.Pantrys
{
    public class DeleteModel : PageModel
    {
        private readonly QuarantineMenu.Data.QuarantineMenuContext _context;

        public DeleteModel(QuarantineMenu.Data.QuarantineMenuContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pantry Pantry { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pantry = await _context.Pantry
                .Include(p => p.Food).FirstOrDefaultAsync(m => m.PantryID == id);

            if (Pantry == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pantry = await _context.Pantry.FindAsync(id);

            if (Pantry != null)
            {
                _context.Pantry.Remove(Pantry);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
