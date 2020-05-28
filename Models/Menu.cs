using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuarantineMenu.Models
{
    public class Menu
    {
        public int MenuID { get; set; }
        public DateTime Date { get; set; }
        public int MealID { get; set; }
        public int FoodID { get; set; }

        public MealKind MealKind { get; set; }
        public Food Food { get; set; }

    }
}
