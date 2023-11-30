using MySqlConnector;
using sql_web_app.Scripts;

namespace sql_web_app.Scripts.Tables;

public static class StorageSQL
{
    public static List<string[]> List()
    {
        List<string[]> Rows = new(); 

        var connection = DB_connector.GetConnection();

        string tmp_comm = 
        "SELECT `Storage_id`, `Email`, st.`Memory`, se.`Location`, `End_datetime` " + 
        "FROM `Storage` AS st, `Client` AS c, `Server` AS se " +
        "WHERE st.`Client_id` = c.`Client_id` and st.`Server_id` = se.`Server_id`;";
        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            String[] row = {
                reader.GetInt32(0).ToString(),
                reader.GetString(1),
                reader.GetInt32(2).ToString(),
                reader.GetString(3),
                reader.GetDateTime(4).ToString()
            };

            Rows.Add(row);
        }

        connection?.Close(); 

        return Rows;
    }

    public static void Create(int client_id, int memory, int server_id, string dateTime)
    {
        var connection = DB_connector.GetConnection();

        String tmp_comm = 
            "INSERT `Storage` (`Server_id`, `Client_id`, `Memory`, `End_datetime`) " +
            "VALUES ('" + server_id + "', '" + client_id + "', '" + memory + "', '" + dateTime + "');";

        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();
        using var reader = command.ExecuteReader();
        connection?.Close(); 
    }

    public static void Update(int id, int client_id, int memory, int server_id, string dateTime)
    {
        var connection = DB_connector.GetConnection();

        String tmp_comm = 
            "UPDATE `Storage` SET " +
            "`Server_id` = '" + server_id + "', " +
            "`Client_id` = '" + client_id + "', " +
            "`Memory` = '" + memory + "', " +
            "`End_datetime` = '" + dateTime + "' " +
            "WHERE (`Storage_id` = '" + id + "');";

        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();
        using var reader = command.ExecuteReader();
        connection?.Close(); 
    }

    public static void Delete(int id)
    {
        var connection = DB_connector.GetConnection();

        String tmp_comm = "DELETE FROM `Storage` WHERE `Storage_id` = '" + id + "';";

        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();
        using var reader = command.ExecuteReader();
        connection?.Close(); 
    }

    public static string[] GetParamsById(int id)
    {
        string[] atributes = new string[4];

        var connection = DB_connector.GetConnection();

        string tmp_comm = "SELECT `Client_id`, `Memory`, `Server_id`, `End_datetime` FROM `Storage` WHERE `Storage_id` = '" + id + "' limit 1;";
        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();

        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            atributes[0] = reader.GetInt32(0).ToString();
            atributes[1] = reader.GetInt32(1).ToString();
            atributes[2] = reader.GetInt32(2).ToString();
            atributes[3] = reader.GetDateTime(3).ToString("yyyy-MM-ddTHH:mm");
        }

        connection?.Close(); 

        return atributes;
    }

    public static Dictionary<int, string> GetClients()
    {
        Dictionary<int, string> clients = new();

        var connection = DB_connector.GetConnection();

        string tmp_comm = "SELECT `Client_id`, `Email` FROM `Client`;";
        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            clients.Add(reader.GetInt32(0), reader.GetString(1));
        }

        connection?.Close(); 

        return clients;
    }

    public static Dictionary<int, string> GetLocations()
    {
        Dictionary<int, string> locations = new();

        var connection = DB_connector.GetConnection();

        string tmp_comm = "SELECT `Server_id`, `Location` FROM `Server`;";
        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            locations.Add(reader.GetInt32(0), reader.GetString(1));
        }

        connection?.Close(); 

        return locations;
    }
}