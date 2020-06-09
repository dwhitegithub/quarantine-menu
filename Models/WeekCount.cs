using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace QuarantineMenu.Models
{
    public class WeekCount
    {
        [ForeignKey("Food")]
        public int FoodID;
        [ForeignKey("MealKind")]
        public int MealKindID;
        [ForeignKey("Pantry")]
        public int PantryID;
        [NotMapped]
        public string FoodName;
        [NotMapped]
        public string MealName;
        [NotMapped]
        public string FoodKindName;

        public Food Food;
        public MealKind MealKind;
        public Menu Menu;
    }
}
