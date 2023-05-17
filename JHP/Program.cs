using JHP.Api;

namespace JHP
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
            Config.Instance.Load();
            ApplicationConfiguration.Initialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form1 frm1 = new Form1()
            {
                ClientSize = new Size(Config.Instance.width, Config.Instance.height),
                Location = new Point(Config.Instance.x, Config.Instance.y),
                Opacity = Config.Instance.opacity / 100.0,
                FormBorderStyle = FormBorderStyle.None,
                TopMost = Config.Instance.topMost
            };
            
            Application.Run(frm1);
        }
    }
}