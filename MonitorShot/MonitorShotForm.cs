using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace MonitorShot
{
    public partial class MonitorShotForm : Form
    {
        private int targetScreen;
        private Keys captureKey;
        private string defaultFolder;
        private string savePath;
        private int serialNumber = 1;
        private Form shutterForm;

        public MonitorShotForm(int targetScreen, Keys captureKey, String defaultFolder)
        {
            if (targetScreen < 1 || targetScreen > Screen.AllScreens.Length)
            {
                MessageBox.Show("対象のスクリーン(" + targetScreen + ")は存在しません。");
                this.Close();
                return;
            }
            this.savePath = Path.Combine(defaultFolder, DateTime.Now.ToString("yyyyMMddHHmmss"));
            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }
            InitializeComponent();

            this.targetScreen = targetScreen;
            this.captureKey = captureKey;
            this.defaultFolder = defaultFolder;
            this.shutterForm = new Form();
            shutterForm.FormBorderStyle = FormBorderStyle.None;
            Screen screen = Screen.AllScreens[targetScreen - 1];
            shutterForm.Left = screen.Bounds.X;
            shutterForm.Top = screen.Bounds.Y;
            shutterForm.Width = screen.Bounds.Width;
            shutterForm.Height = screen.Bounds.Height;
            shutterForm.StartPosition = FormStartPosition.Manual;
            shutterForm.BackColor = Color.FromArgb(100, 100, 100);
            shutterForm.TopMost = true;
            shutterForm.Opacity = 0.5;

            KeyHook.StartHook(this.captureKey, new KeyHookCallback(CaptureKeyPressed));
        }

        private void CaptureKeyPressed()
        {
            Console.WriteLine("CaptureKeyPressed");

            Screen screen = Screen.AllScreens[targetScreen - 1];
            Bitmap bitmap = new Bitmap(screen.Bounds.Width, screen.Bounds.Height);
            DateTime now = DateTime.Now;
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(new Point(screen.Bounds.X, screen.Bounds.Y), new Point(0, 0), bitmap.Size);

                if (this.embedTime.Checked)
                {
                    DrawEmbedTime(g, bitmap, now);
                }
                if (this.showCursorPosition.Checked)
                {
                    DrawCursorPosition(g, screen);
                }
            }
            string fileName = this.serialNumber.ToString("0000") + "_" + now.ToString("yyyyMMddHHmmss");
            this.serialNumber++;
            bitmap.Save(Path.Combine(this.savePath, fileName) + ".png", ImageFormat.Png);

            this.shutterForm.Show();
            Timer timer = new Timer();
            timer.Tick += new EventHandler(HideShutter);
            timer.Interval = 200;
            timer.Start();
        }

        private static void DrawEmbedTime(Graphics g, Bitmap bitmap, DateTime now)
        {
            using (Font font = new Font("ＭＳ ゴシック", 30, GraphicsUnit.Pixel))
            using (Brush brush = new SolidBrush(Color.FromArgb(100, 255, 128, 128)))
            {
                g.DrawString(now.ToString("yyyy/MM/dd HH:mm:ss"), font, brush, 0, bitmap.Height - 30);
            }
        }

        private static void DrawCursorPosition(Graphics g, Screen screen)
        {
            int localX = Cursor.Position.X - screen.Bounds.X;
            int localY = Cursor.Position.Y - screen.Bounds.Y;
            if (localX < 0 || localX >= screen.Bounds.Width
                || localY < 0 || localY >= screen.Bounds.Height)
            {
                return;
            }
            using (Pen pen = new Pen(Color.FromArgb(100, 255, 128, 128), 3))
            {
                g.DrawEllipse(pen, localX - 10, localY - 10, 20, 20);
            }
        }

        private void HideShutter(object sender, EventArgs e)
        {
            this.shutterForm.Hide();
        }

        private void MonitorShotForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            KeyHook.EndHook();
        }
    }
}
