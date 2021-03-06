﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuarantineMenu.Data;
using QuarantineMenu.Models;

namespace QuarantineMenu.Pages.Menus
{
    public class DetailsModel : PageModel
    {
        private readonly QuarantineMenu.Data.QuarantineMenuContext _context;

        public DetailsModel(QuarantineMenu.Data.QuarantineMenuContext context)
        {
            _context = context;
        }

        public Menu Menu { get; set; }
        public Food Food { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Menu = await _context.Menu.FirstOrDefaultAsync(m => m.MenuID == id);

            if (Menu == null)
            {
                return NotFound();
            }

            Food food = _context.Food.Find(Menu.FoodID);
            MealKind mealKind = _context.MealKind.Find(Menu.MealKindID);

            Menu.FoodName = food.Name;
            Menu.MealKindName = mealKind.Name;

            return Page();
        }
    }
}
