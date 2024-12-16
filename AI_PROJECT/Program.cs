using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AI_PROJECT.BLL;
using AI_PROJECT.DAL;
using AI_PROJECT.UI;
namespace AI_PROJECT
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var userService = new UserService();
            Application.Run(new LoginForm(userService));
        }
    }
}
