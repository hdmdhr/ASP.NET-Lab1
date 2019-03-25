using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CPRG214.Marina.Domain;

namespace Lab1
{
    public partial class Lease : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customer"] != null)
            {
                var customer = (Customer)Session["customer"];
                var leaseHistory = CustomerManager.FindLeasingHistory(customer);
                if (leaseHistory.Count > 0)
                {
                    lblLeaseHistory.Text = $"Hello {customer.FirstName}, here's your leasing history.";
                    grdLeaseHistory.DataSource = leaseHistory;
                    DataBind();
                }
                else
                    lblLeaseHistory.Text = $"Hello {customer.FirstName}, you don't have any leasing history yet.";
            }
            else
            {
                Response.Redirect("~/Register.aspx");
            }
        }
    }
}