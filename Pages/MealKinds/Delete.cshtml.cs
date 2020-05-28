using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuarantineMenu.Data;
using QuarantineMenu.Models;

namespace QuarantineMenu.Pages.MealKindID
{
    public class DeleteModel : PageModel
    {
        private readonly QuarantineMenu.Data.QuarantineMenuContext _context;

        public DeleteModel(QuarantineMenu.Data.QuarantineMenuContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MealKind MealKind { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MealKind = await _context.MealKind.FirstOrDefaultAsync(m => m.MealKindID == id);

            if (MealKind == null)
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

            MealKind = await _context.MealKind.FindAsync(id);

            if (MealKind != null)
            {
                _context.MealKind.Remove(MealKind);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
