namespace ITEC_491_GroupProject.Utils
{
    /// <summary>
    /// WorkContext is used to run application. 
    /// </summary>
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
