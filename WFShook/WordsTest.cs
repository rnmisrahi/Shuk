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
        private const double LOW_PERCENTILE = 0.40;
        private List<Word> words;
        private int months;
        private ImageList il;

        public WordsTest(string category, List<Word> words, int months)
        {
            InitializeComponent();
            this.Text = category;
            this.words = words;
            this.months = months;
            label1.Text = string.Format("Select The Words Your {0} Months Old Child Understands", months);
            displayWords(words, months);
        }

        private void checkboxSelected(object sender, EventArgs e)
        {
            grpTrackBar.Visible = txtPercentile.Visible = true;
            Control control = (Control)sender;
            string definition = control.Name;
            Word word = (Word)control.Tag;
            bool low = (word.Percentile < LOW_PERCENTILE);
            string only = low ? "ONLY " : "";
            if (low)
                txtPercentile.BackColor = Color.FromArgb(246, 141, 31);
            else
                txtPercentile.BackColor = System.Drawing.SystemColors.Control;
            txtPercentile.Text = String.Format(only + "{0:0.00} % Of Children This Age Understand The Word {1}", word.Percentile * 100, word.Definition);
            trackBar1.Value = (int)(word.Percentile * 100);
        }

        private CheckBox createCheckBox(Word word, int tab)
        {
            CheckBox cb = new CheckBox();
            //cb.Appearance = System.Windows.Forms.Appearance.Normal;
            cb.CheckAlign = ContentAlignment.TopLeft;
            //cb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            //cb.AutoSize = false;
            //if (File.Exists(Data.BG.Path))
            //   cb.BackgroundImage = Image.FromFile(Data.BG.Path);

            if (File.Exists(word.Path))
            {
                Image image = Image.FromFile(word.Path);
                il.Images.Add(image);
                cb.ImageList = il;
                cb.ImageIndex = il.Images.Count - 1;
            }
            //pb.Image = Image.FromFile(category.Path);

            cb.Tag = word;
            cb.Name = word.Definition;
            cb.Size = new System.Drawing.Size(160, 160);
            //cb.SizeMode = System.Windows.Forms.ImageLayout.Stretch;
            cb.Text = word.Name;
            cb.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            cb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cb.UseVisualStyleBackColor = true;

            cb.CheckedChanged += new System.EventHandler(checkboxSelected);

            cb.TabIndex = tab;
            cb.TabStop = true;

            return cb;
        }

        private Panel createPicPanel(Word word)
        {
            PicPanel picPanel = new PicPanel(word, 140, 160);
            picPanel.Tag = word;
            picPanel.rbYes.Click += new System.EventHandler(checkboxSelected);
            picPanel.rbNo.Click += new System.EventHandler(checkboxSelected);

            return picPanel;
        }
        //private 
        private void displayWords(List<Word> words, int months)
        {
            il = new ImageList();
            il.ImageSize = new Size(130, 130);
            int n = 1;
            foreach(Word w in words)
            {
                //flp.Controls.Add(createCheckBox(w, n++));
                flp.Controls.Add(createPicPanel(w));
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

        private void button1_Click(object sender, EventArgs e)
        {
            Results dlg = new Results(words, months);
            dlg.ShowDialog(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
