using System.Data;
using MySqlConnector;
using sql_web_app.Scripts;

namespace sql_web_app.Scripts.Tables;

public static class ClientSQL
{
    public static List<string[]> List()
    {
        List<string[]> Rows = new(); 

        var connection = DB_connector.GetConnection();

        string tmp_comm = 
        "SELECT `Client_id`, `Email`, `Full_name`, `Password`, s.`Location` " + 
        "FROM `Client` AS c, `Server` AS s " +
        "WHERE c.`Location` = `Server_id`;";
        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            String[] row = {
                reader.GetInt32(0).ToString(),
                reader.GetString(1),
                reader.GetString(2),
                reader.GetString(3),
                reader.GetString(4)
            };

            Rows.Add(row);
        }

        connection?.Close(); 

        return Rows;
    }

    public static void Create(string email, string fullname, string password, int location)
    {
        var connection = DB_connector.GetConnection();

        String tmp_comm = 
            "INSERT `Client` (`Email`, `Full_name`, `Password`, `Location`) " +
            "VALUES ('" + email + "', '" + fullname + "', '" + password + "', '" + location + "');";

        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();
        using var reader = command.ExecuteReader();
        connection?.Close(); 
    }

    public static void Update(int id, string email, string fullname, string password, int location)
    {
        var connection = DB_connector.GetConnection();

        String tmp_comm = 
            "UPDATE `Client` SET " +
            "`Email` = '" + email + "', " +
            "`Full_name` = '" + fullname + "', " +
            "`Password` = '" + password + "', " +
            "`Location` = '" + location + "' " +
            "WHERE (`Client_id` = '" + id + "');";

        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();
        using var reader = command.ExecuteReader();
        connection?.Close(); 
    }

    public static void UpdateWithoutPassword(int id, string email, string fullname, int location)
    {
        var connection = DB_connector.GetConnection();

        String tmp_comm = 
            "UPDATE `Client` SET " +
            "`Email` = '" + email + "', " +
            "`Full_name` = '" + fullname + "', " +
            "`Location` = '" + location + "' " +
            "WHERE (`Client_id` = '" + id + "');";

        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();
        using var reader = command.ExecuteReader();
        connection?.Close(); 
    }

    public static void Delete(int id)
    {
        var connection = DB_connector.GetConnection();

        String tmp_comm = "DELETE FROM `Client` WHERE `Client_id` = '" + id + "';";

        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();
        using var reader = command.ExecuteReader();
        connection?.Close(); 
    }

    public static string[] GetParamsById(int id)
    {
        string[] atributes = new string[3];

        var connection = DB_connector.GetConnection();

        string tmp_comm = "SELECT `Email`, `Full_name`, `Location` FROM `Client` WHERE `Client_id` = '" + id + "' limit 1;";
        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();

        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            atributes[0] = reader.GetString(0);
            atributes[1] = reader.GetString(1);
            atributes[2] = reader.GetInt32(2).ToString();
        }

        connection?.Close(); 

        return atributes;
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

    public static int Count()
    {
        int count = 0;

        var connection = DB_connector.GetConnection();

        string tmp_comm = "SELECT COUNT(*) AS `count` FROM `Client`;";
        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();

        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            count = reader.GetInt32(0);
        }

        connection?.Close(); 

        return count;
    }
}