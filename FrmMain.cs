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
using System.IO; //Namespace for file input and output

namespace HelpDeskHelper
{
	public partial class FrmMain : Form
	{

        /*
         * ______________________________________________________________________________________________________________________________________________________________
         * Fields
         * This section contains global variables and proprties utilized by other objects and classes
         */

        //Variable to store reference to Incident Form
        private FrmIncident frmIncident;
        private FrmAbout frmAbout;

        /* 
         * ______________________________________________________________________________________________________________________________________________________________
         * Constructor
         * This section contains a function utilized in the instantiation of this object
         */

        public FrmMain()
		{
            //Instantiate incident form during construction so form
            //can be used by all methods
            frmIncident = new FrmIncident(this);

            InitializeComponent();
		}

        /* 
         * ______________________________________________________________________________________________________________________________________________________________
         * Form Event Functions
         * This section contains functions utilized in various events / behaviors of the form object
         */

        private void frmMain_Load(object sender, EventArgs e)
		{

		}

        //Summary: process instructions to pull incidents object list from Incidents Form to Main Form
        //Usage: populates list view on Main Form with objects from Incidents List
		private void FrmMain_Activated(object sender, EventArgs e)
		{
            //Instantiate Temporary Incidents List to hold contents
            //of Original Incidents list from incidents form
            List<Incident> tempIncidentsList = new List<Incident>();

            //If objects have been added to the Original Incidents List
            //and, by extention, if that list was ever even instantiated
            if (frmIncident.listPopulated == true)
            {
                //Set Temporary Incidents List = contents of the Original Incidents List
                tempIncidentsList = frmIncident.transferList();

                //Debug statements to confirm input and object count
                //Debug.Print(tempIncidentsList[0].User);
                //Debug.Print(tempIncidentsList.Count.ToString());

                //Populate the List View with the objects from the Temporary Incidents List
                foreach (Incident incident in tempIncidentsList)
                {
                    //Declare list view item to store incident object
                    //attributes in different columns (initialize with first value)
                    ListViewItem listItem = new ListViewItem(incident.User);

                    //Add attributes from current incident object in Temporary Incidents List
                    //to list view item in order of appearance in lits view columns
                    listItem.SubItems.Add(incident.Phone);
                    listItem.SubItems.Add(incident.Date.ToString());
                    listItem.SubItems.Add(incident.Existing.ToString());
                    listItem.SubItems.Add(incident.Urgent.ToString());
                    listItem.SubItems.Add(incident.Description);

                    //Add the list view item to the list view
                    lstvwIncidents.Items.Add(listItem);

                    //Clear list view item of object contents to avoid redundancy
                    listItem = null;
                }

                //Clear object list of objects to avoid redundancy
                tempIncidentsList.Clear();
            }

            //Clear incidents list of object to avoid redundancy
            tempIncidentsList = null;
        }

        /* 
         * ______________________________________________________________________________________________________________________________________________________________
         * Input Functions
         * This section contains functions utilized as a direct result of user inputs
         */

        //Summary: instantiates a new Incident Form object
        //Usage: opens Incident Form
        private void btnNewIncident_Click(object sender, EventArgs e)
		{
            frmIncident = new FrmIncident(this);
            frmIncident.Show();
		}

        //Summary: Instantiate a new Browser Form object
        //Usage: opens browser form
		private void btnSamanage_Click(object sender, EventArgs e)
		{
            FrmBrowser frmBrowser = new FrmBrowser();
            frmBrowser.Show();
        }

        //Summary: prompts user to confirm clear of list view
        //Usage: clear list view
        private void btnClear_Click(object sender, EventArgs e)
        {
            //Declare variable of DialogResult type and assign messagebox to it
            DialogResult exit = MessageBox.Show("Clear incidents list?", "Clear confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //If user selects 'Yes', close the application (no closes messagebox automatically)
            if (exit == DialogResult.Yes)
            {
                lstvwIncidents.Items.Clear();
            }
        }

        /* 
         * ______________________________________________________________________________________________________________________________________________________________
         * Menu Bar Functions
         * This section contains functions utilized as a direct result of user inputs through the Menu Bar
         */

        //Summary: instantiates a new About Form object
        //Usage: opens Help Form
        private void mbAbout_Click(object sender, EventArgs e)
        {
            FrmAbout frmAbout = new FrmAbout();
            frmAbout.Show();
        }

        //Summary: instantiates a new Help Form object
        //Usage: opens Help Form
        private void mbHelp_Click(object sender, EventArgs e)
        {
            FrmHelp frmHelp = new FrmHelp();
            frmHelp.Show();
        }

        //Summary: prompts user to confirm closure of application
        //Usage: exits application
        private void mbExit_Click(object sender, EventArgs e)
        {
            //Declare variable of DialogResult type and assign messagebox to it
            DialogResult exit = MessageBox.Show("Exit application?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //If user selects 'Yes', close the application (no closes messagebox automatically)
            if (exit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
