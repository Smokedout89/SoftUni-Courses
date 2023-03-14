namespace _09._Increase_Age_Stored_Procedure
{
    using System.Data.SqlClient;
    using System.Text;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int minionId = int.Parse(Console.ReadLine());

            SqlConnection sqlConnection = new SqlConnection(ConfigureConnection.Config.connectionString);
            sqlConnection.Open();

            Console.WriteLine(IncreaseMinionAge(sqlConnection, minionId));

            sqlConnection.Close();
        }

        private static string IncreaseMinionAge(SqlConnection sqlConnection, int minionId)
        {
            StringBuilder sb = new StringBuilder();

            string increaseAgeQuery = @"EXEC dbo.usp_GetOlder @MinionId";
            SqlCommand increaseAgeCmd = new SqlCommand(increaseAgeQuery, sqlConnection);
            increaseAgeCmd.Parameters.AddWithValue("@MinionId", minionId);

            increaseAgeCmd.ExecuteNonQuery();

            string minionInfoQuery = @"SELECT Name, Age 
                                         FROM Minions 
                                        WHERE Id = @MinionId";
            SqlCommand minionInfoCmd = new SqlCommand(minionInfoQuery, sqlConnection);
            minionInfoCmd.Parameters.AddWithValue("@MinionId", minionId);

            using SqlDataReader infoReader = minionInfoCmd.ExecuteReader();

            while (infoReader.Read())
            {
                sb.AppendLine($"{infoReader["Name"]} - {infoReader["Age"]} years old");
            }

            return sb.ToString().TrimEnd();
        }
    }
}