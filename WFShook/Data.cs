using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFShook
{
    public static class Data
    {
        public static Word BG = new Word { Definition = "BGBlue" };

        const string CONNECTION_STRING = "Server=(localdb)\\mssqllocaldb;Database=TalkletWords;User ID=rnmisrahi;Password=Smcecq8a;Trusted_Connection=True;MultipleActiveResultSets=true";
        private static string sqlWordsAndPercentilesInCategory = "SELECT DISTINCT Word.Definition, WordData.Percentile FROM dbo.Word " +
                             "INNER JOIN dbo.Category ON dbo.Word.CategoryId = dbo.Category.CategoryId " +
                             "INNER JOIN dbo.WordData ON Word.WordId = dbo.WordData.WordId " +
                             "WHERE (dbo.Category.Name = @Category) " +
                             "AND(WordData.Months = @Months)";

        private static string sqlWordsInCategory =
                            "SELECT W.Definition from Word[W] " +
                            "JOIN Category[C] ON C.CategoryId = w.CategoryId " +
                            "WHERE C.Name = @Category";

        public static List<Word> GetWordsAndPercentilesInCategory(int months, string category)
        {
            List<Word> wordList = new List<Word>();
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                using (SqlCommand comm = new SqlCommand(sqlWordsAndPercentilesInCategory, conn))
                {
                    SqlParameter p1 = new SqlParameter("@Category", SqlDbType.VarChar);
                    p1.Direction = ParameterDirection.Input;
                    p1.Value = category;
                    comm.Parameters.Add(p1);
                    SqlParameter p2 = new SqlParameter("@Months", SqlDbType.Int);
                    p2.Direction = ParameterDirection.Input;
                    p2.Value = months;
                    comm.Parameters.Add(p2);

                    conn.Open();
                    using (var reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            float p = (float)reader["Percentile"];
                            wordList.Add(new Word { Definition = reader.GetString(0), Percentile = p });
                        }
                    }

                }
            }
            return wordList;

        }

        public static List<Word> GetWordsInCategory(string category)
        {
            List<Word> wordList = new List<Word>();
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                using (SqlCommand comm = new SqlCommand(sqlWordsInCategory, conn))
                {
                    SqlParameter p1 = new SqlParameter("@Category", SqlDbType.VarChar);
                    p1.Direction = ParameterDirection.Input;
                    p1.Value = category;
                    comm.Parameters.Add(p1);

                    conn.Open();
                    using (var reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            wordList.Add(new Word { Definition = reader.GetString(0) });
                        }
                    }

                }
            }
            return wordList;

        }


    }
}
