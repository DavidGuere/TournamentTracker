using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public class PrizeModel
    {
        /// <summary>
        /// Unique prize identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Numeric identifier for the position (1 for first place, 2 for second...)
        /// </summary>
        public int PlaceNumber { get; set; }
        
        /// <summary>
        /// Name of the position (First place, Second place...)
        /// </summary>
        public string PlaceName { get; set; }

        /// <summary>
        /// The fixed amount that this place earnd. 0 if not applicable.
        /// </summary>
        public decimal PrizeAmount { get; set; }

        /// <summary>
        /// The number that represents the percentage of the entire take too be 
        /// given to this position. It is a number between 0 and 1. 0 if not applicable. 
        /// </summary>
        public double PricePercentage { get; set; }

        // Constructors
        public PrizeModel()
        {

        }

        public PrizeModel(string TplaceNumber, string TplaceName, string TprizeAmound, string TprizePercentage)
        {
            int placeNumberValue = 0;
            int.TryParse(TplaceNumber, out placeNumberValue);
            PlaceNumber = placeNumberValue;

            PlaceName = TplaceName;

            decimal prizeAmountValue = 0;
            decimal.TryParse(TprizeAmound, out prizeAmountValue);
            PrizeAmount = prizeAmountValue;

            double prizePercentageValue = 0;
            double.TryParse(TprizePercentage, out prizePercentageValue);
            PricePercentage = prizePercentageValue;
        }
    }
}
