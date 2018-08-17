/*
 * Author: Evan Brooks
 * Organization: Town of Cary
 * Date: 8/17/2018
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics; //Namespace with debug class

namespace HelpDeskHelper
{
	public partial class FrmIncident : Form
    {
        /*
         * ______________________________________________________________________________________________________________________________________________________________
         * Fields
         * This section contains global variables and properties utilized by other objects and classes
         */

        //List used to store Incident objects
        public List<Incident> incidentsList = new List<Incident>();

        //Bool used to check if list is populated
        public bool listPopulated = false;

        //Variable to store reference to Main Form
        private FrmMain parent;

        /* 
         * ______________________________________________________________________________________________________________________________________________________________
         * Constructor
         * This section contains a function utilized in the instantiation of this object
         */

        public FrmIncident(FrmMain parent)
		{
			//Initialize FrmIncident with parameters
			InitializeComponent();
			this.parent = parent;
		}

        /* 
         * ______________________________________________________________________________________________________________________________________________________________
         * Form Event Functions
         * This section contains functions utilized in various events / behaviors of the form object
         */

        private void frmIncident_Load(object sender, EventArgs e)
		{

		}

        /* 
         * ______________________________________________________________________________________________________________________________________________________________
         * Input Functions
         * This section contains functions utilized as a direct result of user inputs
         */

        //Summary: Process user inputs and subsequently instantiate incident objects
        //Usage: add incident objcets to the incidentsList
        private void btnSave_Click(object sender, EventArgs e)
		{
            //Validate sufficient information has been provided by the user
            if (inputCheck() == true)
            {
                //Initialize variables with user inputs
                string user = txtUser.Text;
                string phone = txtPhone.Text;
                DateTime date = dtpDate.Value;
                Boolean existing = false;
                Boolean urgent = false;
                string description = txtDescription.Text;

                //Change boolean values based on check boxes
                if (chkExisting.Checked == true)
                    existing = true;
                if (chkUrgent.Checked == true)
                    urgent = true;

                //Instantiate Incident object with user inputs
                Incident incident = new Incident(user, phone, date, existing, urgent, description);
                incidentsList.Add(incident);

                //Inform user of successful operation
                MessageBox.Show("New incident created. Clearing fields.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                //Update the validation
                listPopulated = true;

                //Clear the form fields and refocus the cursor
                txtUser.Focus();
                inputClear();
            }
            else
            {
                //Inform user of need for basic information
                MessageBox.Show("Please enter at least a username and description!", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                txtUser.Focus();
            }
            
		}

        //Summary: closes Incident Form and activates Main Form
        //Usage: triggers the transfer of the incidentsList
		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
            parent.Activate();
		}

        /* 
         * ______________________________________________________________________________________________________________________________________________________________
         * Auxilliary Functions
         * This section contains functions utilized as components of other functions
         */

        //Summary: return incidentsList object
        //Usage: pulls the list of incident objects into the main form
        public List<Incident> transferList()
        {
            return incidentsList;
        }

        //Summary: clear user inputs
        //Usage: resets the Incident Form
        private void inputClear()
		{
			txtUser.Clear();
			txtPhone.Clear();
			chkExisting.CheckState = CheckState.Unchecked;
			chkUrgent.CheckState = CheckState.Unchecked;
			txtDescription.Clear();
		}

        //Summary: check user input exists
        //Usage: ensures key form fields have been filled
        private Boolean inputCheck()
        {
            Boolean check = false;

            if (txtUser.Text == "" && txtDescription.Text == "")
            {
                check = false;
            }
            else
            {
                check = true;
            }

            return check;
        }

        /*
         * ______________________________________________________________________________________________________________________________________________________________
         *User Experience Functions
         *This section contains a variety of functions which facillitate improved user experience and data entry validation
         */

        private void txtUser_Click(object sender, EventArgs e)
        {
            txtUser.SelectAll();
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            txtUser.SelectAll();
        }

        private void txtPhone_Click(object sender, EventArgs e)
        {
            txtPhone.SelectAll();
        }

        private void txtPhone_Enter(object sender, EventArgs e)
        {
            txtPhone.SelectAll();
        }

        private void txtDescription_Click(object sender, EventArgs e)
        {
            txtDescription.SelectAll();
        }

        private void txtDescription_Enter(object sender, EventArgs e)
        {
            txtDescription.SelectAll();
        }
    }
}
