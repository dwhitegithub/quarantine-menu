using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuarantineMenu.Models
{
    public class FoodCount
    {
        public int Count { get; set; }
        public int PantryCount { get; set; }

        [ForeignKey("Food")]
        public int FoodID { get; set; }

        [NotMapped]
        public string FoodName { get; set; } 

        public Food Food { get; set; }

        public ICollection<FoodCount> FoodCountList { get; } = new List<FoodCount>();
        public List<Pantry> PantryList { get; } = new List<Pantry>();

    }
}
