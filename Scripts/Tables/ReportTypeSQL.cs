using System.Data;
using System.Data.SqlTypes;
using MySqlConnector;
using sql_web_app.Scripts;

namespace sql_web_app.Scripts.Tables;

public static class ReportTypeSQL
{
    public static List<string[]> List()
    {
        List<string[]> Rows = new(); 

        var connection = DB_connector.GetConnection();

        string tmp_comm = "SELECT * FROM `Report_type`;";
        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            String[] row = {
                reader.GetInt32(0).ToString(),
                reader.GetString(1)
            };

            Rows.Add(row);
        }

        connection?.Close(); 

        return Rows;
    }

    public static void Create(string title)
    {
        var connection = DB_connector.GetConnection();

        String tmp_comm = 
            "INSERT `Report_type` (`Title`) " +
            "VALUES ('" + title + "');";

        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();
        using var reader = command.ExecuteReader();
        connection?.Close(); 
    }

    public static void Update(int id, string title)
    {
        var connection = DB_connector.GetConnection();

        String tmp_comm = 
            "UPDATE `Report_type` SET " +
            "`Title` = '" + title + "' " +
            "WHERE (`Report_type_id` = '" + id + "');";

        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();
        using var reader = command.ExecuteReader();
        connection?.Close(); 
    }

    public static void Delete(int id)
    {
        var connection = DB_connector.GetConnection();

        String tmp_comm = "DELETE FROM `Report_type` WHERE `Report_type_id` = '" + id + "';";

        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();
        using var reader = command.ExecuteReader();
        connection?.Close(); 
    }

    public static string[] GetParamsById(int id)
    {
        string[] atributes = new string[1];

        var connection = DB_connector.GetConnection();

        string tmp_comm = "SELECT `Title` FROM `Report_type` WHERE `Report_type_id` = '" + id + "' limit 1;";
        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();

        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            atributes[0] = reader.GetString(0);
        }

        connection?.Close(); 

        return atributes;
    }
}