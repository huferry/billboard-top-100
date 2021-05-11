using System;

namespace billboard_server
{
    public interface ISettings
    {
        string DbConnectionString { get; }
    }

    public class Settings : ISettings
    {
        private static string GetEnvVar(
            string key, 
            string defaultValue = null)
        {
            return Environment.GetEnvironmentVariable(key) ?? defaultValue;
        }
        
        public static readonly ISettings Instance = new Settings();

        public string DbConnectionString => GetEnvVar("DB_CONNECTION_STRING", "host=localhost;port=5432;database=billboard;username=user;password=password");
    }
}