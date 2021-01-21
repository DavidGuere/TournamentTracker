using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;
using System.Data;
using Dapper;

 //   @PlaceNumber int,
 //   @PlaceName nvarchar(50),
 //   @PrizeAmount money,
 //   @PrizePercentage float,
 //   @id int = 0 output

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
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConnection.ConnectionName("MyTournaments")))
            {
                var p = new DynamicParameters();
                p.Add("@PlaceNumber", new_model.PlaceNumber);
                p.Add("@PlaceName", new_model.PlaceName);
                p.Add("@PrizeAmount", new_model.PrizeAmount);
                p.Add("@PrizePercentage", new_model.PricePercentage);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spPrizes_insert_data", p, commandType: CommandType.StoredProcedure);

                new_model.Id = p.Get<int>("@id");

                return new_model;
            }
        }
    }
}
