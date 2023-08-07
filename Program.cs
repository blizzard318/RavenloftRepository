using Microsoft.Data.Sqlite;


namespace Ravenloft
{
    internal class Program
    {
        int Main(string[] args)
        {
            using (var connection = new SqliteConnection("Data Source=ravenloft.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    SELECT name
                    FROM user
                    WHERE id = $id
                ";
                command.Parameters.AddWithValue("$id", 0);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var name = reader.GetString(0);

                        Console.WriteLine($"Hello, {name}!");
                    }
                }
            }
            return 0;
        }
    }
}