using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for User
/// </summary>
public class User
{
    public string UserName { get; private set; }
    public string Password { get; private set; }
    public User(string username, string password)
    {
        this.UserName = username;
        this.Password = password;
        //
        // TODO: Add constructor logic here
        //


    }
}