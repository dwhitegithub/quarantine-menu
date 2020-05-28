using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuarantineMenu.Data;
using QuarantineMenu.Models;

namespace QuarantineMenu.Pages.FoodKinds
{
    public class EditModel : PageModel
    {
        private readonly QuarantineMenu.Data.QuarantineMenuContext _context;

        public EditModel(QuarantineMenu.Data.QuarantineMenuContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FoodKind FoodKind { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FoodKind = await _context.FoodKind.FirstOrDefaultAsync(m => m.FoodKindID == id);

            if (FoodKind == null)
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

            _context.Attach(FoodKind).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodKindExists(FoodKind.FoodKindID))
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

        private bool FoodKindExists(int id)
        {
            return _context.FoodKind.Any(e => e.FoodKindID == id);
        }
    }
}
