using System;
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
    public class IndexModel : PageModel
    {
        private readonly QuarantineMenu.Data.QuarantineMenuContext _context;

        public IndexModel(QuarantineMenu.Data.QuarantineMenuContext context)
        {
            _context = context;
        }

        public IList<Menu> Menu { get;set; }
        public IList<Food> Food { get; set; }
        public IList<MealKind> MealKind { get; set; }

        public async Task OnGetAsync()
        {
            var menus = _context.Menu
                .Include(f => f.MealKind)
                .Include(f => f.Food)
                .AsNoTracking();

            Menu = await menus.ToListAsync();
        }
    }
}
