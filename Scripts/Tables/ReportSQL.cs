using System.Data;
using MySqlConnector;
using sql_web_app.Scripts;

namespace sql_web_app.Scripts.Tables;

public static class ReportSQL
{
    public static List<string[]> List()
    {
        List<string[]> Rows = new(); 

        var connection = DB_connector.GetConnection();

        string tmp_comm = 
        "SELECT `Report_id`, c.`Email`, rt.`Title`, e.`Email`, `Status` " + 
        "FROM `Report` AS r, `Client` AS c, `Report_type` AS rt, `Employee` AS e " +
        "WHERE r.`Client_id` = c.`Client_id` " +
        "AND r.`Report_type_id` = rt.`Report_type_id` " +
        "AND r.`Employee_id` = e.`Employee_id`;";
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
                reader.GetInt32(4).ToString()
            };

            Rows.Add(row);
        }

        connection?.Close(); 

        return Rows;
    }

    public static void Create(int client_id, int reportType_id, int employee_id, int status)
    {
        var connection = DB_connector.GetConnection();

        String tmp_comm = 
            "INSERT `Report` (`Client_id`, `Report_type_id`, `Employee_id`, `Status`) " +
            "VALUES ('" + client_id + "', '" + reportType_id + "', '" + employee_id + "', '" + status + "');";

        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();
        using var reader = command.ExecuteReader();
        connection?.Close(); 
    }

    public static void Update(int id, int client_id, int reportType_id, int employee_id, int status)
    {
        var connection = DB_connector.GetConnection();

        String tmp_comm = 
            "UPDATE `Report` SET " +
            "`Client_id` = '" + client_id + "', " +
            "`Report_type_id` = '" + reportType_id + "', " +
            "`Employee_id` = '" + employee_id + "', " +
            "`Status` = '" + status + "' " +
            "WHERE (`Report_id` = '" + id + "');";

        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();
        using var reader = command.ExecuteReader();
        connection?.Close(); 
    }

    public static void Delete(int id)
    {
        var connection = DB_connector.GetConnection();

        String tmp_comm = "DELETE FROM `Report` WHERE `Report_id` = '" + id + "';";

        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();
        using var reader = command.ExecuteReader();
        connection?.Close(); 
    }

    public static string[] GetParamsById(int id)
    {
        string[] atributes = new string[4];

        var connection = DB_connector.GetConnection();

        string tmp_comm = "SELECT `Client_id`, `Report_type_id`, `Employee_id`, `Status` FROM `Report` WHERE `Report_id` = " + id + " limit 1;";
        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();

        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            atributes[0] = reader.GetInt32(0).ToString();
            atributes[1] = reader.GetInt32(1).ToString();
            atributes[2] = reader.GetInt32(2).ToString();
            atributes[3] = reader.GetInt32(3).ToString();
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

    public static Dictionary<int, string> GetReportTypes()
    {
        Dictionary<int, string> clients = new();

        var connection = DB_connector.GetConnection();

        string tmp_comm = "SELECT `Report_type_id`, `Title` FROM `Report_type`;";
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

    public static Dictionary<int, string> GetEmployees()
    {
        Dictionary<int, string> employees = new();

        var connection = DB_connector.GetConnection();

        string tmp_comm = "SELECT `Employee_id`, `Email` FROM `Employee`;";
        var command = new MySqlCommand(tmp_comm, connection);

        connection?.Open();

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            employees.Add(reader.GetInt32(0), reader.GetString(1));
        }

        connection?.Close(); 

        return employees;
    }
}