using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess.TxtHelper;

namespace TrackerLibrary.DataAccess
{
    class TxtConnection : IDataConnection
    {
        private const string prizeModelFileName = "PrizeModel.csv";
        private const string peopleModelFileName = "PeopleModel.csv";

        public PersonModel SavePersonModel(PersonModel new_model)
        {
            List<PersonModel> people = peopleModelFileName.CreateFilePath().LoadFile().ConvertStringToPersonModel();

            int maxId = 1;
            if (people.Count > 0)
            {
                maxId = people.OrderByDescending(column => column.Id).First().Id + 1;
            }

            new_model.Id = maxId;

            people.Add(new_model);

            people.SavePeopleModelToTxt(peopleModelFileName);

            return new_model;
        }

        public PrizeModel SavePrizeModel(PrizeModel new_model)
        {
            // take the fileName, convert it to a full path, Load the file from path, convert it to PrizeModel.
            List<PrizeModel> prizes = prizeModelFileName.CreateFilePath().LoadFile().ConvertStringsToPrizeModel();

            // Order the list according to the id in descending, take the first one (max) and add 1.
            int maxId = 1;
            
            if (prizes.Count > 0)
            {
                maxId = prizes.OrderByDescending(column => column.Id).First().Id + 1;
            }
            
            
            // Set the new model's ID to the max+1.
            new_model.Id = maxId;

            // Add the new_model to the list
            prizes.Add(new_model);

            // Save the file in a txt format.
            prizes.SavePrizeModelToTxtFile(prizeModelFileName);

            return new_model;
        }
    }
}
