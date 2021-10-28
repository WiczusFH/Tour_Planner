using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using log4net;

namespace DataAccess
{
    public class Configuration
    {
    public static bool Configured { get; private set; } = false;

    public static string Host { get; private set; }
    public static string Username { get; private set; }
    public static string Password { get; private set; }
    public static string Database { get; private set; }
    public static string MapQuestKey { get; private set; }
    public static string MapQuestURL { get; private set; }

    log4net.ILog Log = LogManager.GetLogger(typeof(Configuration));

    private static Configuration _address = new Configuration();
    public static Configuration address { get { return _address; } }


    private Configuration()
        {
            string ConfigText;
            try
            {
                ConfigText = File.ReadAllText("config.json", Encoding.UTF8);
                JObject jObject = JObject.Parse(ConfigText);
                Host=jObject.GetValue("host").ToString();
                Username = jObject.GetValue("username").ToString();
                Password = jObject.GetValue("password").ToString();
                Database = jObject.GetValue("database").ToString();
                MapQuestKey = jObject.GetValue("mapQuestKey").ToString();
                MapQuestURL = jObject.GetValue("mapQuestURL").ToString();
                Configured = true;
            }
            catch (Exception)
            {

            }
        }
    }
}
