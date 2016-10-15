using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CST465Project_StephanieVetter.Web_Forms
{
    public partial class ValidateForm : System.Web.UI.Page
    {
        StringBuilder queryString = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void uxSubmit_Click(object sender, EventArgs e)
        {
            queryString.Append("?name=" + uxName.Value);
            queryString.Append("&favoritecolor=" + uxFavColor.Value);
            queryString.Append("&city=" + uxCity.Value);

            Response.Redirect("~/Web Forms/ValidateFormOutput.aspx" + queryString);   
        }
    }
}