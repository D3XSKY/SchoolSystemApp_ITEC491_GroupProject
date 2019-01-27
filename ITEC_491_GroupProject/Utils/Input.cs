using System;

namespace ITEC_491_GroupProject.Utils
{
    public static class Input
    {
        public static DateTime GetDate(string date)
        {
            DateTime result;
            DateTime.TryParseExact(date, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out result);
            return result;
        }
    }
}
