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
        private static string sql = "SELECT DISTINCT Word.Definition, WordData.Percentile FROM dbo.Word " +
                             "INNER JOIN dbo.Category ON dbo.Word.CategoryId = dbo.Category.CategoryId " +
                             "INNER JOIN dbo.WordData ON Word.WordId = dbo.WordData.WordId " +
                             "WHERE (dbo.Category.Name = @Category) " +
                             "AND(WordData.Months = @Months)";
        
        public static List<string> GetWordsInCategory(int months, string category)
        {
            List<string> wordList = new List<string>();
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                using (SqlCommand comm = new SqlCommand(sql, conn))
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
                            wordList.Add(reader.GetString(0));
                    }

                }
            }
            return wordList;

        }

    }
}
