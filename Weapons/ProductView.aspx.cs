﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        if (Page.IsPostBack)
            return;

        if (!string.IsNullOrEmpty(Request.QueryString["id"]))
        {
            string searchTerm = Request.QueryString["id"];

            Debug.WriteLine("Søgeterm:"  +searchTerm);


            using (UserRepository us = new UserRepository())
            {

               Product p = us.GetProduct(searchTerm);

                if ((p != null) )
                {
                    ProductHeader.Text = p.Name;
                    Image1.ImageUrl = "assets/img/" + p.Img;
                    Description.Text = p.Desc;

                }
            }


        }
    }

    
}