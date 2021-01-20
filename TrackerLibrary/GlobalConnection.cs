using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.DataAccess;

namespace TrackerLibrary
{
    public static class GlobalConnection
    {
        public static List<IDataConnection> ListOfConnections { get; private set; } = new List<IDataConnection>();

        public static void InitializeConnections(bool sqlData, bool txtData)
        {
            if (sqlData)
            {
                SqlConnection sql = new SqlConnection();
                ListOfConnections.Add(sql);
            }

            if (txtData)
            {
                TxtConnection txt = new TxtConnection();
                ListOfConnections.Add(txt);
               
            }
        }
    }
}
