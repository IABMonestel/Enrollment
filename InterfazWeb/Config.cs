using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace InterfazWeb
{
    public class Config
    {
        public static string getConnectionString
        {
            get
            {
                return ConfigurationManager.AppSettings["ConnectionString"];
            }
        }
    }
}