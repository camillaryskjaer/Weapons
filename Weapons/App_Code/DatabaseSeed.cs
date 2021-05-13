using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;


/// <summary>
/// Summary description for DatabaseSeed
/// </summary>
public class DatabaseSeed
{
    public DatabaseSeed()
    {
        //
        // TODO: Add constructor logic here
        //


    }


    public static void Seed()
    {

        var connString = "Data Source=(local);Initial Catalog=Master;Integrated Security=true";
        string txtDatabase = "weapons";



        //Drop databasen


        using (var conn = new System.Data.SqlClient.SqlConnection(connString))
        {

            bool IsExits = CheckDatabaseExists(conn, "weapons"); //Check database exists in sql server.

            if (IsExits)
            {
                String sqlCommandText = @"
                ALTER DATABASE " + txtDatabase + @" SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                DROP DATABASE [" + txtDatabase + "]";
                Debug.WriteLine("Dropping");
                var command = new System.Data.SqlClient.SqlCommand(sqlCommandText, conn);
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
            }


            Debug.WriteLine("Creating");
            String sqlcreate = "create database " + txtDatabase + ";";
            var cmd = new System.Data.SqlClient.SqlCommand(sqlcreate, conn);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();

        }
        createTables();
      
    }
    private static void createTables()
    {
        string txtDatabase = "weapons";
        var connString = "Data Source=(local);Initial Catalog=" + txtDatabase + ";Integrated Security=true";
        using (var conn = new System.Data.SqlClient.SqlConnection(connString))
        {
            //test
            string sqlUserDBQuery = "create table users (userid int,username varchar(255),password varchar(255),firstname varchar(255));";
            using (SqlCommand sqlCmd = new SqlCommand(sqlUserDBQuery, conn))
            {
                sqlCmd.Connection.Open();
                sqlCmd.ExecuteNonQuery();
                sqlCmd.Connection.Close();

            }

            //insert user
            sqlUserDBQuery = "insert into users(userid,username,password,firstname) values(1,'camr','1234','Camilla')";
            using (SqlCommand sqlCmd = new SqlCommand(sqlUserDBQuery, conn))
            {
                sqlCmd.Connection.Open();
                sqlCmd.ExecuteNonQuery();
                sqlCmd.Connection.Close();
                conn.Close();




            }

            //Create credit card stuff
            using (var c = new System.Data.SqlClient.SqlConnection(connString))
            {
                //test
                sqlUserDBQuery = "create table creditcard (number varchar(19),name varchar(255),expYear varchar(4),expMonth varchar(2), type varchar(255));";
                using (SqlCommand sqlCmd = new SqlCommand(sqlUserDBQuery, conn))
                {
                    sqlCmd.Connection.Open();
                    sqlCmd.ExecuteNonQuery();
                    sqlCmd.Connection.Close();
                }

                //insert user
                sqlUserDBQuery = "insert into creditcard(number,name,expYear,expMonth,type) values('4826118361776374','Mogens FlowerHorn','2022','01','Visa')";





                using (SqlCommand sqlCmd = new SqlCommand(sqlUserDBQuery, conn))
                {
                    sqlCmd.Connection.Open();
                    sqlCmd.ExecuteNonQuery();
                    sqlCmd.Connection.Close();
                    conn.Close();
                }

                sqlUserDBQuery = "insert into creditcard(number,name,expYear,expMonth,type) values('5230573972911967','Mikkel Sørensen','2023','01','Mastercard')";





                using (SqlCommand sqlCmd = new SqlCommand(sqlUserDBQuery, conn))
                {
                    sqlCmd.Connection.Open();
                    sqlCmd.ExecuteNonQuery();
                    sqlCmd.Connection.Close();
                    conn.Close();
                }

            }


            //Create weapons

            List<Product> prod = new List<Product>();
            prod.Add(new Product(-1, "Perico Pistol", "A deadly shot. Dont be precious. You wont scuff the titanium nitride finish.", "perico-pistol.png"));
            prod.Add(new Product(-1, "Combat Shotgun", "There''s only one semi-automatic shotgun with a fire rate that sets the LSFD alarm bells ringing, and you''re looking at it.", "combat-shotgun.png"));



            using (var c = new System.Data.SqlClient.SqlConnection(connString))
            {
                //test
                sqlUserDBQuery = "create table products (id INT IDENTITY(1,1),name varchar(255),description varchar(255),img varchar(255));";
                using (SqlCommand sqlCmd = new SqlCommand(sqlUserDBQuery, conn))
                {
                    sqlCmd.Connection.Open();
                    sqlCmd.ExecuteNonQuery();
                    sqlCmd.Connection.Close();
                }



                foreach (var item in prod)
                {
                    sqlUserDBQuery = "insert into products(name,description,img) values('" + item.Name + "','" + item.Desc + "','" + item.Img + "')";
                    using (SqlCommand sqlCmd = new SqlCommand(sqlUserDBQuery, conn))
                    {
                        sqlCmd.Connection.Open();
                        sqlCmd.ExecuteNonQuery();
                        sqlCmd.Connection.Close();
                        conn.Close();
                    }
                }



            }







        }




    }

    public static bool CheckDatabaseExists(SqlConnection tmpConn, string databaseName)
    {
        string sqlCreateDBQuery;
        bool result = false;

        try
        {
            sqlCreateDBQuery = string.Format("SELECT database_id FROM sys.databases WHERE Name = '{0}'", databaseName);
            using (SqlCommand sqlCmd = new SqlCommand(sqlCreateDBQuery, tmpConn))
            {
                tmpConn.Open();
                object resultObj = sqlCmd.ExecuteScalar();
                int databaseID = 0;
                if (resultObj != null)
                {
                    int.TryParse(resultObj.ToString(), out databaseID);
                }
                tmpConn.Close();
                result = (databaseID > 0);
            }
        }
        catch (Exception)
        {
            result = false;
        }
        return result;
    }

}