using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WFShook
{
    public class PicPanel : Panel
    {
        public Word word { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public RadioButton rbYes { get; set; }
        public RadioButton rbNo { get; set; }
        public RadioButton rbMaybe { get; set; }

        public bool isYes
        {
            get
            {
                return rbYes.Checked;
            }
        }

        public bool isNo {
            get {
                return rbNo.Checked;
            }
        }

        public bool isMaybe
        {
            get
            {
                return rbMaybe.Checked;
            }
        }        

        public PicPanel(Word word, int width, int height)
        {
            this.word = word;
            this.width = width;
            this.height = height;

            GroupBox panel = createPanel();
            this.Size = new Size(width, height);
            this.Controls.Add(panel);
        }

        private Panel createSidePanel(DockStyle docStyle, int size)
        {
            Panel pnl = new Panel();
            pnl.Dock = docStyle;
            pnl.Size = new System.Drawing.Size(size, size);

            return pnl;
        }

        private PictureBox createPictureBox(string filename)
        {
            PictureBox pb = new PictureBox();
            pb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            if (File.Exists(filename))
            {
                pb.Image = Image.FromFile(filename);
                pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            }
            pb.Dock = System.Windows.Forms.DockStyle.Fill;
            pb.BringToFront();
            return pb;
        }

        private RadioButton createRadioButton(string name, string text, int tab, DockStyle dockStyle, Point point)
        {
            RadioButton rb = new RadioButton();
            rb.AutoSize = true;
            rb.Location = point;
            rb.Name = name;
            //rb.Size = new System.Drawing.Size(46, 17);
            rb.Dock = dockStyle;
            rb.TabIndex = tab;
            rb.Text = text;
            rb.UseVisualStyleBackColor = true;
            rb.Tag = word; //Because we have to react to events here

            return rb;
        }

        private GroupBox createPanel()
        {
            GroupBox pnl = new GroupBox();
            pnl.Controls.Add(createSidePanel(DockStyle.Bottom, 10));
            pnl.Controls.Add(createSidePanel(DockStyle.Left, 10));
            pnl.Controls.Add(createSidePanel(DockStyle.Right, 10));
            Panel pnlTop = createSidePanel(DockStyle.Top, 40);
            Panel pnlWord = new Panel();
            Label lblWord = new Label();
            lblWord.Text = word.Name;
            lblWord.AutoSize = false;
            lblWord.Dock = DockStyle.Bottom;
            lblWord.TextAlign = ContentAlignment.BottomCenter;
            lblWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            pnlWord.Controls.Add(lblWord);
            pnlWord.Size = new Size(10, 20);
            pnlWord.Dock = System.Windows.Forms.DockStyle.Bottom;
            pnlTop.Controls.Add(pnlWord);

            rbYes = createRadioButton("Yes", "YES", 0, DockStyle.Left, new Point(4, 5));
            rbMaybe = createRadioButton("Maybe", "?", 1, DockStyle.None, new Point(70, 5));
            rbNo = createRadioButton("No", "NO", 2, DockStyle.Right, new Point(4, 5));
            Panel pnlRadios = new Panel();
            pnlRadios.Dock = DockStyle.Top;
            pnlRadios.Size = new Size(10, 20);
            pnlTop.Controls.Add(pnlRadios);
            pnlRadios.Controls.Add(rbYes);
            pnlRadios.Controls.Add(rbNo);
            //pnlRadios.Controls.Add(rbMaybe);
            pnlRadios.BringToFront();
            pnl.Controls.Add(pnlTop);
            Panel pnlCenter = createSidePanel(DockStyle.Fill, 30);
            //pnl.Location = new System.Drawing.Point(30, 12);
            pnl.Size = new System.Drawing.Size(width, height);
            PictureBox p = createPictureBox(word.Path);
            p.BringToFront();
            pnlCenter.Controls.Add(p);
            pnl.Controls.Add(pnlCenter);
            pnlCenter.BringToFront();
            return pnl;
        }


    }
}
