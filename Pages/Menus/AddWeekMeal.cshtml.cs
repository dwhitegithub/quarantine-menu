using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuarantineMenu.Models;
using QuarantineMenu.Data;
using System.Globalization;
using System.Xml;

namespace QuarantineMenu.Pages.Menus
{
    public class AddWeekMealModel : PageModel
    {
        private readonly QuarantineMenu.Data.QuarantineMenuContext _context;

        public AddWeekMealModel(QuarantineMenu.Data.QuarantineMenuContext context)
        {
            _context = context;
        }

        public IList<Menu> MenuList { get; set; }
        public IList<Food> FoodList { get; set; }
        public IList<MealKind> MealList { get; set; }
        public IList<DateTime> WeekDates { get; set; }
        public DateTime StartDay { get; set; }
        public async Task OnGetAsync()
        {

            DateTime StartDay = GetStartDay(DateTime.Now);

            var menus = _context.Menu
                 .Include(f => f.MealKind)
                 .Include(f => f.Food)
                 .Where(f => f.MealDate >= StartDay && f.MealDate <= StartDay.AddDays(7))
                 .OrderBy(f => f.MealDate).ThenBy(f => f.MealKindID)
                 .AsNoTracking();

            MenuList = await menus.ToListAsync();
        }

        public async Task OnGetSetTargetDate(string tbTargetDate)
        {
            string starter = tbTargetDate; 
            DateTime.TryParse(starter, out DateTime StartDay);
             StartDay = GetStartDay(StartDay);

            var menus = _context.Menu
                 .Include(f => f.MealKind)
                 .Include(f => f.Food)
                 .Where(f => f.MealDate >= StartDay && f.MealDate <= StartDay.AddDays(7))
                 .OrderBy(f => f.MealDate).ThenBy(f => f.MealKindID)
                 .AsNoTracking();

            MenuList = await menus.ToListAsync();
        }
        public DateTime GetStartDay(DateTime TargetDate)
        {
            DayOfWeek myDayOfWeek = TargetDate.DayOfWeek;
            DateTime dtStart =TargetDate;
            DateTime dtEnd = TargetDate;
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

            return dtStart;
        }
    }
}
