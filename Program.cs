using TodoLIstApp.categories;
using TodoLIstApp.tasks;

namespace TodoLIstApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //Application.Run(new loginForm());
            Application.Run(new tasksForm());
            //Application.Run(new SignUpForm());
            //Application.Run(new CategoryForm());
        }
    }
}