using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace WFShook
{
    public partial class WordsTest : Form
    {
        private List<string> words;
        private int months;
        private ImageList il;

        public WordsTest(List<string> words, int months)
        {
            InitializeComponent();
            this.words = words;
            this.months = months;
            displayWords(words, months);
        }

        private void checkboxSelected(object sender, EventArgs e)
        {
            string definition = ((Control)sender).Name;
        }

        private CheckBox createCheckBox(Word word, int tab)
        {
            CheckBox cb = new CheckBox();
            cb.Appearance = System.Windows.Forms.Appearance.Button;
            ///cb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ///cb.AutoSize = true;
            //cb.Size = new System.Drawing.Size(124, 96);
            ///if (File.Exists(Data.BG.Path))
               /// cb.BackgroundImage = Image.FromFile(Data.BG.Path);

            if (File.Exists(word.Path))
            {
                Image image = Image.FromFile(word.Path);
                il.Images.Add(image);
                cb.ImageList = il;
                cb.ImageIndex = il.Images.Count - 1;
            }
            //pb.Image = Image.FromFile(category.Path);

            cb.Name = word.Definition;
            cb.Size = new System.Drawing.Size(240, 240);
            //pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            cb.Text = word.Name;
            cb.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            cb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cb.UseVisualStyleBackColor = true;

            cb.CheckedChanged += new System.EventHandler(checkboxSelected);

            cb.TabIndex = tab;
            cb.TabStop = true;

            return cb;
        }

        private CheckBox createCheckBoxOld(int n)
        {
            CheckBox cb = new CheckBox();
            cb.Appearance = System.Windows.Forms.Appearance.Button;
            cb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            cb.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            cb.Name = "checkBox" + n;
            cb.Size = new System.Drawing.Size(124, 96);
            cb.TabIndex = 1;
            ///string name = Path.GetFileNameWithoutExtension(imageFiles[n]);
            ///cb.Text = name;
            cb.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            cb.UseVisualStyleBackColor = true;
            cb.ImageIndex = n;
            cb.ImageList = il;
            cb.CheckedChanged += new System.EventHandler(checkBoxSelected);
            return cb;
        }

        //private 
        private void displayWords(List<string> words, int months)
        {
            il = new ImageList();
            il.ImageSize = new Size(240, 240);
            int n = 1;
            foreach(string w in words)
            {
                flp.Controls.Add(createCheckBox(new Word { Definition = w }, n++));
            }
        }

        private void checkBoxSelected(object sender, EventArgs e)
        {
            Console.WriteLine(sender.GetType());
            Console.WriteLine(e.ToString());

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
