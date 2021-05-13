using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserRepository
/// </summary>
public class UserRepository : IDisposable
{
    SqlConnection conn;
    public UserRepository()
    {
        var connString = "Data Source=(local);Initial Catalog=weapons;Integrated Security=true";

        conn = new System.Data.SqlClient.SqlConnection(connString);
        conn.Open();
    }

    public List<Product> GetAllProduct()
    {
        string s = "select * from products";

        Product p = null;
        List<Product> prod = new List<Product>();
        using (SqlCommand sqlCommand = new SqlCommand(s, conn))
        {

            using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
            {
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {

                        p = new Product(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3));
                        prod.Add(p);
                    }
                }
               

                    return prod;
            }
        }
        return null;
    }

    public Product GetProduct(object id)
    {
        string s = "select * from products where id="+id.ToString();

        Product p = null;


        Debug.WriteLine(s);
        using (SqlCommand sqlCommand = new SqlCommand(s, conn))
        {

            using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
            {
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {

                        p = new Product(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3));
                      
                    }
                }


                return p;
            }
        }
        return null;
    }



    /// <summary>
    /// 
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns>null if no user exist</returns>
    public User FindUser(string username, string password)
    {

        string selectU = "select username,password from users where username='" + username + "' and password='" + password + "'";
        User u = null;
        using (SqlCommand sqlCommand = new SqlCommand(selectU, conn))
        {

            using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
            {
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {

                        u = new User(dataReader.GetString(0), dataReader.GetString(1));
                        return u;
                    }
                }
                else
                    return null;
            }
        }
        return null;
    }


    public void Dispose()
    {
        if (conn != null)
            conn.Close();

    }
}