using LibraryManagement.UI.Models;

using Newtonsoft.Json;

using System.IO;

namespace LibraryManagement.UI.Utils
{
    internal static class ConfigurationHelper
    {
        private static string _fileDirectory = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "LibraryManagement");
        private static string _filePath = Path.Join(_fileDirectory, "programming011.settings");

        private static ConfigurationInfo _configuration;

        public static void Write(ConfigurationInfo config)
        {
            string text = JsonConvert.SerializeObject(config);

            if (Directory.Exists(_fileDirectory) == false)
            {
                Directory.CreateDirectory(_fileDirectory);
            }

            File.WriteAllText(_filePath, text);
            _configuration = null;
        }

        public static ConfigurationInfo Read()
        {
            if (_configuration != null)
            {
                return _configuration;
            }

            if (Directory.Exists(_fileDirectory) == false || File.Exists(_filePath) == false)
            {
                return null;
            }

            string text = File.ReadAllText(_filePath);
            _configuration = JsonConvert.DeserializeObject<ConfigurationInfo>(text);
            return _configuration;
        }
    }
}
