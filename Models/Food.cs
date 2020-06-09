using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuarantineMenu.Models
{
    public class Food
    {

        [Key] 
        public int FoodID { get; set; }

        public string Name { get; set; }

        [ForeignKey("FoodKind")]
        public int FoodKindID { get; set; }
        [NotMapped]
        public string FoodKindName { get; set; }

        public FoodKind FoodKind { get; set; }

    }
}
