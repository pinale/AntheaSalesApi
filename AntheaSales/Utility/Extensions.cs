using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AntheaSales.Utility
{
    public static class Extensions
    {
        public static double Rnd(this double number)
        {
            return Math.Ceiling(number * 20) / 20;
            //return Math.Round(number * 20) / 20;
        }
    }
}