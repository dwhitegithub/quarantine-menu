using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuarantineMenu.Data;
using QuarantineMenu.Models;
using System.Globalization;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace QuarantineMenu.Pages
{
    public class IndexModel : PageModel
    {

        private readonly QuarantineMenu.Data.QuarantineMenuContext _context;

        public  IndexModel(QuarantineMenu.Data.QuarantineMenuContext context)
        {
            _context = context;
        }

        public WeekCount WeekCount;

    }
}