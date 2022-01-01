using System;
using System.Drawing;
using System.Windows.Forms;

namespace ColorPixel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OpenFileDialog ofd = new OpenFileDialog();
        Color clr;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ofd.Filter = "jpg files(*.jpg)|*.jpg|png files(*.png)|*.png|jpeg files(*.jpeg)|*.jpeg|All Files(*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.ImageLocation = ofd.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                clr = colorDialog1.Color;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ofd.FileName is not null)
            {
                Bitmap image = new Bitmap(ofd.FileName);
                Random random = new Random();

                for (int i = 0; i < 50000; i++)
                {
                    int X = random.Next(image.Width);
                    int Y = random.Next(image.Height);
                    image.SetPixel(X, Y, clr);
                }

                pictureBox2.Image = image;
            }
        }
    }
}
