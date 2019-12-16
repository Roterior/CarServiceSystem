using CarServiceSystem.src.form;
using System;
using System.Windows.Forms;

namespace CarServiceSystem
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location));
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
