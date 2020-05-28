using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuarantineMenu.Data;
using QuarantineMenu.Extensions;
using QuarantineMenu.Models;

namespace QuarantineMenu.Pages.Foods
{
    public class IndexModel : PageModel
    {
        private readonly QuarantineMenu.Data.QuarantineMenuContext _context;

        public IndexModel(QuarantineMenu.Data.QuarantineMenuContext context)
        {
            _context = context;
        }

        public IList<Food> Food { get; set; }
        public IList<FoodKind> FoodKind { get; set; }

        public async Task OnGetAsync()
        {
            var foods =  _context.Food
                .Include(f => f.FoodKind)
                .AsNoTracking();
            
            Food = await foods.ToListAsync();

            //List<FoodKind> FoodKindlist = _context.FoodKind.ToList();
            //ViewData["FoodKinds"] = ListExtensions.ToSelectList(FoodKindlist, "FoodKindID", "Name");

        }
    }
}
