using Microsoft.Extensions.Configuration;


namespace PlayWrightAPI.Utilities
{
        public static class Settings
        {
            private static readonly IConfiguration Config;

            static Settings()
            {
                Config = new ConfigurationBuilder().AddJsonFile
                ("appsettings.json", true, true)
                .Build();
            }

            public static string API_TOKEN => Config["API_TOKEN"];

            public static string REPO => Config["REPO"];

            public static string USER => Config["USER"];
            public static string URL => Config["URL"];
            public static string COMMITDATE => Config["COMMITDATE"];

            public static string ENDUSERSHAKEY => Config["ENDUSERSHAKEY"];




        }
}
