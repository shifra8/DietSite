using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dto
{
    public class WeeklyTrackingDto
    {
        public string CustomerId { get; set; }
        public DateTime TrackingDate { get; set; }
        public double UpdatedWeight { get; set; }
        public bool ExceededCalories { get; set; }
    }
}
