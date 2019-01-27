using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ITEC_491_GroupProject.Utils
{
    public static class Input
    {
        //public static string GetInput()
        //{
        //    string consoleRead = Console.ReadLine();
        //    int input;
        //    while (!Regex.IsMatch(consoleRead, "/^[0-9A-Za-z\\s\\-]+$/") || int.try)
        //    {
        //        Console.WriteLine("Invalid input. Enter again: ");
        //        consoleRead = Console.ReadLine();
        //    }
        //    ReturnInput(consoleRead);
        //}
        public static string ReturnInput(string input)
        {
            return input;
        }
        public static DateTime GetDate(string date)
        {
            DateTime result;
            DateTime.TryParseExact(date, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out result);

            return result;
        }
    }
}
