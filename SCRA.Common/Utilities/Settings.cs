using System;
using System.Configuration;
using SCRA.Common.Net;

namespace SCRA.Common.Utilities
{
    public static class Settings
    {
        public const string DateTimeFormat = "MM/dd/yyyy hh:mm tt";

        public static TimeSpan DbContextConnectionTimeout = TimeSpan.FromSeconds(300);

        public static string SCRAConnectionString
            => "Data Source=dev05;Initial Catalog=SCRA;User=ceperez;Password=Solracp4321;MultipleActiveResultSets=True";//ConfigurationManager.ConnectionStrings["SCRAConnection"].ConnectionString;

        public static int SessionExpiration
            => Int32.Parse(ConfigurationManager.AppSettings["session-expiration"]);

        public static int WidgetCacheExpiration
            => Int32.Parse(ConfigurationManager.AppSettings["widget-cache-expiration"]) * 60 * 1000;

        public static string MASTER_PASSWORD
        {
            get { return ConfigurationManager.AppSettings["master-password"]; }
        }

        public static string DirectoryDomain
        {
            get { return ConfigurationManager.AppSettings["directory-domain"]; }
        }

        public static string DirectoryUrl
        {
            get { return ConfigurationManager.AppSettings["directory-url"]; }
        }

        public static string DirectoryContainer
        {
            get { return ConfigurationManager.AppSettings["directory-container"]; }
        }
        public static DirectoryCredential DirectoryCredential
        {
            get
            {
                return new DirectoryCredential(
                    ConfigurationManager.AppSettings["directory-browser-username"],
                    ConfigurationManager.AppSettings["directory-browser-password"]);
            }
        }

        public static string LogPath
        {
            get { return ConfigurationManager.AppSettings["log-path"]; }
        }

        public static string Origins
        {
            get { return ConfigurationManager.AppSettings["allowed-origins"]; }
        }
        public static string Headers
        {
            get { return ConfigurationManager.AppSettings["allowed-headers"]; }
        }
        public static string Methods
        {
            get { return ConfigurationManager.AppSettings["allowed-methods"]; }
        }
    }
}