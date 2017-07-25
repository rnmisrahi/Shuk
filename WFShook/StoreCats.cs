using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGauges.Win.Gauges.Circular;

namespace WFShook
{
    public partial class StoreCats : Form
    {
        int pointer = 0;
        int maxPointer = 0;

        public StoreCats()
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

        private PictureBox createPictureBox()
        {
            PictureBox pb = new PictureBox();
            pb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pb.Dock = System.Windows.Forms.DockStyle.Fill;
            pb.Image = Image.FromFile("Images\\baby.png");
            pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

            return pb;
        }

        private GroupBox createPanel()
        {
            GroupBox pnl = new GroupBox();
            pnl.Controls.Add(createSidePanel(DockStyle.Bottom, 10));
            pnl.Controls.Add(createSidePanel(DockStyle.Left, 10));
            pnl.Controls.Add(createSidePanel(DockStyle.Right, 10));
            pnl.Controls.Add(createSidePanel(DockStyle.Top, 30));
            //pnl.Controls.Add(this.pnlLeft);
            //pnl.Controls.Add(this.pnlRight);
            //pnl.Controls.Add(this.pnlTop);
            //pnl.Location = new System.Drawing.Point(30, 12);
            pnl.Name = "pnl";pnl.Text = "HERE I AM SAM";
            pnl.Size = new System.Drawing.Size(188, 198);
            //pnl.TabIndex = 15;
            PictureBox p = createPictureBox();
            p.BringToFront();
            pnl.Controls.Add(p);



            return pnl;
        }

        private void useGauge()
        {
            int n = 0;
            int max = 100;
            n = gauge1.RangeBars.Count;
            arcScaleComponent1.MaxValue = 300F;
            max = (int)arcScaleComponent1.MaxValue;
            n = int.Parse(textBox1.Text);
            for (int i = 1; i <= n; i++)
            {
                gauge1.RangeBars[0].Value = i;
                System.Threading.Thread.Sleep(30);
            }
        }

        private void useGaugeTimer()
        {
            pointer = 1;
            maxPointer = int.Parse(textBox1.Text);
            timer1.Start();
        }

        private void setGauge()
        {
            gauge1.RangeBars[0].Value = pointer++;
            labelComponent2.Text = pointer.ToString();
            if (pointer >= maxPointer)
                timer1.Stop();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //useGaugeTimer();
            GroupBox p = createPanel();
            p.Location = new Point(20, 10);
            CheckBox cb = new CheckBox();
            cb.Text = "HEY";cb.Name = "NAME";
            cb.Location = new Point(200, 20);
            this.Controls.Add(cb);
            groupBox1.Controls.Add(p);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            setGauge();
        }
    }
}
