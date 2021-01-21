using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.DataAccess;
using System.Configuration;


namespace TrackerLibrary
{
    public static class GlobalConnection
    {
        public static IDataConnection Connection { get; private set; }

        public static void InitializeConnection(DatabaseType type)
        {
            switch (type)
            {
                case DatabaseType.SQL:
                    SqlConnection sql = new SqlConnection();
                    Connection = sql;
                    break;
                case DatabaseType.TXT:
                    TxtConnection txt = new TxtConnection();
                    Connection = txt;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Returns the connection string from the App.config
        /// </summary>
        /// <param name="name_of_connection">The name of the connection</param>
        /// <returns>The connection string of name_of_connection connection</returns>
        public static string ConnectionName(string name_of_connection)
        {
            return ConfigurationManager.ConnectionStrings[name_of_connection].ConnectionString;
        }
    }
}
