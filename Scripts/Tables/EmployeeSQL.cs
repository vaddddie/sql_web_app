using System.Data;
using MySqlConnector;
using sql_web_app.Scripts;

namespace sql_web_app.Scripts.Tables;

public static class EmployeeSQL
{
    public static List<string[]> List()
    {
        List<string[]> Rows = new(); 

        var connection = DB_connector.GetConnection();

        string tmp_comm = 
        "SELECT `Employee_id`, j.`Title`, `Email`, `Full_name`, `Password`, `Rate` " + 
        "FROM `Employee` AS e, `Job_title` AS j " +
        "WHERE e.`Job_title_id` = j.`Job_title_id`;";
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
                reader.GetString(4),
                reader.GetInt32(5).ToString()
            };

            Rows.Add(row);
        }

        connection?.Close(); 

        return Rows;
    }

    public static void Create(int JobTitle_id, string email, string fullname, string password, int rate)
    {
        var connection = DB_connector.GetConnection();

        String tmp_comm = 
            "INSERT `Employee` (`Job_title_id`, `Email`, `Full_name`, `Password`, `Rate`) " +
            "VALUES ('" + JobTitle_id + "', '" + email + "', '" + fullname + "', '" + password + "', '" + rate + "');";

        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();
        using var reader = command.ExecuteReader();
        connection?.Close(); 
    }

    public static void Update(int id, int JobTitle_id, string email, string fullname, string password, int rate)
    {
        var connection = DB_connector.GetConnection();

        String tmp_comm = 
            "UPDATE `Employee` SET " +
            "`Job_title_id` = '" + JobTitle_id + "', " +
            "`Email` = '" + email + "', " +
            "`Full_name` = '" + fullname + "', " +
            "`Password` = '" + password + "', " +
            "`Rate` = '" + rate + "' " +
            "WHERE (`Employee_id` = '" + id + "');";

        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();
        using var reader = command.ExecuteReader();
        connection?.Close(); 
    }

    public static void UpdateWithoutPassword(int id, int JobTitle_id, string email, string fullname, int rate)
    {
        var connection = DB_connector.GetConnection();

        String tmp_comm = 
            "UPDATE `Employee` SET " +
            "`Job_title_id` = '" + JobTitle_id + "', " +
            "`Email` = '" + email + "', " +
            "`Full_name` = '" + fullname + "', " +
            "`Rate` = '" + rate + "' " +
            "WHERE (`Employee_id` = '" + id + "');";

        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();
        using var reader = command.ExecuteReader();
        connection?.Close(); 
    }

    public static void Delete(int id)
    {
        var connection = DB_connector.GetConnection();

        String tmp_comm = "DELETE FROM `Employee` WHERE `Employee_id` = '" + id + "';";

        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();
        using var reader = command.ExecuteReader();
        connection?.Close(); 
    }

    public static string[] GetParamsById(int id)
    {
        string[] atributes = new string[4];

        var connection = DB_connector.GetConnection();

        string tmp_comm = "SELECT `Job_title_id`, `Email`, `Full_name`, `Rate` FROM `Employee` WHERE `Employee_id` = '" + id + "' limit 1;";
        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();

        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            atributes[0] = reader.GetInt32(0).ToString();
            atributes[1] = reader.GetString(1);
            atributes[2] = reader.GetString(2);
            atributes[3] = reader.GetInt32(3).ToString();
        }

        connection?.Close(); 

        return atributes;
    }

    public static Dictionary<int, string> GetJobTitles()
    {
        Dictionary<int, string> jobTitles = new();

        var connection = DB_connector.GetConnection();

        string tmp_comm = "SELECT `Job_title_id`, `Title` FROM `Job_title`;";
        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            jobTitles.Add(reader.GetInt32(0), reader.GetString(1));
        }

        connection?.Close(); 

        return jobTitles;
    }

    public static int Count()
    {
        int count = 0;

        var connection = DB_connector.GetConnection();

        string tmp_comm = "SELECT COUNT(*) AS `count` FROM `Employee`;";
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