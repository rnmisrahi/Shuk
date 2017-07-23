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

namespace WFShook
{
    public partial class Categories : Form
    {
        private List<Word> categoryList;
        private int months;
        private ImageList il;

        public Categories(List<Word> categoryList, int months)
        {
            InitializeComponent();
            this.categoryList = categoryList;
            this.months = months;
            displayCategories();
        }

        private PictureBox createPictureImage(Word category, int tab)
        {
            PictureBox pb = new System.Windows.Forms.PictureBox();
            pb.BackgroundImage = Image.FromFile(Data.BG.Path);

            pb.Image = Image.FromFile(category.Path);

            pb.Name = category.Name;
            pb.Size = new System.Drawing.Size(240, 240);
            pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pb.TabIndex = tab;
            pb.TabStop = true;

            return pb;
        }

        private void button_Click(object sender, EventArgs e)
        {
            string definition = ((Control)sender).Name;
            List<string> words = Data.GetWordsInCategory(months, definition);
            if (words.Count < 1)
                MessageBox.Show("No Words in this Category");
            else
            {
                WordsTest dlg = new WordsTest(words, months);
                dlg.ShowDialog(this);
            }
        }

        private Button createButton(Word category, int tab)
        {
            Button pb = new System.Windows.Forms.Button();
            if (File.Exists(Data.BG.Path))
                pb.BackgroundImage = Image.FromFile(Data.BG.Path);

            if (File.Exists(category.Path)) { 
                Image image = Image.FromFile(category.Path);
                il.Images.Add(image);
                pb.ImageList = il;
            pb.ImageIndex = il.Images.Count - 1;
            }
            //pb.Image = Image.FromFile(category.Path);

            pb.Name = category.Definition;
            pb.Size = new System.Drawing.Size(240, 240);
            //pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pb.Text = category.Name;
            pb.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            pb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            pb.UseVisualStyleBackColor = true;

            pb.Click += new System.EventHandler(button_Click);

            pb.TabIndex = tab;
            pb.TabStop = true;

            return pb;
        }

        private void displayCategories()
        {
            il = new ImageList();
            il.ImageSize = new Size(240, 240);
            int n = 1;
            foreach(Word category in categoryList)
            {
                flp.Controls.Add(createButton(category, n++));
            }
        }

    }
}
