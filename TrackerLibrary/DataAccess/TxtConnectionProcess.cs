using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess.TxtHelper
{
    public static class TxtConnectionProcess
    {
        /// <summary>
        /// Creates a file path from fileName to the fileName
        /// </summary>
        /// <param name="fileName">The name and extention of the file</param>
        /// <returns>A path</returns>
        public static string CreateFilePath (this string fileName)
        {
            // Returns: C/filePath/fileName.cvs
            return $"{ConfigurationManager.AppSettings["savePath"]}\\{fileName}";
        }

        /// <summary>
        /// Loads the data of a file from filePath into a list
        /// </summary>
        /// <param name="filePath">The path of the file</param>
        /// <returns>If it does not exitst, it creates a new empty list. Otherwise it load all the data into a list</returns>
        public static List<string> LoadFile(this string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new List<string>();
            }

            return File.ReadAllLines(filePath).ToList();
        }


        ///////////////////////////////////////////////      Prize Model        //////////////////////////////////////////////
        /// <summary>
        /// Converts the strings from the file into a PrizeModel type
        /// </summary>
        /// <param name="stringLines">An individual line of the file</param>
        /// <returns>A list containing each of the lines of the file converted into a PrizeModel type</returns>
        public static List<PrizeModel> ConvertStringsToPrizeModel(this List<string> stringLines)
        {
            List<PrizeModel> output = new List<PrizeModel>();

            foreach (string line in stringLines)
            {
                string[] columns = line.Split(',');

                PrizeModel p = new PrizeModel();

                p.Id = int.Parse(columns[0]);
                p.PlaceNumber = int.Parse(columns[1]);
                p.PlaceName = columns[2];
                p.PrizeAmount = decimal.Parse(columns[3]);
                p.PricePercentage = double.Parse(columns[4]);

                output.Add(p);
            }

            return output;
        }

        /// <summary>
        /// Takes the PrizeModel, converts it to string and saves it into the fileName file
        /// </summary>
        /// <param name="updatedModel">The model containing the new model</param>
        /// <param name="fileName">The name of the file to save to.</param>
        public static void SavePrizeModelToTxtFile(this List<PrizeModel> updatedModel, string fileName)
        {
            List<string> stringLines = new List<string>();

            foreach (PrizeModel model in updatedModel)
            {
                stringLines.Add($"{model.Id},{model.PlaceNumber},{model.PlaceName},{model.PrizeAmount},{model.PricePercentage}");
            }

            File.WriteAllLines(fileName.CreateFilePath(), stringLines);
        }


        ///////////////////////////////////////////////      Person Model        //////////////////////////////////////////////
        public static List<PersonModel> ConvertStringToPersonModel(this List<string> stringLines)
        {
            List<PersonModel> output = new List<PersonModel>();

            foreach (string line in stringLines)
            {
                string[] columns = line.Split(',');

                PersonModel model = new PersonModel();

                model.Id = int.Parse(columns[0]);
                model.firstName = columns[1];
                model.lastName = columns[2];
                model.Email = columns[3];
                model.Telephone = columns[4];

                output.Add(model);
            }

            return output;
        }

        public static void SavePeopleModelToTxt(this List<PersonModel> updatedModel, string fileName)
        {
            List<string> linesToSave = new List<string>();

            foreach (PersonModel model in updatedModel)
            {
                linesToSave.Add($"{model.Id},{model.firstName},{model.lastName},{model.Email},{model.Telephone}");
            }

            File.WriteAllLines(fileName.CreateFilePath(), linesToSave);
        }

        ////////////////////////////////////////////        Team Model      ////////////////////////////////////////////////
        
        public static List<TeamModel> ConvertStringToTeamModels(this List<string> stringLines, string fileName)
        {
            List<TeamModel> output = new List<TeamModel>();
            List<PersonModel> people = fileName.CreateFilePath().LoadFile().ConvertStringToPersonModel();

            foreach (string line in stringLines)
            {
                string[] columns = line.Split(',');

                TeamModel model = new TeamModel();

                model.Id = int.Parse(columns[0]);
                model.TeamName = columns[1];

                string[] personIds = columns[2].Split('|');

                foreach (string id in personIds)
                {
                    model.TeamMembers.Add(people.Where(x => x.Id == int.Parse(id)).First());

                }
                output.Add(model);
            }

            return output;
        }

        public static void SaveTeamModelToTxt(this List<TeamModel> updatedModel, string fileName)
        {
            List<string> linesToSave = new List<string>();

            foreach (TeamModel team in updatedModel)
            {
                linesToSave.Add($"{team.Id},{team.TeamName},{ConvertPeopleListToString(team.TeamMembers)}");
            }

            File.WriteAllLines(fileName.CreateFilePath(), linesToSave);
        }

        private static string ConvertPeopleListToString(List<PersonModel> people)
        {
            string output = "";

            if (people.Count == 0)
            {
                return "";
            }

            foreach (PersonModel person in people)
            {
                output += $"{person.Id}|";
            }

            output = output.Substring(0, output.Length - 1);

            return output;
        }

        /////////////////////////////////////////////       Tournament Model        ///////////////////////////////////////
        ///

        public static List<TournamentModel> ConvertTournamentListToString(this List<string> stringLines, string fileName, string fileNameTeamModel, string fileNamePrizeModel)
        {
            //id, TournamentName, EntryFee, (id|id|id - Entered Teams), (id|id|id - Prizes), Rounds - id^id^id|id^id^id|id^id^id|)
            List<TournamentModel> output = new List<TournamentModel>();
            List<TeamModel> teams = fileName.CreateFilePath().LoadFile().ConvertStringToTeamModels(fileNameTeamModel);
            List<PrizeModel> prizes = fileNamePrizeModel.CreateFilePath().LoadFile().ConvertStringsToPrizeModel();

            foreach (string line in stringLines)
            {
                string[] cols = line.Split(',');

                TournamentModel t = new TournamentModel();

                t.ID = int.Parse(cols[0]);
                t.TournamentName = cols[1];
                t.entryFee = decimal.Parse(cols[2]);

                string[] teamId = cols[3].Split('|');

                foreach (string id in teamId)
                {
                    //look for the team that id's matches the on in the loop and give me the first one
                    t.EnteredTeams.Add(teams.Where(x => x.Id == int.Parse(id)).First());
                }

                string[] prizeIds = cols[4].Split('|');

                foreach (string id in prizeIds)
                {
                    t.Prizes.Add(prizes.Where(x => x.Id == int.Parse(id)).First());
                }

                // ROUNDS

                output.Add(t);
            }

            return output;
        }

        public static void SaveTournamentModelToTxt(this List<TournamentModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (TournamentModel tm in models)
            {
                lines.Add($"{tm.ID},{tm.TournamentName},{tm.entryFee},{ConvertTeamListToString(tm.EnteredTeams)},{ConvertPrizeListToString(tm.Prizes)},{ConvertRoundListToString(tm.Rounds)}");
            }

            File.WriteAllLines(fileName.CreateFilePath(), lines);
        }

        public static string ConvertTeamListToString(List<TeamModel> teams)
        {
            string output = "";

            if (teams.Count == 0)
            {
                return "";
            }

            foreach (TeamModel t in teams)
            {
                output += $"{t.Id}|";
            }

            output = output.Substring(0, output.Length - 1);

            return output;
        }

        public static string ConvertPrizeListToString(List<PrizeModel> prizes)
        {
            string output = "";

            if (prizes.Count == 0)
            {
                return "";
            }

            foreach (PrizeModel t in prizes)
            {
                output += $"{t.Id}|";
            }

            output = output.Substring(0, output.Length - 1);

            return output;
        }

        public static string ConvertMatchupListToString(List<MatchModel> matchups)
        {
            string output = "";

            if (matchups.Count == 0)
            {
                return "";
            }

            foreach (MatchModel m in matchups)
            {
                output += $"{m.Id}^";
            }

            output = output.Substring(0, output.Length - 1);

            return output;
        }

        public static string ConvertRoundListToString(List<List<MatchModel>> rounds)
        {
            string output = "";

            if (rounds.Count == 0)
            {
                return "";
            }

            foreach ( List<MatchModel> r in rounds)
            {
                output += $"{ConvertMatchupListToString(r)}|";
            }

            output = output.Substring(0, output.Length - 1);

            return output;
        }
    }
}
