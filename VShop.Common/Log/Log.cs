using System;
using System.Collections.Generic;
using System.IO;

namespace VShop.Common
{
    public class Log
    {
        public static void Component(string Message)
        {
            WriteFile("Component", Message);
        }

        public static void Component(Exception ex)
        {
            WriteFile("Component", ex.ToString());
        }

        public static void Website(string Message)
        {
            WriteFile("Website", Message);
        }

        public static void Website(Exception ex)
        {
            WriteFile("Website", ex.ToString());
        }

        public static void WebAPI(string Message)
        {
            WriteFile("WebAPI", Message);
        }

        public static void WebAPI(Exception ex)
        {
            WriteFile("WebAPI", ex.ToString());
        }

        public static void Service(string Message)
        {
            WriteFile("Service", Message);
        }

        public static void Service(Exception ex)
        {
            WriteFile("Service", ex.ToString());
        }

        public static void Repositories(Exception ex)
        {
            WriteFile("Repositories", ex.ToString());
        }

        public static void Repositories(string Message)
        {
            WriteFile("Repositories", Message);
        }

        public static void Entity(string Message)
        {
            WriteFile("Entity", Message);
        }

        public static void Entity(Exception ex)
        {
            WriteFile("Entity", ex.ToString());
        }

        #region ===== Private =====

        private static IDictionary<string, object> locker = new Dictionary<string, object>();

        private static object GetLocker(string name)
        {
            if (!locker.ContainsKey(name))
            {
                locker[name] = new object();
            }
            return locker[name];
        }

        private static void WriteFile(string folder, string message)
        {
            WriteFile(folder, "", message);
        }

        private static void WriteFile(string folder, string filename, string message)
        {
            try
            {
                lock (GetLocker(folder))
                {
                    string path = AppDomain.CurrentDomain.BaseDirectory + "/Web/Log/" + folder;
                    string file = path + "/"
                        + (!string.IsNullOrEmpty(filename) ? filename + "_" : "")
                        + DateTime.Now.ToString("yyyy_MM_dd") + ".log";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    using (var objSW = new StreamWriter(file, true))
                    {
                        objSW.WriteLine("===== " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ": " + message);
                        objSW.Close();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        #endregion ===== Private =====
    }
}