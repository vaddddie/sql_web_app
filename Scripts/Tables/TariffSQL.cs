using System.Data;
using System.Data.SqlTypes;
using MySqlConnector;
using sql_web_app.Scripts;

namespace sql_web_app.Scripts.Tables;

public static class TariffSQL
{
    public static List<string[]> List()
    {
        List<string[]> Rows = new(); 

        var connection = DB_connector.GetConnection();

        string tmp_comm = "SELECT * FROM Tariff;";
        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            String[] row = {
                reader.GetInt32(0).ToString(),
                reader.GetInt32(1).ToString(),
                reader.GetFloat(2).ToString()
            };

            Rows.Add(row);
        }

        connection?.Close(); 

        return Rows;
    }

    public static void Create(int memory, string price)
    {
        var connection = DB_connector.GetConnection();

        String tmp_comm = 
            "INSERT `Tariff` (`Storage_memory`, `Price_at_month`) " +
            "VALUES ('" + memory + "', '" + price + "');";

        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();
        using var reader = command.ExecuteReader();
        connection?.Close(); 
    }

    public static void Update(int id, int memory, string price)
    {
        var connection = DB_connector.GetConnection();

        String tmp_comm = 
            "UPDATE `Tariff` SET " +
            "`Storage_memory` = '" + memory + "', " +
            "`Price_at_month` = '" + price + "' " +
            "WHERE (`Tariff_id` = '" + id + "');";

        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();
        using var reader = command.ExecuteReader();
        connection?.Close(); 
    }

    public static void Delete(int id)
    {
        var connection = DB_connector.GetConnection();

        String tmp_comm = "DELETE FROM `Tariff` WHERE `Tariff_id` = '" + id + "';";

        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();
        using var reader = command.ExecuteReader();
        connection?.Close(); 
    }

    public static string[] GetParamsById(int id)
    {
        string[] atributes = new string[2];

        var connection = DB_connector.GetConnection();

        string tmp_comm = "SELECT `Storage_memory`, `Price_at_month` FROM `Tariff` WHERE `Tariff_id` = '" + id + "' limit 1;";
        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();

        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            atributes[0] = reader.GetInt32(0).ToString();
            atributes[1] = reader.GetFloat(1).ToString();
        }

        connection?.Close(); 

        return atributes;
    }
}