using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace EvyThingUtil
{
    class XmlConfigLoader
    {
        private XDocument xmlDoc;
        private readonly string XML_PATH = AppDomain.CurrentDomain.BaseDirectory + @"\xml_config.xml";

        public XmlConfigLoader()
        {
            xmlDoc = XDocument.Load(XML_PATH);  
        }

        private string GetConfigValue(string key)
        {
            var results = from c in xmlDoc.Descendants(key)
                          select c;
            string s = "";
            foreach (var result in results)
            {
                s = result.Value;
                break;
            }
            return s;   
        }

        private string GetConfigAttriValue(string key, string xmlAttribute)
        {
            var results = from c in xmlDoc.Descendants(key)
                          select c;
            string s = "";
            foreach (var result in results)
            {
                s = result.Attribute(xmlAttribute).Value;
                break;
            }
            return s;
        }

        private void SetConfigValue(string key, string value)
        {
            var results = from c in xmlDoc.Descendants(key)
                          select c;
            foreach (var result in results)
            {
                result.Value = value;
            }
            xmlDoc.Save(XML_PATH); 
        }

        public int GetWindowH()
        {
           return int.Parse(GetConfigValue("window_height"));
        }

        public void SetWindowH(int value)
        {
            SetConfigValue("window_height", value.ToString());
        }

        public int GetWindowW()
        {
            return int.Parse(GetConfigValue("window_width"));
        }

        public void SetWindowW(int value)
        {
            SetConfigValue("window_width", value.ToString());
        }

        public bool GetMatchRegex()
        {
            return bool.Parse(GetConfigValue("match_regex"));
        }

        public void SetMatchRegex(bool value)
        {
            SetConfigValue("match_regex", value.ToString());
        }

        public bool GetMatchWholeWord()
        {
            return bool.Parse(GetConfigValue("match_whole_word"));
        }

        public void SetMatchWholeWord(bool value)
        {
            SetConfigValue("match_whole_word", value.ToString());
        }

        public bool GetMatchPath()
        {
            return bool.Parse(GetConfigValue("match_path"));
        }

        public void SetMatchPath(bool value)
        {
            SetConfigValue("match_path", value.ToString());
        }

        public bool GetMatchCase()
        {
            return bool.Parse(GetConfigValue("match_case"));
        }

        public void SetMatchCase(bool value)
        {
            SetConfigValue("match_case", value.ToString());
        }
    }
}
