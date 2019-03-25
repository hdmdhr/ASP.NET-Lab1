using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab1
{
    public partial class Lease : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customer"] != null)
            {
                Debug.WriteLine("have session");
            }
            else
            {
                Response.Redirect("~/Register.aspx");
            }
        }
    }
}