using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace TLWebForm.DataAccess.Internal
{
    internal class DataAccess
    {
        public static string GetConnectionString(string name)
        {
            string cnnVal = ConfigurationManager.ConnectionStrings[name].ConnectionString;
            return cnnVal;
        }
    }
}