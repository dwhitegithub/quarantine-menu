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

namespace QuarantineMenu.Pages.Pantrys
{
    public class IndexModel : PageModel
    {
        private readonly QuarantineMenu.Data.QuarantineMenuContext _context;

        public IndexModel(QuarantineMenu.Data.QuarantineMenuContext context)
        {
            _context = context;
        }

        public IList<Pantry> Pantry { get;set; }
        public IList<Food> Food { get; set; }
        //public IList<FoodKind> FoodKind { get; set; }

        public async Task OnGetAsync()
        {
            var pantrys = _context.Pantry
                            .Include(f => f.Food)
                            .OrderBy(f => f.Food.Name)
                            .AsNoTracking();


            Pantry = await pantrys.ToListAsync();


        }
    }
}
