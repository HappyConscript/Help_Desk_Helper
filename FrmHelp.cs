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
    public partial class FrmHelp : Form
    {

        /* 
        * ______________________________________________________________________________________________________________________________________________________________
        * Constructor
        * This section contains a function utilized in the instantiation of this object
        */

        public FrmHelp()
        {
            InitializeComponent();
        }

        /* 
         * ______________________________________________________________________________________________________________________________________________________________
         * Input Functions
         * This section contains functions utilized as a direct result of user inputs
         */
        
        //Summary: closes object
        //Usage: closes the help form 
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
