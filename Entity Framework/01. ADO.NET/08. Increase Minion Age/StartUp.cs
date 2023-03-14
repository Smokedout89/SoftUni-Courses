namespace _08._Increase_Minion_Age
{
    using System.Data.SqlClient;
    using System.Text;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var minionId = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            using SqlConnection sqlConnection = new SqlConnection(ConfigureConnection.Config.connectionString);
            sqlConnection.Open();

            foreach (var id in minionId)
            {
                AddIdToMinionAndUpdate(sqlConnection, id);
            }

            Console.WriteLine(PrintMinions(sqlConnection));

            sqlConnection.Close();
        }

        private static string PrintMinions(SqlConnection sqlConnection)
        {
            StringBuilder sb = new StringBuilder();

            string updateQuery = @"SELECT Name, Age FROM Minions";
            SqlCommand updateCmd = new SqlCommand(updateQuery, sqlConnection);
            SqlDataReader dataReader = updateCmd.ExecuteReader();

            while (dataReader.Read())
            { 
                sb.AppendLine($"{dataReader["Name"]} {dataReader["Age"]}");
            }

            return sb.ToString().TrimEnd();
        }

        private static void AddIdToMinionAndUpdate(SqlConnection sqlConnection, int id)
        {
            string addIdQuery = @"UPDATE Minions
                                     SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                                   WHERE Id = @Id";

            SqlCommand addIdCmd = new SqlCommand(addIdQuery, sqlConnection);
            addIdCmd.Parameters.AddWithValue("@Id", id);
            addIdCmd.ExecuteNonQuery();
        }
    }
}