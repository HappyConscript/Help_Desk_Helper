/*
 * Author: Evan Brooks
 * Organization: Town of Cary
 * Date: 6/28/2018
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskHelper
{
    public class Incident
    {
        /*
         * ______________________________________________________________________________________________________________________________________________________________
         * Properties
         * This section contains global variables and properties utilized to define this object
         */

        public string User { get; set; }
        public string Phone { get; set; }
        public DateTime Date { get; set; }
        public Boolean Existing { get; set; }
        public Boolean Urgent { get; set; }
		public string Description { get; set; }

        /* 
         * ______________________________________________________________________________________________________________________________________________________________
         * Constructor
         * This section contains a function utilized in the instantiation of this object
         */

        public Incident(string user, string phone, DateTime date, Boolean existing, Boolean urgent, string description)
        {
            this.User = user;
            this.Phone = phone;
            this.Date = date;
            this.Existing = existing;
            this.Urgent = urgent;
			this.Description = description;
        }

        /* 
         * ______________________________________________________________________________________________________________________________________________________________
         * Functions
         * This section contains the functions which define the behaviors of this object
         */

        public override string ToString()
        {
			string incidentPrint = "User: " + User + " Phone: " + Phone + " Date: " + Date + " Existing: " + Existing + " Urgent: " + Urgent + " Description: " + Description; 
            return incidentPrint;
        }
    }
}
