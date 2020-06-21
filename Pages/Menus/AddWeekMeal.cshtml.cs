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
            
            MenuList = GetCalendar(MenuList, StartDay);
            MenuList.OrderBy(f => f.MealDate);
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
            MenuList = GetCalendar(MenuList, StartDay);
            MenuList.OrderBy(f => f.MealDate);
        }
        public DateTime GetStartDay(DateTime TargetDate)
        {
            DayOfWeek myDayOfWeek = TargetDate.DayOfWeek;
            DateTime dtStart =TargetDate;
            DateTime dtEnd = TargetDate;
            switch (myDayOfWeek)
            {
                case DayOfWeek.Monday:
                    dtStart = dtStart.AddDays(-1);
                    dtEnd = dtStart.AddDays(7);
                    break;
                case DayOfWeek.Tuesday:
                    dtStart = dtStart.AddDays(-2);
                    dtEnd = dtStart.AddDays(7);
                    break;
                case DayOfWeek.Wednesday:
                    dtStart = dtStart.AddDays(-3);
                    dtEnd = dtStart.AddDays(7);
                    break;
                case DayOfWeek.Thursday:
                    dtStart = dtStart.AddDays(-4);
                    dtEnd = dtStart.AddDays(7);
                    break;
                case DayOfWeek.Friday:
                    dtStart = dtStart.AddDays(-5);
                    dtEnd = dtStart.AddDays(7);
                    break;
                case DayOfWeek.Saturday:
                    dtStart = dtStart.AddDays(-6);
                    dtEnd = dtStart.AddDays(7);
                    break;
                case DayOfWeek.Sunday:
                    dtEnd = dtStart.AddDays(7);
                    break;
                default:
                    break;
            }

            return dtStart;
        }

        public IList<Menu> GetCalendar(IList<Menu> menuList, DateTime beginDate)
        {
            var myDays = menuList.GroupBy(f => f.MealDate)
                .Select(g =>
                  new WeekDayCount()
                  {
                      WeekDay = g.Key.DayOfWeek,
                      Count = g.Count()
                  }
               );

            List<WeekDayCount> weekDays = myDays.ToList();
            
            //Sunday
            if (!weekDays.Exists(f => f.WeekDay == DayOfWeek.Sunday))
            {
                Menu amenu = new Menu();
                amenu.MealDate = beginDate;
                menuList.Insert(0,amenu);
            }
            //Monday
            if (!weekDays.Exists(f => f.WeekDay == DayOfWeek.Monday) )
            {
                Menu amenu = new Menu();
                amenu.MealDate = beginDate.AddDays(1);
                menuList.Insert(1, amenu);
            }
            //Tuesday
            if (!weekDays.Exists(f => f.WeekDay == DayOfWeek.Tuesday) )
            {
                Menu amenu = new Menu();
                amenu.MealDate = beginDate.AddDays(2);
                menuList.Insert(2, amenu);
            }
            //Wednesday
            if (!weekDays.Exists(f => f.WeekDay == DayOfWeek.Wednesday) )
            {
                Menu amenu = new Menu();
                amenu.MealDate = beginDate.AddDays(3);
                menuList.Insert(3, amenu);
            }
            //Thursday
            if (!weekDays.Exists(f => f.WeekDay == DayOfWeek.Thursday))
            {
                Menu amenu = new Menu();
                amenu.MealDate = beginDate.AddDays(4);
                menuList.Insert(4, amenu);
            }
            //Friday
            if (!weekDays.Exists(f => f.WeekDay == DayOfWeek.Friday))
            {
                Menu amenu = new Menu();
                amenu.MealDate = beginDate.AddDays(5);
                menuList.Insert(5, amenu);
            }
            //Saturday
            if (!weekDays.Exists(f => f.WeekDay == DayOfWeek.Saturday)  )
            {
                Menu amenu = new Menu();
                amenu.MealDate = beginDate.AddDays(6);
                menuList.Insert(6, amenu);
            }

            return menuList.OrderBy(f=>f.MealDate).ToList();          
        }
    }
}
