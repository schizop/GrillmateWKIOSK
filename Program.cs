using System;
using System.Windows.Forms;
using GrillMateWKiosk;

namespace GrillMateWKiosk
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Instantiate LoginForm
            LoginForm loginForm = new LoginForm();

            // Show the login form as a dialog. If it returns OK, open the table selection form.
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new TableSelectionForm());
            }
        }
    }
}