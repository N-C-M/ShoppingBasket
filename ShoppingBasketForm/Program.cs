using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ShoppingBasketForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// This is a test.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
