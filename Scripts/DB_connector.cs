using MySqlConnector;

namespace sql_web_app.Scripts;

public static class DB_connector
{
    private static readonly String _host = "localhost";
    private static readonly String _datebase = "Cloud_storage";
    private static readonly String _port = "3306";
    private static readonly String _username = "user1";
    private static readonly String _password = "password";

    private static MySqlConnection? Connection;

    public static void DB_connect()
    {
        String connString = 
            "Server=" + _host + 
            ";Database=" + _datebase + 
            ";port=" + _port + 
            ";User Id=" + _username + 
            ";password=" + _password;
        Connection = new MySqlConnection(connString);  
    }

    public static MySqlConnection? GetConnection() => Connection;

    // public static MySqlDataReader? MySqlExecute(string message)
    // {
    //     try
    //     {
    //         var command = new MySqlCommand(message, Connection);

    //         Connection?.Open();
    //         using var reader = command.ExecuteReader();
    //         Connection?.Close();

    //         return reader;
    //     }
    //     catch(Exception e)
    //     {
    //         Console.WriteLine("Error: " + e.Message);
    //         return null;
    //     }

    // }
}