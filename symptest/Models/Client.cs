using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace symptest.Models
{
    public class Client
    {
        public string ClientId { get; set; }
        public DateTime Client_Date_Of_Birth { get; set; }
        public string Relationship_Status { get; set; }
        public string Advocate_Name { get; set; }
        public string Notes_On_Client { get; set; }
        public string Gender { get; set; }
        public string Ethnicity { get; set; }
        public string Race { get; set; }
        public string Partner_Gender { get; set; }
    }
}
