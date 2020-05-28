using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuarantineMenu.Data;
using QuarantineMenu.Models;

namespace QuarantineMenu.Pages.FoodKinds
{
    public class IndexModel : PageModel
    {
        private readonly QuarantineMenu.Data.QuarantineMenuContext _context;

        public IndexModel(QuarantineMenu.Data.QuarantineMenuContext context)
        {
            _context = context;
        }

        public IList<FoodKind> FoodKind { get;set; }

        public async Task OnGetAsync()
        {
            FoodKind = await _context.FoodKind.ToListAsync();
        }
    }
}
