using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Al.Config
{
    public class SynConf
    {
        public String m_strDir { set; get; }
        public DateTime m_dtAutoSynTime { set; get; }
        public DateTime m_dtLastSynTime { set; get; }
    }

    public class SysemConf
    {
        public String m_strDbDir { set; get; }
        public SynConf m_Sync { set; get; }
    }

    public class ConfigApi
    {
        private String m_strFileFullPath;

        public ConfigApi(String strFileFullPath)
        {
            this.m_strFileFullPath = strFileFullPath;
        }

        public void setConfig<T>(T root)
        {
            String strJson = null;

            strJson = JsonConvert.SerializeObject(root, Formatting.Indented);

            int i = 1;
        }

        public T getConfig<T>(String strJson)
        {
            T objJson;

            objJson = JsonConvert.DeserializeObject<T>(strJson);

            return objJson;
        }

    }
}
