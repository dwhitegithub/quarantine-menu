﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuarantineMenu.Data;
using QuarantineMenu.Models;

namespace QuarantineMenu.Pages.MealKinds
{
    public class DetailsModel : PageModel
    {
        private readonly QuarantineMenu.Data.QuarantineMenuContext _context;

        public DetailsModel(QuarantineMenu.Data.QuarantineMenuContext context)
        {
            _context = context;
        }

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
    }
}
