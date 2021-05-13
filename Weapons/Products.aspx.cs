using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Products : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        
  using (UserRepository us = new UserRepository())
        {

            List<Product> p = us.GetAllProduct();

            if ((p != null) && (p.Count > 0))
            {

                Repeater1.DataSource = p;
                Repeater1.DataBind();

            }
        }


    }
}