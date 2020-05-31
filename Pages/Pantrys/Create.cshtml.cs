using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuarantineMenu.Data;
using QuarantineMenu.Models;

namespace QuarantineMenu.Pages.Pantrys
{
    public class CreateModel : PageModel
    {
        private readonly QuarantineMenu.Data.QuarantineMenuContext _context;

        public CreateModel(QuarantineMenu.Data.QuarantineMenuContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["FoodID"] = new SelectList(_context.Food, "FoodID", "Name");
            return Page();
        }

        [BindProperty]
        public Pantry Pantry { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            // check for existing record for that food
            var pantrys = _context.Pantry
                .AsEnumerable()
                .Where(b => b.FoodID == Pantry.FoodID)
                .ToList();

            if (pantrys.Count > 0)
            {
                return RedirectToPage("./Index");
            }

            _context.Pantry.Add(Pantry);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
