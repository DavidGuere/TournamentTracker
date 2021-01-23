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

//  @FirstName nvarchar(50),
//	@LastName nvarchar(50),
//	@Email nvarchar(50),
//	@Telephone varchar(10),
//	@id int = 0 output

//  @TeamId int,
//  @PersonId int,
//  @id int = 0 output

//  @TeamName nvarchar(50),
//  @id int = 0 output

namespace TrackerLibrary.DataAccess
{
    public class SqlConnection : IDataConnection
    {
        private const string nameOfConnection = "MyTournaments";

        public TeamModel SaveTeamModel(TeamModel new_model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConnection.ConnectionName(nameOfConnection)))
            {
                var p = new DynamicParameters();

                p.Add("@TeamName", new_model.TeamName);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spTeams_insert_data", p, commandType: CommandType.StoredProcedure);

                new_model.Id = p.Get<int>("@id");

                foreach (PersonModel person in new_model.TeamMembers)
                {
                    var p2 = new DynamicParameters();

                    p2.Add("@TeamId", new_model.Id);
                    p2.Add("@PersonId", person.Id);

                    connection.Execute("dbo.spTeamMembers_insert_data", p2, commandType: CommandType.StoredProcedure);
                }

                return new_model;
            }
        }

        public PersonModel SavePersonModel(PersonModel new_model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConnection.ConnectionName(nameOfConnection)))
            {
                var p = new DynamicParameters();
                p.Add("FirstName", new_model.firstName);
                p.Add("@LastName", new_model.lastName);
                p.Add("@Email", new_model.Email);
                p.Add("@Telephone", new_model.Telephone);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("spPeople_insert_data", p, commandType: CommandType.StoredProcedure);

                new_model.Id = p.Get<int>("@id");

                return new_model;
            }
        }

        /// <summary>
        /// Saves the pzize to the SQL database
        /// </summary>
        /// <param name="new_model">The prize information</param>
        /// <returns>The prize information including the unique identifier.</returns>
        public PrizeModel SavePrizeModel(PrizeModel new_model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConnection.ConnectionName(nameOfConnection)))
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

        public List<PersonModel> GetAllPeople()
        {
            List<PersonModel> output;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConnection.ConnectionName(nameOfConnection)))
            {
                output = connection.Query<PersonModel>("dbo.spSelectAllPeople").ToList();
            }

            return output;
        }

        public List<TeamModel> GetAllTeams()
        {
            List<TeamModel> output;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConnection.ConnectionName(nameOfConnection)))
            {
                output = connection.Query<TeamModel>("dbo.spSelectAllTeams").ToList();

                foreach (TeamModel team in output)
                {
                    var p = new DynamicParameters();
                    p.Add("@@TeamId", team.Id);

                    team.TeamMembers = connection.Query<PersonModel>("dbo.spSelectMembersByTeam", p, commandType: CommandType.StoredProcedure).ToList();
                }
            }

            return output;
        }
    }
}
