using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuarantineMenu.Models
{
    public class WeekDayCount
    {
        public DayOfWeek  WeekDay { get; set; }
        public int Count { get; set; }
        public ICollection<WeekDayCount> WeekDayCountList { get; } = new List<WeekDayCount>();
    }
}
