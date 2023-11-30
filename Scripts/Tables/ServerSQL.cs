using MySqlConnector;
using sql_web_app.Scripts;

namespace sql_web_app.Scripts.Tables;

public static class ServerSQL
{
    public static List<string[]> List()
    {
        List<string[]> Rows = new(); 

        var connection = DB_connector.GetConnection();

        string tmp_comm = "SELECT * FROM `Server`;";
        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            String[] row = {
                reader.GetInt32(0).ToString(),
                reader.GetString(1),
                reader.GetInt32(2).ToString(),
                reader.GetInt32(3).ToString()
            };

            Rows.Add(row);
        }

        connection?.Close(); 

        return Rows;
    }

    public static void Create(string location, int memory, int status)
    {
        var connection = DB_connector.GetConnection();

        String tmp_comm = 
            "INSERT `Server` (`Location`, `Memory`, `status`) " +
            "VALUES ('" + location + "', '" + memory + "', '" + status + "');";

        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();
        using var reader = command.ExecuteReader();
        connection?.Close(); 
    }

    public static void Update(int id, string location, int memory, int status)
    {
        var connection = DB_connector.GetConnection();

        String tmp_comm = 
            "UPDATE `Server` SET " +
            "`Location` = '" + location + "', " +
            "`Memory` = '" + memory + "', " +
            "`Status` = '" + status + "' " +
            "WHERE (`Server_id` = '" + id + "');";

        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();
        using var reader = command.ExecuteReader();
        connection?.Close(); 
    }

    public static void Delete(int id)
    {
        var connection = DB_connector.GetConnection();

        String tmp_comm = "DELETE FROM `Server` WHERE `Server_id` = '" + id + "';";

        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();
        using var reader = command.ExecuteReader();
        connection?.Close(); 
    }

    public static string[] GetParamsById(int id)
    {
        string[] atributes = new string[3];

        var connection = DB_connector.GetConnection();

        string tmp_comm = "SELECT `Location`, `Memory`, `Status` FROM `Server` WHERE `Server_id` = '" + id + "' limit 1;";
        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();

        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            atributes[0] = reader.GetString(0);
            atributes[1] = reader.GetInt32(1).ToString();
            atributes[2] = reader.GetInt32(2).ToString();
        }

        connection?.Close(); 

        return atributes;
    }
}