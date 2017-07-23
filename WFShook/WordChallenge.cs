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
    public partial class WordChallenge : Form
    {

        public WordChallenge()
        {
            InitializeComponent();
            cbMonths.SelectedIndex = 16;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'talkletWordsDataSet.Category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter.Fill(this.talkletWordsDataSet.Category);

        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            List<Word> categories = new List<Word> {
                new Word { Definition = "animals" },
                new Word { Definition = "vehicles" },
                new Word { Definition = "toys" },
                new Word { Definition = "food_drink" },
                new Word { Definition = "clothing" },
                new Word { Definition = "body_parts" },
                new Word { Definition = "household" },
                new Word { Definition = "furniture_rooms" },
                new Word { Definition = "outside" },
                new Word { Definition = "places" },
                new Word { Definition = "people" },
                new Word { Definition = "time_words" }
            };
            Categories dlg = new Categories(categories, int.Parse(cbMonths.Text));
            dlg.ShowDialog(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stam dlg = new Stam();
            dlg.ShowDialog(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WordCategories dlg = new WordCategories();
            dlg.Show(this);
        }
    }
}
