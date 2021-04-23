using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    
    }

    protected void Login_Click(object sender, EventArgs e)
    {
        //Do stuff
        Debug.WriteLine("Log-in");


        //Test database
        using (UserRepository us = new UserRepository()) {

            User u = us.FindUser(UserName.Text,Password.Text);
            if (u != null) {

                //brugeren skal logges ind
                
                Response.Redirect("productlist.aspx");

            }
        } 

    }
}