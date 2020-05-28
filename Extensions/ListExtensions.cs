using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuarantineMenu.Extensions
{

    public static class ListExtensions
    {
        public static SelectList ToSelectList<TEntity>(this List<TEntity> items, string valueField, string textField) where TEntity : class
        {
            return new SelectList(items, valueField, textField);
        }
    }

}
