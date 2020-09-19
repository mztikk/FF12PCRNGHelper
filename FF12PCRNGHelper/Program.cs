using System;
using System.Diagnostics;
using System.Security.Principal;
using System.Windows.Forms;

namespace FF12PCRNGHelper
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            if (!IsAdministrator())
            {
                var res = MessageBox.Show(
                    "We need admin rights to access processes. Restart as Admin?",
                    "Elevated Permissions",
                    MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    var p = new Process();
                    p.StartInfo.FileName = Process.GetCurrentProcess().MainModule.FileName;
                    p.StartInfo.Verb = "runas";
                    p.Start();
                    Application.Exit();
                    return;
                }
            }
            try
            {
                Config.Load();
            }
            // Config has default values for when loading fails.
            catch
            {
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        internal static bool IsAdministrator()
        {
            return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
