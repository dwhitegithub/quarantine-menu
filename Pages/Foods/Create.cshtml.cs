using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuarantineMenu.Data;
using QuarantineMenu.Extensions;
using QuarantineMenu.Models;

namespace QuarantineMenu.Pages.Foods
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
            List<FoodKind> FoodKindList = _context.FoodKind.ToList();
            ViewData["FoodKinds"] = ListExtensions.ToSelectList(FoodKindList, "FoodKindID", "Name");

            return Page();
        }

        [BindProperty]
        public Food Food { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            _context.Food.Add(Food);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
