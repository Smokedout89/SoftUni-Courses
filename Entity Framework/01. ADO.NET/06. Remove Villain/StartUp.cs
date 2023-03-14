namespace _06._Remove_Villain
{
    using System.Data.SqlClient;
    using System.Text;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine());
            using SqlConnection sqlConnection = new SqlConnection(ConfigureConnection.Config.connectionString);
            sqlConnection.Open();

            Console.WriteLine(DeleteVillain(sqlConnection, villainId));

            sqlConnection.Close();
        }

        public static string DeleteVillain(SqlConnection sqlConnection, int villainId)
        {
            StringBuilder sb = new StringBuilder();

            string villainNameQuery = @"SELECT Name 
                                          FROM Villains 
                                         WHERE Id = @VillainId";
            SqlCommand villainNameCmd = new SqlCommand(villainNameQuery, sqlConnection);
            villainNameCmd.Parameters.AddWithValue("@VillainId", villainId);

            string villainName = (string)villainNameCmd.ExecuteScalar();

            if (villainName == null)
            {
                return $"No such villain was found.";
            }

            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

            try
            {
                string releaseMinionsQuery = @"DELETE FROM MinionsVillains 
                                                     WHERE VillainId = @VillainId";
                SqlCommand releaseMinionCmd = new SqlCommand(releaseMinionsQuery, sqlConnection, sqlTransaction);
                releaseMinionCmd.Parameters.AddWithValue("@VillainId", villainId);

                int minionsReleased = releaseMinionCmd.ExecuteNonQuery();

                string deleteVillainQuery = @"DELETE FROM Villains
                                                    WHERE Id = @VillainId";
                SqlCommand deleteVillainCmd = new SqlCommand(deleteVillainQuery, sqlConnection, sqlTransaction);
                deleteVillainCmd.Parameters.AddWithValue("@VillainId", villainId);

                int villainsDeleted = deleteVillainCmd.ExecuteNonQuery();

                if (villainsDeleted != 1)
                {
                    sqlTransaction.Rollback();
                }

                sb
                    .AppendLine($"{villainName} was deleted.")
                    .AppendLine($"{minionsReleased} minions were released.");
            }
            catch (Exception e)
            {
                sqlTransaction.Rollback();
                return e.ToString();
            }

            sqlTransaction.Commit();
            return sb.ToString().TrimEnd();
        }
    }
}