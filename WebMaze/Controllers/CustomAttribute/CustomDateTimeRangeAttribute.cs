using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.Controllers.CustomAttribute
{
    public class CustomDateTimeRangeAttribute : RangeAttribute
    {
        public CustomDateTimeRangeAttribute()
        : base(typeof(DateTime),
            DateTime.Now.ToShortDateString(),
            DateTime.Now.AddYears(5).ToShortDateString())
        {}
        public override string FormatErrorMessage(string name)
        {
            return base.FormatErrorMessage(name);
        }
    }
}
