namespace _07._Print_All_Minion_Names
{
    using System.Data.SqlClient;

    public class StartUp
    {
        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConfigureConnection.Config.connectionString);
            sqlConnection.Open();

            var minions = GetAllMinions(sqlConnection);

            if (minions.Count > 0)
            {
                for (int i = 0; i < minions.Count/2; i++)
                {
                    Console.WriteLine(minions[i]);
                    Console.WriteLine(minions[minions.Count - 1 - i]);
                }

                if (minions.Count % 2 != 0)
                {
                    Console.WriteLine(minions[minions.Count/2]);
                }
            }

            sqlConnection.Close();
        }

        private static List<string> GetAllMinions(SqlConnection sqlConnection)
        {
            var minions = new List<string>();

            string getMinionsQuery = @"SELECT Name FROM Minions";
            SqlCommand getMinionsCmd = new SqlCommand(getMinionsQuery, sqlConnection);

            using SqlDataReader minionsReader = getMinionsCmd.ExecuteReader();

            while (minionsReader.Read())
            {
                var minion = (string)minionsReader["Name"];
                minions.Add(minion.ToString());
            }

            return minions;
        }
    }
}