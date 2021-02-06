using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    
    /// <summary>
    /// Represents one match in the tournament
    /// </summary>
    public class MatchModel
    {
        public int Id { get; set; }
        /// <summary>
        /// The list of teams participaiting in this match
        /// </summary>
        public List<MatchupEntryModel> Entries { get; set; }

        /// <summary>
        /// The winner of the match
        /// </summary>
        public TeamModel Winner { get; set; }

        /// <summary>
        /// The number of the current round
        /// </summary>
        public int MatchupRound { get; set; }
    }
}
