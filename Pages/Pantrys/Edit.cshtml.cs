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

namespace QuarantineMenu.Pages.Pantrys
{
    public class EditModel : PageModel
    {
        private readonly QuarantineMenu.Data.QuarantineMenuContext _context;

        public EditModel(QuarantineMenu.Data.QuarantineMenuContext context)
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
           ViewData["FoodID"] = new SelectList(_context.Food, "FoodID", "FoodID");
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

            _context.Attach(Pantry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PantryExists(Pantry.PantryID))
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

        private bool PantryExists(int id)
        {
            return _context.Pantry.Any(e => e.PantryID == id);
        }
    }
}
