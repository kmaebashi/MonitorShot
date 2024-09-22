using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace MonitorShot
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            int targetScreen = 0;
            Keys captureKey = Keys.Insert;
            string defaultFolder = null;

            try
            {
                string targetScreenStr = ConfigurationManager.AppSettings["targetScreen"];
                targetScreen = Int32.Parse(targetScreenStr);

                string captureKeyStr = ConfigurationManager.AppSettings["captureKey"];
                captureKey = (Keys)Enum.Parse(typeof(Keys), captureKeyStr);

                defaultFolder = ConfigurationManager.AppSettings["defaultFolder"];
            }
            catch (Exception ex)
            {
                Log.Write("構成ファイルの読み込みエラーです。");
                Log.Write("ex.." + ex);
                Environment.Exit(1);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MonitorShotForm(targetScreen, captureKey, defaultFolder));

        }
    }
}
