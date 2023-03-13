namespace _03._Minion_Names
{
    using System.Data.SqlClient;
    using System.Text;

    public class StartUp
    {
        static StringBuilder sb = new StringBuilder();

        static void Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine());
            using SqlConnection sqlConnection = new SqlConnection(ConfigureConnection.Config.connectionString);
            sqlConnection.Open();

            GetVillainById(sqlConnection, villainId);

            Console.WriteLine(GetMinionsForVillain(sqlConnection, villainId));

            sqlConnection.Close();
        }

        private static string GetVillainById(SqlConnection sqlConnection, int villainId)
        {
            string villianNameQuery = @"SELECT Name 
                                          FROM Villains 
                                         WHERE Id = @VillainId";

            SqlCommand getVillainNameCmd = new SqlCommand(villianNameQuery, sqlConnection);
            getVillainNameCmd.Parameters.AddWithValue("@VillainId", villainId);

            string villainName = (string)getVillainNameCmd.ExecuteScalar();
            if (villainName == null)
            {
                Console.WriteLine($"No villain with ID {villainId} exists in the database.");
                Environment.Exit(0);
            }

            return sb.AppendLine($"Villain: {villainName}").ToString().TrimEnd();
        }

        private static string GetMinionsForVillain(SqlConnection sqlConnection, int villainId)
        {
            string minionsQuery = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                           m.Name, 
                                           m.Age
                                      FROM MinionsVillains AS mv
                                      JOIN Minions As m ON mv.MinionId = m.Id
                                     WHERE mv.VillainId = @VillainId
                                  ORDER BY m.Name";

            SqlCommand minionsCmd = new SqlCommand(minionsQuery, sqlConnection);
            minionsCmd.Parameters.AddWithValue("@VillainId", villainId);

            using SqlDataReader minionReader = minionsCmd.ExecuteReader();

            if (!minionReader.HasRows)
            {
                return sb.AppendLine($"(no minions)").ToString().TrimEnd();
            }
            else
            {
                while (minionReader.Read())
                {
                    sb.AppendLine($"{minionReader["RowNum"]}. {minionReader["Name"]} {minionReader["Age"]}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}