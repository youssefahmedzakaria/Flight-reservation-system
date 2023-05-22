namespace GUI
{
    internal static class Program
    {
        public const string connectionString = "Data Source=DESKTOP-LTOVK9O;Initial Catalog=flightSystem;Integrated Security=True";
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new mainMenu());
        }
    }
}