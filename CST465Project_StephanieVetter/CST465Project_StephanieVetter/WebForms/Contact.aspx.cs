using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CST465Project_StephanieVetter.Web_Forms
{
    public partial class Contact : System.Web.UI.Page
    {
        StringBuilder userInput = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            uxEventOutput.Text += "<br/>" + "Page Load";
        }
        protected void _Init(EventArgs e)
        {
            uxEventOutput.Text += "<br/>" + "Page Init";
        }
        protected void _OnPreRender(EventArgs e)
        {
            uxEventOutput.Text += "<br/>" + "PreRender";
        }
        protected void uxSubmit_Click(object sender, EventArgs e)
        {
            uxEventOutput.Text += "<br/>" + "uxSubmit_Click";

            userInput.Append("<br/>" + "Name: " + uxName.Text + "<br/>");
            userInput.Append("Priority: " + uxPriority.SelectedValue + "<br/>");
            userInput.Append("Subject: " + uxSubject.Text + "<br/>");
            userInput.Append("Description: " + uxDescription.Text);

            uxFormOutput.Text = userInput.ToString();
        }
    }
}