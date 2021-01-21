﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    public interface IDataConnection
    {
        PrizeModel SavePrizeModel(PrizeModel new_model);
        PersonModel SavePersonModel(PersonModel new_model);
    }
}
