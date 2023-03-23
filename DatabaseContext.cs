using System.Data;
using System.Data.SQLite;

namespace DecisionSupportSystem
{
    public class DatabaseContext
    {
        /// <summary>
        /// путь к базе данных
        /// </summary>
        private const string path = "C:\\Users\\nidro\\OneDrive\\Документы\\DecisionSupportSystemDB.db";


        /// <summary>
        /// выполнить запрос
        /// </summary>
        /// <param name="query">запрос</param>
        /// <returns>набор данных</returns>
        public static DataSet ExecuteQuery(string query)
        {
            string connectionString = "Data Source=" + path + ";Version=3;New=True;Comress=True";
            SQLiteConnection connection = new SQLiteConnection(connectionString);

            DataSet ds = new DataSet();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);
            adapter.Fill(ds);

            connection.Close();
            return ds;
        }
    }
}
