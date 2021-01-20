using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    class TxtConnection : IDataConnection
    {
        public PrizeModel SavePrizeModel(PrizeModel new_model)
        {
            new_model.Id = 1;
            return new_model;
        }
    }
}
