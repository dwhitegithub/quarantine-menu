using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuarantineMenu.Models
{
    public class Menu
    {
        public int MenuID { get; set; }
        [DisplayFormat(DataFormatString = "{0:ddd MM/dd}") ]
        [Column("Date")]
        public DateTime MealDate { get; set; }

        [ForeignKey("MealKind")]
        public int MealKindID { get; set; }

        [ForeignKey("Food")]
        public int FoodID { get; set; }

        [NotMapped]
        public int FoodCounts { get; set; }
        [NotMapped]
        public string MealKindName { get; set; }
        [NotMapped]
        public string FoodName { get; set; }

        public MealKind MealKind { get; set; }
        public Food Food { get; set; }

    }
}
