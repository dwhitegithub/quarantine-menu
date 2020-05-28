using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace QuarantineMenu.Models
{
    public class Pantry
    {
        [Key]
        public int PantryID { get; set; }

        public int Count { get; set; }

        [ForeignKey("Food")]
        public int FoodID { get; set; }

        [NotMapped]
        public string FoodName { get; set; }

        public Food Food { get; set; }

    }
}
