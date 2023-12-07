using System.Data;
using MySqlConnector;
using sql_web_app.Scripts;

namespace sql_web_app.Scripts.Tables;

public static class VirtualStorageSQL
{
    public static List<string[]> List()
    {
        List<string[]> Rows = new(); 

        var connection = DB_connector.GetConnection();

        string tmp_comm = "SELECT * FROM `Virtual_storage`;";
        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            String[] row = {
                reader.GetInt32(0).ToString(),
                reader.GetString(1),
                reader.GetString(2)
            };

            Rows.Add(row);
        }

        connection?.Close(); 

        return Rows;
    }

    public static void Update(int id, string username, string password)
    {
        var connection = DB_connector.GetConnection();

        String tmp_comm = 
            "UPDATE `Virtual_storage` SET " +
            "`FTP_user` = '" + username + "', " +
            "`FTP_password` = '" + password + "' " +
            "WHERE (`Client_id` = '" + id + "');";
        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();
        using var reader = command.ExecuteReader();
        connection?.Close(); 
    }

    public static string[] GetParamsById(int id)
    {
        string[] atributes = new string[2];

        var connection = DB_connector.GetConnection();

        string tmp_comm = "SELECT `FTP_user`, `FTP_password` FROM `Virtual_storage` WHERE `Client_id` = '" + id + "' limit 1;";
        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();

        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            atributes[0] = reader.GetString(0);
            atributes[1] = reader.GetString(1);
        }

        connection?.Close(); 

        return atributes;
    }

    public static List<string> GetUsernames()
    {
        List<string> usernames = new ();

        var connection = DB_connector.GetConnection();

        string tmp_comm = "SELECT `FTP_user` FROM `Virtual_storage`;";
        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            usernames.Add(reader.GetString(0));
        }

        connection?.Close(); 

        return usernames;
    }
}