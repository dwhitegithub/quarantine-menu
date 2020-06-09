using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuarantineMenu.Data;
using QuarantineMenu.Extensions;
using QuarantineMenu.Models;

namespace QuarantineMenu.Pages.Menus
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

            List<Food> FoodList = _context.Food.ToList();
            ViewData["Foods"] = ListExtensions.ToSelectList(FoodList, "FoodID", "Name");
            List<MealKind> MealList = _context.MealKind.ToList();
            ViewData["Meals"] = ListExtensions.ToSelectList(MealList, "MealKindID", "Name");
            return Page();
        }

        [BindProperty]
        public Menu Menu { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var menus = _context.Menu
                    .AsEnumerable()
                    .Where(b => b.MealDate.ToShortDateString() == Menu.MealDate.ToShortDateString() && Menu.MealKindID == b.MealKindID)
                    .ToList();

                if (menus != null)
                {
                    if (menus.Count() > 0)
                    {
                        return RedirectToPage("./Index");
                    }
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                return RedirectToPage("./Index");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Menu.Add(Menu);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
