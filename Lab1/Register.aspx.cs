using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CPRG214.Marina.Domain;

namespace Lab1
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //!ValidationSummary1.ShowMessageBox
            if (IsValid)
            {
                // validation passed, create Customer obj
                Customer currentCust = null;
                
                // check if user exist in database already
                var allCustomers = CustomerManager.GetAllCustomers();
                bool isInDB = false;
                // iterate through all customers, compare properties
                foreach (var oldC in allCustomers)
                {
                    if (txtFName.Text == oldC.FirstName &&
                        txtLName.Text == oldC.LastName &&
                        txtPhone.Text == oldC.Phone &&
                        txtCity.Text == oldC.City)
                    {
                        // have a match in database, change flag to true, assign 
                        isInDB = true;
                        currentCust = oldC;
                    }
                }

                if (!isInDB)
                {
                    // not in DB, create new obj, insert into DB
                    currentCust = new Customer
                    {
                        // set id to current max id + 1
                        CustomerID = allCustomers.Max(c => c.CustomerID) + 1,  
                        FirstName = txtFName.Text,
                        LastName = txtLName.Text,
                        Phone = txtPhone.Text,
                        City = txtCity.Text
                    };
                    CustomerManager.InsertCustomer(currentCust);
                }

                // now current customer exist in DB, create session
                Session.Add("customer", currentCust);
                Response.Redirect("~/Lease.aspx");
            }

        }

        
        
    }
}