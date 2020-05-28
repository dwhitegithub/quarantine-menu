using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuarantineMenu.Data;
using QuarantineMenu.Models;

namespace QuarantineMenu.Pages.Foods
{
    public class DetailsModel : PageModel
    {
        private readonly QuarantineMenu.Data.QuarantineMenuContext _context;

        public DetailsModel(QuarantineMenu.Data.QuarantineMenuContext context)
        {
            _context = context;

        }

        public Food Food { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Food = await _context.Food.FirstOrDefaultAsync(m => m.FoodID == id);

            if (Food == null)
            {
                return NotFound();
            }
            FoodKind foodKind = _context.FoodKind.Find(Food.FoodKindID);
            Food.FoodKindName = foodKind.Name;
            return Page();
        }
    }
}
