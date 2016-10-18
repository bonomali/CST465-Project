using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CST465Project_StephanieVetter.Web_Forms
{
    public partial class ValidateFormOutput : System.Web.UI.Page
    {
        String name = null;
        String favColor = null;
        String city = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            name = Request.QueryString["name"];
            favColor = Request.QueryString["favoritecolor"]; 
            city = Request.QueryString["city"];

            if (name == null || favColor == null || city == null)
            {
                uxInvalidDataArea.Visible = true;
            }
            else
            {
                uxName.Text = name;
                uxFavoriteColor.Text = favColor;
                uxCity.Text = city;
                uxValidDataArea.Visible = true;
            }
        }
    }
}