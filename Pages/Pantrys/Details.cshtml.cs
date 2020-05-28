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
    public class DetailsModel : PageModel
    {
        private readonly QuarantineMenu.Data.QuarantineMenuContext _context;

        public DetailsModel(QuarantineMenu.Data.QuarantineMenuContext context)
        {
            _context = context;
        }

        public Pantry Pantry { get; set; }
        public Food Food { get; set; }

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

            Food food = _context.Food.Find(Pantry.FoodID);
            Pantry.FoodName = food.Name;

            return Page();
        }
    }
}
