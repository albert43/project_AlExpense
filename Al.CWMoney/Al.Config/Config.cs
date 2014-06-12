using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Newtonsoft.Json;

namespace Al.Config
{
    public class SynConf
    {
        public String Dir { set; get; }
        public DateTime AutoSyncTime { set; get; }
        public DateTime LastSyncTime { set; get; }
    }

    public class SystemConf
    {
        public String DbDir { set; get; }
        public SynConf Synch { set; get; }
    }

    /// <summary>
    /// Application interface to access config in JSON format.
    /// This class dependences on JSON.NET open source library.
    /// </summary>
    public class ConfigApi
    {
        private String m_strFileFullPath = null;
        
        /// <summary>
        /// Constructor.
        /// Every instance is depended on a config file.
        /// </summary>
        /// <param name="strFileFullPath">The full path of the configuration file.</param>
        public ConfigApi (String strFileFullPath)
        {
            this.m_strFileFullPath = strFileFullPath;
        }

        public void setConfig<T>(T root)
        {
            String strJson = null;

            //  Translate object ot JSON string
            strJson = JsonConvert.SerializeObject(root, Formatting.Indented);
            
            //  Write in config file.
            StreamWriter sw = new StreamWriter(m_strFileFullPath);
            sw.Write(strJson);
            sw.Close();
        }

        public T getConfig<T>()
        {
            T objJson;
            String strJson;

            //  Read config file.
            StreamReader sr = new StreamReader(m_strFileFullPath);
            strJson = sr.ReadToEnd();
            sr.Close();

            //  Translate to object
            objJson = JsonConvert.DeserializeObject<T>(strJson);

            return objJson;
        }
    }
}
