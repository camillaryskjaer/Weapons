using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

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

    private static void createTables() {
        string txtDatabase = "weapons";
        var connString = "Data Source=(local);Initial Catalog="+txtDatabase+";Integrated Security=true";
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