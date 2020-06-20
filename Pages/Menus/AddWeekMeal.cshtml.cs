using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuarantineMenu.Models;

namespace QuarantineMenu.Pages.Menus
{
    public class AddWeekMealModel : PageModel
    {
        private readonly QuarantineMenu.Data.QuarantineMenuContext _context;

        public AddWeekMealModel(QuarantineMenu.Data.QuarantineMenuContext context)
        {
            context = _context;
        }

        public IList<Menu> MenuList { get; set; }
        public IList<Food> FoodList { get; set; }
        public IList<MealKind> MealList { get; set; }
        public void OnGet()
        {

        }
    }
}
