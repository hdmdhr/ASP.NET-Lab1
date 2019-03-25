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
        // Show Lease History
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

        // User Picked A Dock: SelectedValue is DockID, use it to retrive slips
        protected void drpDockPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpDockPicker.SelectedValue == "0")
                return;
                var availableSlips = SlipManager.GetAvailableSlipsFromDock(Convert.ToInt32(drpDockPicker.SelectedValue));
                grdAvailableSlips.DataSource = availableSlips;
                DataBind();
                Session.Add("availableSlips",availableSlips);
        }

        // User Clicked On Lease Button: insert a new record into Lease table, give feedback message
        protected void grdAvailableSlips_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "lease")
            {
                var index = Convert.ToInt32(e.CommandArgument);
                var selectedSlip = ((List<Slip>)Session["availableSlips"])[index];
                var currentCustomer = (Customer)Session["customer"];

                if (SlipManager.LeaseSelectedSlip(selectedSlip, currentCustomer))
                {
                    // refresh lease history and available slips
                    drpDockPicker_SelectedIndexChanged(sender,e);
                    Page_Load(sender,e);

                    Response.Write($"<h2 class='alert alert-success'>The slip (id: {selectedSlip.SlipID}) is holded for you, please pay within 24 hours.</h2>");
                }

            }
        }
    }
}