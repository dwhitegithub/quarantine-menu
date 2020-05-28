using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuarantineMenu.Data;
using QuarantineMenu.Models;

namespace QuarantineMenu.Pages.FoodKinds
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
            return Page();
        }

        [BindProperty]
        public FoodKind FoodKind { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.FoodKind.Add(FoodKind);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
