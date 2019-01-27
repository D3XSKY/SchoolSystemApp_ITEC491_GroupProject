using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITEC_491_GroupProject.Utils
{
    public class WorkContext
    {
        public static Database database = new Database();

        public static void Run()
        {
            try
            {
                database = DatabaseUtilities.LoadData();
                Output.StartApp();
                Output.MasterOptions();
            }
            finally
            {
                Output.Exit();
            }
        }
    }
}
