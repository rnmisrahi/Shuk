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
    public partial class WordChallenge : Form
    {

        private List<Word> categories = new List<Word> {
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

        public WordChallenge()
        {
            InitializeComponent();
            cbMonths.SelectedIndex = 16;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'talkletWordsDataSet.Category' table. You can move, or remove it, as needed.
            ///this.categoryTableAdapter.Fill(this.AtalkletWordsDataSet.Category);

        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            Categories dlg = new Categories(categories, int.Parse(cbMonths.Text));
            dlg.ShowDialog(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Word> words;
            Console.WriteLine("Missing Images");
            foreach(Word category in categories)
            {
                words = Data.GetWordsInCategory(category.Definition);
                Console.WriteLine("Category: " + category.Definition);
                foreach(Word w in words)
                {
                    if (!File.Exists(w.Path))
                        Console.WriteLine(w.Definition);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new StoreCats().ShowDialog(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.ShowDialog(this);
        }
    }
}
