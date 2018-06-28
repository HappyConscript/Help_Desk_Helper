/*
 * Author: Evan Brooks
 * Organization: Town of Cary
 * Date: 6/28/2018
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

namespace HelpDeskHelper
{
    public partial class FrmBrowser : Form
    {
       /* 
        * ______________________________________________________________________________________________________________________________________________________________
        * Constructor
        * This section contains a function utilized in the instantiation of this object
        */
        public FrmBrowser()
        {
            InitializeComponent();
        }

        /* 
         * ______________________________________________________________________________________________________________________________________________________________
         * Form Event Functions
         * This section contains functions utilized in various events / behaviors of the form object
         */

        private void FrmBrowser_Activated(object sender, EventArgs e)
        {
            Uri samange = new Uri("https://townofcary.samanage.com/");
            wbSamanage.Url = samange;
        }

        /* 
         * ______________________________________________________________________________________________________________________________________________________________
         * Input Functions
         * This section contains functions utilized as a direct result of user inputs
         */

        //Summary: closes Incident Form and activates Main Form
        //Usage: triggers the transfer of the incidentsList
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
