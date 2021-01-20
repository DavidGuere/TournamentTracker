using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    /// <summary>
    /// Represents one member of the team
    /// </summary>
    public class PersonModel
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
    }
}
