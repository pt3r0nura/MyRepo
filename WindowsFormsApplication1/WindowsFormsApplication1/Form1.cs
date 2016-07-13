using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap croppedPlateNumber = null;
            Image img = Image.FromFile(textBox1.Text);
            Bitmap bmp = new Bitmap(img);

            int x = 50;//Convert.ToInt32(rect.left);
            int y = 50;//Convert.ToInt32(rect.top);
            int x1 = 100;//Convert.ToInt32(rect.right);
            int y1 = 110;//Convert.ToInt32(rect.bottom);
            string folder = "c:\\tmp";
            string fileName = DateTime.Now.Ticks.ToString() + ".jpeg";
            string path = Path.Combine(folder, fileName);
            Rectangle imgRect = new Rectangle(x, y, x1 - x, y1 - y);
            croppedPlateNumber = bmp.Clone(imgRect, img.PixelFormat);
            croppedPlateNumber.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            textBox1.Text = openFileDialog1.FileName;
        }
    }
}
