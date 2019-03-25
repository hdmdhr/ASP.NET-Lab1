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
            if (!ValidationSummary1.ShowMessageBox)
            {
                // validation passed, create Customer obj
                var newC = new Customer
                {
                    CustomerID = null,  // set to null, use database auto increment
                    FirstName = txtFName.Text,
                    LastName = txtFName.Text,
                    Phone = txtPhone.Text,
                    City = txtCity.Text
                };
                // check if user exist in database already
                var allCustomers = CustomerManager.GetAllCustomers();
                bool isInDB = false;
                // iterate through all customers, compare properties
                foreach (var oldC in allCustomers)
                {
                    if (newC.FirstName == oldC.FirstName &&
                        newC.LastName == oldC.LastName &&
                        newC.Phone == oldC.Phone &&
                        newC.City == oldC.City)
                        // have a match in database, change flag to true
                        isInDB = true;
                }

                if (!isInDB)
                    // not in DB, insert into DB
                    CustomerManager.InsertCustomer(newC);

                // now new customer exist in DB, create session
                Session.Add("customer", newC);
                Response.Redirect("~/Lease.aspx");
            }

        }

        
        
    }
}