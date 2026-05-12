using System;
using System.Windows.Forms;

namespace Sistem_Penyewaan_Studio_Musik
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Langsung ke FormLogin dulu, bukan FormDashboard
            Application.Run(new FormDashboard());
        }
    }
}