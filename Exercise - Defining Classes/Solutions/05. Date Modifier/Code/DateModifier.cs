using System;
using System.Globalization;

namespace DefiningClasses {
    public class DateModifier {
        public static int CalculateDifference(string date1, string date2) {
            DateTime firstDate = DateTime.ParseExact(date1, "yyyy MM dd", CultureInfo.InvariantCulture);
            DateTime secondDate = DateTime.ParseExact(date2, "yyyy MM dd", CultureInfo.InvariantCulture);
        
            return Math.Abs((secondDate - firstDate).Days);
        }
    }   
}
