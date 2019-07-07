using System;
using System.Windows.Forms;

namespace IgraPamcenja
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>gd
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Start());
        }
    }
}
