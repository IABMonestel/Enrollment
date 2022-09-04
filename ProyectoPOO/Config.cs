using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaz
{
    public static class Config
    {
        //propiedad de solo lectura que recupera la variable connectionString
        public static string getConnectionString
        {
            get
            {
                return Properties.Settings.Default.ConnectionString;
            }
        }
    }
}
