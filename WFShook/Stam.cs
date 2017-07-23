using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFShook
{
    public partial class Stam : Form
    {
        const string CONNECTION_STRING = "Server=(localdb)\\mssqllocaldb;Database=TalkletWords;User ID=rnmisrahi;Password=Smcecq8a;Trusted_Connection=True;MultipleActiveResultSets=true";
        public Stam()
        {
            InitializeComponent();
        }

        private void Stam_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'talkletWordsDataSet1.Animals' table. You can move, or remove it, as needed.
            this.animalsTableAdapter.Fill(this.talkletWordsDataSet1.Animals);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            wordsInCategory("Animals");

            //IEnumerable<TalkletWordsDataSet1.AnimalsRow> animals =
            //talkletWordsDataSet1.Animals;
            //foreach(TalkletWordsDataSet1.AnimalsRow a in animals)
            //{
            //    Console.WriteLine(a.Definition);
            //}

            //IEnumerable<TalkletWordsDataSet2.WordsInCategoryDataTable> animals2 =
            //talkletWordsDataSet2.WordsInCategory

        }

        private void wordsInCategory(string category)
        {

            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                string sql = @"SELECT Word.Definition FROM dbo.Word INNER JOIN dbo.Category ON dbo.Word.CategoryId = dbo.Category.CategoryId WHERE (dbo.Category.Name = @Parameter1)";
                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    SqlParameter p1 = new SqlParameter("@Parameter1", SqlDbType.VarChar);
                    p1.Direction = ParameterDirection.Input;
                    p1.Value = category;
                    comm.Parameters.Add(p1);

                    conn.Open();
                    using (var reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                            Console.WriteLine(reader.GetString(0));
                    }

                }
            }
        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.wordsInCategoryTableAdapter.Fill(this.talkletWordsDataSet2.WordsInCategory, parameter1ToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
