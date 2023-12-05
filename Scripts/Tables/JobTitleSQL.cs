using System.Data;
using System.Data.SqlTypes;
using MySqlConnector;
using sql_web_app.Scripts;

namespace sql_web_app.Scripts.Tables;

public static class JobTitleSQL
{
    public static List<string[]> List()
    {
        List<string[]> Rows = new(); 

        var connection = DB_connector.GetConnection();

        string tmp_comm = "SELECT * FROM `Job_title`;";
        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            String[] row = {
                reader.GetInt32(0).ToString(),
                reader.GetString(1),
                reader.GetInt32(2).ToString()
            };

            Rows.Add(row);
        }

        connection?.Close(); 

        return Rows;
    }

    public static void Create(string title, int accessLevel)
    {
        var connection = DB_connector.GetConnection();

        String tmp_comm = 
            "INSERT `Job_title` (`Title`, `Access_level`) " +
            "VALUES ('" + title + "', '" + accessLevel + "');";

        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();
        using var reader = command.ExecuteReader();
        connection?.Close(); 
    }

    public static void Update(int id, string title, int accessLevel)
    {
        var connection = DB_connector.GetConnection();

        String tmp_comm = 
            "UPDATE `Job_title` SET " +
            "`Title` = '" + title + "', " +
            "`Access_level` = '" + accessLevel + "' " +
            "WHERE (`Job_title_id` = '" + id + "');";

        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();
        using var reader = command.ExecuteReader();
        connection?.Close(); 
    }

    public static void Delete(int id)
    {
        var connection = DB_connector.GetConnection();

        String tmp_comm = "DELETE FROM `Job_title` WHERE `Job_title_id` = '" + id + "';";

        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();
        using var reader = command.ExecuteReader();
        connection?.Close(); 
    }

    public static string[] GetParamsById(int id)
    {
        string[] atributes = new string[2];

        var connection = DB_connector.GetConnection();

        string tmp_comm = "SELECT `Title`, `Access_level` FROM `Job_title` WHERE `Job_title_id` = '" + id + "' limit 1;";
        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();

        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            atributes[0] = reader.GetString(0);
            atributes[1] = reader.GetInt32(1).ToString();
        }

        connection?.Close(); 

        return atributes;
    }
}