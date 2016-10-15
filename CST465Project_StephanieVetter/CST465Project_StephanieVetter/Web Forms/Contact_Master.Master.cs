using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CST465Project_StephanieVetter.Web_Forms
{
    public partial class Contact_Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public String LabelText
        {
            get { return lblRequiredTextBox.Text; }

            set
            {
                lblRequiredTextBox.Text = value;
                requiredTextBox.ErrorMessage = value + "is required";
            }
        }
        public String Value
        {
            get { return uxRequiredTextBox.Text; }

            set
            {
                uxRequiredTextBox.Text = value;
            }
        }
        public String ValidationGroup
        {
            get { return requiredTextBox.ValidationGroup; }

            set
            {
                requiredTextBox.ValidationGroup = value;
            }
        }
    }
}