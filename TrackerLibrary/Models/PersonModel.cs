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
        /// <summary>
        /// Unique prize identifier
        /// </summary>
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }

        public string fullName
        {
            get
            {
                return $"{firstName} {lastName}";
            }
        }

        public PersonModel()
        {

        }

        public PersonModel(string TfirsrtName, string TlastName, string Temail, string Ttelephone)
        {
            firstName = TfirsrtName;
            lastName = TlastName;
            Email = Temail;
            Telephone = Ttelephone;
        }
    }
}
