namespace _05._Change_Town_Names_Casing
{
    using System.Data.SqlClient;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();

            using SqlConnection sqlConnection = new SqlConnection(ConfigureConnection.Config.connectionString);
            sqlConnection.Open();

            int rowsAffected = UpdateTownsToUppercase(sqlConnection, country);

            if (rowsAffected <= 0)
            {
                Console.WriteLine("No town names were affected.");
                Environment.Exit(0);
            }

            Console.WriteLine($"{rowsAffected} town names were affected.");

            var townNames = FindTownsNames(sqlConnection, country);

            Console.WriteLine($"[{string.Join(", ", townNames)}]");

            sqlConnection.Close();
        }

        private static HashSet<string> FindTownsNames(SqlConnection sqlConnection, string countryName)
        {
            HashSet<string> towns = new HashSet<string>();

            string countryQuery = @"SELECT t.Name 
                                      FROM Towns as t
                                      JOIN Countries AS c ON c.Id = t.CountryCode
                                     WHERE c.Name = @CountryName";
            SqlCommand findTownsCmd = new SqlCommand(countryQuery, sqlConnection);
            findTownsCmd.Parameters.AddWithValue("@CountryName", countryName);

            using SqlDataReader townsReader = findTownsCmd.ExecuteReader();

            while (townsReader.Read())
            {
                string town = (string)townsReader[0];
                towns.Add(town);
            }

            return towns;
        }

        private static int UpdateTownsToUppercase(SqlConnection sqlConnection, string countryName)
        {
            string updateNamesQuery = @"UPDATE Towns
                                           SET Name = UPPER(Name)
                                         WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @CountryName)";
            SqlCommand updateNamesCmd = new SqlCommand(updateNamesQuery, sqlConnection);
            updateNamesCmd.Parameters.AddWithValue("@CountryName", countryName);

            return updateNamesCmd.ExecuteNonQuery();
        }
    }
}