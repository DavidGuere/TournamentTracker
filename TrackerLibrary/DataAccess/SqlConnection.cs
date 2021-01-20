using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    public class SqlConnection : IDataConnection
    {
        /// <summary>
        /// Saves the pzize to the SQL database
        /// </summary>
        /// <param name="new_model">The prize information</param>
        /// <returns>The prize information including the unique identifier.</returns>
        public PrizeModel SavePrizeModel(PrizeModel new_model)
        {
            new_model.Id = 1;
            return new_model;
        }
    }
}
