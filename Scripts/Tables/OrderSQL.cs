using MySqlConnector;
using sql_web_app.Scripts;

namespace sql_web_app.Scripts.Tables;

public static class OrderSQL
{
    public static List<string[]> List()
    {
        List<string[]> Rows = new(); 

        var connection = DB_connector.GetConnection();

        string tmp_comm = 
        "SELECT `Order_id`, `Email`, `Storage_memory`, `Price_at_month`, `Datetime` " + 
        "FROM `Order` AS o, `Client` AS c, `Tariff` AS t " +
        "WHERE o.`Client_id` = c.`Client_id` and o.`Tariff_id` = t.`Tariff_id`;";
        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            String[] row = {
                reader.GetInt32(0).ToString(),
                reader.GetString(1),
                reader.GetInt32(2).ToString(),
                reader.GetFloat(3).ToString(),
                reader.GetDateTime(4).ToString()
            };

            Rows.Add(row);
        }

        connection?.Close(); 

        return Rows;
    }

    public static void Create(int client_id, int tariff_id, string dateTime)
    {
        var connection = DB_connector.GetConnection();

        String tmp_comm = 
            "INSERT `Order` (`Client_id`, `Tariff_id`, `Datetime`) " +
            "VALUES ('" + client_id + "', '" + tariff_id + "', '" + dateTime + "');";

        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();
        using var reader = command.ExecuteReader();
        connection?.Close(); 
    }

    public static void Update(int id, int client_id, int tariff_id, string dateTime)
    {
        var connection = DB_connector.GetConnection();

        String tmp_comm = 
            "UPDATE `Order` SET " +
            "`Client_id` = '" + client_id + "', " +
            "`Tariff_id` = '" + tariff_id + "', " +
            "`Datetime` = '" + dateTime + "' " +
            "WHERE (`Order_id` = '" + id + "');";

        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();
        using var reader = command.ExecuteReader();
        connection?.Close(); 
    }

    public static void Delete(int id)
    {
        var connection = DB_connector.GetConnection();

        String tmp_comm = "DELETE FROM `Order` WHERE `Order_id` = '" + id + "';";

        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();
        using var reader = command.ExecuteReader();
        connection?.Close(); 
    }

    public static string[] GetParamsById(int id)
    {
        string[] atributes = new string[3];

        var connection = DB_connector.GetConnection();

        string tmp_comm = "SELECT Client_id, Tariff_id, Datetime FROM `Order` WHERE Order_id = " + id + " limit 1;";
        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();

        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            atributes[0] = reader.GetInt32(0).ToString();
            atributes[1] = reader.GetInt32(1).ToString();
            atributes[2] = reader.GetDateTime(2).ToString("yyyy-MM-ddTHH:mm");
        }

        connection?.Close(); 

        return atributes;
    }

    public static Dictionary<int, string> GetClients()
    {
        Dictionary<int, string> clients = new();

        var connection = DB_connector.GetConnection();

        string tmp_comm = "SELECT Client_id, Email FROM Client;";
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

    public static Dictionary<int, string> GetTariffs()
    {
        Dictionary<int, string> tariffs = new();

        var connection = DB_connector.GetConnection();

        string tmp_comm = "SELECT * FROM Tariff;";
        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            string tmp = reader.GetInt32(1).ToString() + " Гб: " + reader.GetFloat(2).ToString() + " $";
            tariffs.Add(reader.GetInt32(0), tmp);
        }

        connection?.Close(); 

        return tariffs;
    }

    public static int Count()
    {
        int count = 0;

        var connection = DB_connector.GetConnection();

        string tmp_comm = "SELECT COUNT(*) AS `count` FROM `Order`;";
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