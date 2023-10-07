using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DBConnector.SQLite
{
    [XmlRoot("Configuration")]
    public class Configuration
    {
        protected static string _configPath = @".\SQLiteConfiguration.xml";
        public static Configuration Load()
        {
            using (var stream = new FileStream(_configPath, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
                Configuration config = (Configuration)serializer.Deserialize(stream);
                return config;
            }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        protected Configuration()
        {
            Path = string.Empty;
        }

        [XmlElement("Path")]
        public string Path { get; set; }
    }
}
