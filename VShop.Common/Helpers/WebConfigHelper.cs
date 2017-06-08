using System;
using System.Configuration;

namespace VShop.Common.Helpers
{
    public static class WebConfigHelper
    {
        public static string GetKey(string key)
        {
            return ConfigurationManager.AppSettings[key].ToString();
        }

        public static void SetKey(string key, string value)
        {
            if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                ConfigurationManager.AppSettings[key] = value;
        }

        public static int GetPageSize()
        {
            return Convert.ToInt32(GetKey("PageSize"));
        }

        public static int GetMaxPage()
        {
            return Convert.ToInt32(GetKey("MaxPage"));
        }
    }
}