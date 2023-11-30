using DevOne.Security.Cryptography.BCrypt;

namespace sql_web_app.Scripts;

public static class HashClass
{
    public static string Hash(string password)
    {
        var salt = BCryptHelper.GenerateSalt();
        var hash = BCryptHelper.HashPassword(password, salt);
        return hash;
    }

    public static bool Check(string password, string hPassword)
    {
        return BCryptHelper.CheckPassword(password, hPassword);
    }
}