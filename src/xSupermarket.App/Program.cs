using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace xSupermarket.App
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string AppTheme = "DevExpress Style";

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            SkinManager.EnableFormSkinsIfNotVista();
            SkinManager.EnableMdiFormSkins();
            UserLookAndFeel.Default.SetSkinStyle(AppTheme);
            
            Application.Run(new MainForm());
        }
    }
}
