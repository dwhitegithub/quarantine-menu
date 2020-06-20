using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuarantineMenu.Models;

namespace QuarantineMenu.Pages.Components.WeekCount 
{
    public class WeekCountViewComponent : ViewComponent
    {
        private readonly QuarantineMenu.Data.QuarantineMenuContext _context;
        private readonly List<Pantry> _pantryList;
        private readonly List<Menu> _menuList;
        public WeekCountViewComponent(QuarantineMenu.Data.QuarantineMenuContext context)
        {
            _context = context;
            _pantryList = context.Pantry.ToList();
            _menuList = _context.Menu.ToList();
        }

        public List<Food> FoodList { get; set; }
        public List<Pantry> PantryList { get; set; }
        public Food Food { get; set; }
        public Pantry Pantry { get; set; }
        public List<Menu> Menus { get; set; }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            DayOfWeek myDayOfWeek = DateTime.Now.DayOfWeek;
            DateTime dtStart = DateTime.Now;
            DateTime dtEnd = DateTime.Now;
            switch (myDayOfWeek)
            {
                case DayOfWeek.Monday:
                    dtEnd = dtStart.AddDays(7);
                    break;
                case DayOfWeek.Tuesday:
                    dtStart = dtStart.AddDays(-1);
                    dtEnd = dtStart.AddDays(7);
                    break;
                case DayOfWeek.Wednesday:
                    dtStart = dtStart.AddDays(-2);
                    dtEnd = dtStart.AddDays(7);
                    break;
                case DayOfWeek.Thursday:
                    dtStart = dtStart.AddDays(-3);
                    dtEnd = dtStart.AddDays(7);
                    break;
                case DayOfWeek.Friday:
                    dtStart = dtStart.AddDays(-4);
                    dtEnd = dtStart.AddDays(7);
                    break;
                case DayOfWeek.Saturday:
                    dtStart = dtStart.AddDays(-5);
                    dtEnd = dtStart.AddDays(7);
                    break;
                case DayOfWeek.Sunday:
                    dtStart = dtStart.AddDays(-6);
                    dtEnd = dtStart.AddDays(7);
                    break;
                default:
                    break;
            }


            
            // generate list of Meals on or after today
            // Meals (Menu object) and Food 
            List<Menu> Menus = await _context.Menu
                .Where(f => f.MealDate >= dtStart.Date)
                .Include(f => f.Food)
                .ToListAsync();

           // count Foods from meals (Menus)
           var  MenusList = Menus.GroupBy(f => f.FoodID)
              .Select(g =>
                  new FoodCount()
                  {
                      FoodID = g.Key,
                      Count = g.Count()
                  }   
               );

            List<FoodCount> FoodCountList = new List<FoodCount>();

            foreach (FoodCount fc in MenusList)
            {
                var varFood = from menu in Menus
                              where menu.FoodID == fc.FoodID
                              select new { FoodID = menu.FoodID, Name = menu.Food.Name };
                Food food = new Food() ;
                food.FoodID = varFood.First().FoodID;
                food.Name = varFood.First().Name;
                fc.Food = food;
                FoodCountList.Add(fc);
            }
          
            foreach (FoodCount fcl in FoodCountList.OrderBy(f => f.Food.Name))
            {
                var pantryCount = from pantryItem in _pantryList
                                  where pantryItem.FoodID == fcl.FoodID
                                  select new { PantryCount = pantryItem.Count };
                if (pantryCount == null)
                { 
                    fcl.PantryCount = 0 ; 
                }
                else
                { 
                    fcl.PantryCount = (int)pantryCount.First().PantryCount ; 
                }
                fcl.PantryCount = fcl.PantryCount - fcl.Count;
            }

            return View(FoodCountList);
        }

        public void OnPost() { }



    }
}
