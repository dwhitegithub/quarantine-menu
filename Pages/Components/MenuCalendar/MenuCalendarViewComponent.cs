using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuarantineMenu.Models;

namespace QuarantineMenu.Pages.Components.MenuCalendar
{
    public class MenuCalendarViewComponent : ViewComponent
    {
        private readonly QuarantineMenu.Data.QuarantineMenuContext _context;
        private readonly List<Menu> _menuList;
        public MenuCalendarViewComponent(QuarantineMenu.Data.QuarantineMenuContext context)
        {
            _context = context;
            _menuList = _context.Menu.ToList();
        }
        public List<Menu> Menus { get; set; }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // figure the start cell of the calendar
            // figure rowcount of the calendar
            //populate cells before month.1
            // populate cells
            // populate cells after month.last   

            // get a list of menus for the current month
            Menus = await GetMonthMenuList(DateTime.Now);
            Menu startMenu = Menus.FirstOrDefault<Menu>();
            DayOfWeek startDay = startMenu.MealDate.DayOfWeek;


            //IEnumerator<List<Menu>> menuList = (IEnumerator<List<Menu>>)(IEnumerator<dynamic>)Menus;
            //IEnumerator<List<Menu>> menuList =  (IEnumerator<List<Menu>>)GetMonthMenuList(DateTime.Now, DateTime.Now);

            return View(Menus);

        }

        private async Task<List<Menu>> GetMonthMenuList(DateTime dtMonth)
        {
            List<Menu> menus = await _context.Menu
                .Where(f => f.MealDate.Month == DateTime.Now.Month)
                .Include(f => f.Food)
                .Include(f => f.MealKind)
                .ToListAsync();

            return menus;
        }
        private async Task<IEnumerator<List<Menu>>> GetMonthMenuList(DateTime dtMonth, DateTime dtStartDay)
        {
            IEnumerator < List < Menu >> menus = (IEnumerator<List<Menu>>)await _context.Menu
                .Where(f => f.MealDate.Month == DateTime.Now.Month)
                .Include(f => f.Food)
                .ToListAsync();

            return menus;

        }

    }
}
