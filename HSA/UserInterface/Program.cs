using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HSA.UserInterface
{
    static class Program
    {

        // ----------------------------------------------------------------------------------------------------

        // First point of the application

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        // ----------------------------------------------------------------------------------------------------

        // Main method

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }

        // ----------------------------------------------------------------------------------------------------

    }
}
