using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFShook
{
    public partial class Form1 : Form
    {
        private GroupBox myPanel;

        public Form1()
        {
            InitializeComponent();
        }

        private Panel createSidePanel(DockStyle docStyle, int size)
        {
            Panel pnl = new Panel();
            pnl.Dock = docStyle;// System.Windows.Forms.DockStyle.Bottom;
            //pnl.Location = new System.Drawing.Point(10, 188);
            //pnl.Name = "pnlBottom";
            pnl.Size = new System.Drawing.Size(size, size);
            //pnl.TabIndex = 3;

            return pnl;
        }

        private PictureBox createPictureBox(string filename)
        {
            PictureBox pb = new PictureBox();
            pb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pb.Image = Image.FromFile(filename);
            pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pb.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.pb.TabIndex = 4;
            //this.pb.TabStop = false;
            pb.BringToFront();
            return pb;
        }

        private RadioButton createRadioButton(string name, string text, int tab, DockStyle dockStyle, Point point)
        {
            RadioButton rb = new RadioButton();
            rb.AutoSize = true;
            rb.Location = point;
            rb.Name = name;
            rb.Dock = dockStyle;
            rb.TabIndex = tab;
            rb.Text = text;
            rb.UseVisualStyleBackColor = true;

            return rb;
        }

        private GroupBox createPanel()
        {
            GroupBox pnl = new GroupBox();
            pnl.Controls.Add(createSidePanel(DockStyle.Bottom, 10));
            pnl.Controls.Add(createSidePanel(DockStyle.Left, 10));
            pnl.Controls.Add(createSidePanel(DockStyle.Right, 10));
            Panel top = createSidePanel(DockStyle.Top, 30);
            top.Name = "Top";
            RadioButton rbYes = createRadioButton("Yes", "YES", 0, DockStyle.Left, new System.Drawing.Point(4, 7));
            RadioButton rbMaybe = createRadioButton("Maybe", "?", 1, DockStyle.None, new System.Drawing.Point(70, 7));
            RadioButton rbNo = createRadioButton("No", "NO", 2, DockStyle.Right, new System.Drawing.Point(4, 7));
            top.Controls.Add(rbYes);
            top.Controls.Add(rbNo);
            top.Controls.Add(rbMaybe);
            pnl.Controls.Add(top);
            Panel pnlCenter = createSidePanel(DockStyle.Fill, 30);
            pnl.Size = new System.Drawing.Size(200, 200);
            PictureBox p = createPictureBox("Images\\baby.png");
            p.BringToFront();
            pnlCenter.Controls.Add(p);
            pnl.Controls.Add(pnlCenter);
            pnlCenter.BringToFront();
            return pnl;
        }

        private int selected()
        {
            RadioButton rbYes = (RadioButton)myPanel.Controls["Top"].Controls["Yes"];
            RadioButton rbNo = (RadioButton)myPanel.Controls["Top"].Controls["No"];
            RadioButton rbMaybe = (RadioButton)myPanel.Controls["Top"].Controls["Maybe"];

            return 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myPanel = createPanel();
            myPanel.Location = new Point(20, 10);
            this.Controls.Add(myPanel);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            selected();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Word w = new Word { Definition = "bed" };
            PicPanel pnl = new PicPanel(w, 140, 140);
            flp.Controls.Add(pnl);
        }
    }
}
