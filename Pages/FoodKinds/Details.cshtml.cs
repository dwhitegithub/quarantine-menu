using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuarantineMenu.Data;
using QuarantineMenu.Models;

namespace QuarantineMenu.Pages.FoodKinds
{
    public class DetailsModel : PageModel
    {
        private readonly QuarantineMenu.Data.QuarantineMenuContext _context;

        public DetailsModel(QuarantineMenu.Data.QuarantineMenuContext context)
        {
            _context = context;
        }

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
    }
}
