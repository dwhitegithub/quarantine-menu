using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuarantineMenu.Models;

namespace QuarantineMenu.Pages.Shared
{
    public class WeekCountModel : PageModel
    {
        private readonly QuarantineMenu.Data.QuarantineMenuContext _context;

        public WeekCountModel(QuarantineMenu.Data.QuarantineMenuContext context)
        {
            _context = context;
        }

        public IList<Food> FoodList { get; set; }
        public IList<Pantry> PantryList { get; set; }
        public Food Food { get; set; }
        public Pantry Pantry { get; set; }
        public WeekCount WeekCount { get; set; }
        public List<Menu> Menus { get; set; }
        //public  void OnGet();
        public async Task<List<Menu>> OnGetAsync()
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
            //var menus = _context.Menu
            Menus = await _context.Menu
                .Where(f => f.MealDate >= dtStart)
                .ToListAsync();
            return Menus;
            //Menus = await (List<Menu>)menus.ToListAsync();
        }

        public void OnPost() { }

    }
}