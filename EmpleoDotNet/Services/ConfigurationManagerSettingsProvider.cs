using System.Configuration;
using EmpleoDotNet.AppServices;

namespace EmpleoDotNet.Services
{
    public class ConfigurationManagerSettingsProvider : ISettingsProvider
    {
        public string Get(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}