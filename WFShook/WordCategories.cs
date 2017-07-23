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

namespace WFShook
{
    public partial class WordCategories : Form
    {
        const string PNG = ".png";
        const string BG = "BGBlue.png";
        public WordCategories()
        {
            InitializeComponent();
        }

        private PictureBox createPictureImage(string name, int tab)
        {
            PictureBox pb = new System.Windows.Forms.PictureBox();

            string path = Directory.GetCurrentDirectory() + @"\images\";
            pb.BackgroundImage = Image.FromFile(path + BG); ;
            pb.Image = Image.FromFile(path + name + PNG);

            pb.Location = new System.Drawing.Point(4, 41);
            pb.Name = name;
            pb.Size = new System.Drawing.Size(240, 240);
            pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pb.TabIndex = tab;
            pb.TabStop = false;

            return pb;

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void WordCategories_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
