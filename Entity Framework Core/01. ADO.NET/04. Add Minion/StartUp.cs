namespace _04._Add_Minion
{
    using System.Data.SqlClient;
    using System.Text;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] minionInfo = Console.ReadLine()
                .Split(": ", StringSplitOptions.RemoveEmptyEntries)[1]
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string villainName = Console.ReadLine()
                .Split(": ", StringSplitOptions.RemoveEmptyEntries)[1];
            StringBuilder sb = new StringBuilder();

            using SqlConnection sqlConnection = new SqlConnection(ConfigureConnection.Config.connectionString);
            sqlConnection.Open();

            Console.WriteLine(AddNewMinion(sqlConnection, sb, minionInfo, villainName));

            sqlConnection.Close();
        }

        private static string AddNewMinion(SqlConnection sqlConnection, StringBuilder sb, string[] minionInfo, string villainName)
        {
            string minionName = minionInfo[0];
            int minionAge = int.Parse(minionInfo[1]);
            string minionTown = minionInfo[2];

            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

            try
            {
                int townId = GetTownId(sqlConnection, sqlTransaction, sb, minionTown);
                int villainId = GetVillainId(sqlConnection, sqlTransaction, sb, villainName);
                int minionId = AddMinionAndGetId(sqlConnection, sqlTransaction, minionName, minionAge, townId);

                string addMinionToVillainQuery = @"INSERT INTO MinionsVillains (MinionId, VillainId) 
                                                        VALUES (@MinionId, @VillainId)";
                SqlCommand addMinionToVillainCmd = new SqlCommand(addMinionToVillainQuery, sqlConnection, sqlTransaction);
                addMinionToVillainCmd.Parameters.AddWithValue("@MinionId", minionId);
                addMinionToVillainCmd.Parameters.AddWithValue("@VillainId", villainId);

                addMinionToVillainCmd.ExecuteNonQuery();
                sb.AppendLine($"Successfully added {minionName} to be minion of {villainName}.");

                sqlTransaction.Commit();
            }
            catch (Exception e)
            {
                sqlTransaction.Rollback();
                return e.ToString();
            }

            return sb.ToString().TrimEnd();
        }

        private static int GetTownId(SqlConnection sqlConnection, SqlTransaction sqlTransaction, StringBuilder sb, string minionTown)
        {
            string townIdQuery = @"SELECT Id 
                                     FROM Towns 
                                    WHERE Name = @TownName";
            SqlCommand townIdCmd = new SqlCommand(townIdQuery, sqlConnection, sqlTransaction);
            townIdCmd.Parameters.AddWithValue("@TownName", minionTown);

            object townIdObj = townIdCmd.ExecuteScalar();

            if (townIdObj == null)
            {
                string addTownQuery = @"INSERT INTO Towns (Name) 
                                             VALUES (@TownName)";
                SqlCommand addTownCmd = new SqlCommand(addTownQuery, sqlConnection, sqlTransaction);
                addTownCmd.Parameters.AddWithValue("@TownName", minionTown);

                addTownCmd.ExecuteNonQuery();
                sb.AppendLine($"Town {minionTown} was added to the database.");

                townIdObj = townIdCmd.ExecuteScalar();
            }

            return (int)townIdObj;
        }

        private static int GetVillainId(SqlConnection sqlConnection, SqlTransaction sqlTransaction,
            StringBuilder sb, string villainName)
        {
            string villainIdQuery = @"SELECT Id 
                                        FROM Villains 
                                       WHERE Name = @VillainName";
            SqlCommand villainIdCmd = new SqlCommand(villainIdQuery, sqlConnection, sqlTransaction);
            villainIdCmd.Parameters.AddWithValue("@VillainName", villainName);

            object villainIdObj = villainIdCmd.ExecuteScalar();

            if (villainIdObj == null)
            {
                string evilnessFactorQuery = @"SELECT Id
                                                 FROM EvilnessFactors
                                                WHERE Name = 'Evil'";
                SqlCommand evilnessFactorCmd = new SqlCommand(evilnessFactorQuery, sqlConnection, sqlTransaction);
                int evilnessFactorId = (int)evilnessFactorCmd.ExecuteScalar();

                string insertVillainQuery = @"INSERT INTO Villains (Name, EvilnessFactorId)  
                                                   VALUES (@VillainName, @EvilnessFactorId)";
                SqlCommand insertVillainCmd = new SqlCommand(insertVillainQuery, sqlConnection, sqlTransaction);
                insertVillainCmd.Parameters.AddWithValue("@VillainName", villainName);
                insertVillainCmd.Parameters.AddWithValue("@EvilnessFactorId", evilnessFactorId);

                insertVillainCmd.ExecuteNonQuery();
                sb.AppendLine($"Villain {villainName} was added to the database.");

                villainIdObj = villainIdCmd.ExecuteScalar();
            }

            return (int)villainIdObj;
        }

        private static int AddMinionAndGetId(SqlConnection sqlConnection, SqlTransaction sqlTransaction,
            string minionName, int minionAge, int minionTownId)
        {
            string addMinionQuery = @"INSERT INTO Minions (Name, Age, TownId) 
                                           VALUES (@MinionName, @MinionAge, @TownId)";
            SqlCommand addMinionCmd = new SqlCommand(addMinionQuery, sqlConnection, sqlTransaction);
            addMinionCmd.Parameters.AddWithValue("@MinionName", minionName);
            addMinionCmd.Parameters.AddWithValue("@MinionAge", minionAge);
            addMinionCmd.Parameters.AddWithValue("@TownId", minionTownId);

            addMinionCmd.ExecuteNonQuery();

            string addedMinionIdQuery = @"SELECT Id
                                            FROM Minions
                                           WHERE Name = @MinionName AND Age = @MinionAge AND TownId = @TownId";
            SqlCommand getMinionIdCmd = new SqlCommand(addedMinionIdQuery, sqlConnection, sqlTransaction);
            getMinionIdCmd.Parameters.AddWithValue("@MinionName", minionName);
            getMinionIdCmd.Parameters.AddWithValue("@MinionAge", minionAge);
            getMinionIdCmd.Parameters.AddWithValue("@TownId", minionTownId);

            int minionId = (int)getMinionIdCmd.ExecuteScalar();

            return minionId;
        }
    }
}