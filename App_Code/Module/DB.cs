using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DB
/// </summary>
public class DB
{ 
    public static string connection = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;

    public static DataTable selectUser(String email)
    {
        DataTable dt = new DataTable();

        try
        {
            using (SqlConnection con = new SqlConnection(DB.connection))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    con.Open();

                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from Client where email = @email;";
                    cmd.Parameters.AddWithValue("email", email);
                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = cmd;
                    sda.Fill(dt);
                }
            }
        }
        catch (Exception ex)
        {
        }
        return dt;
    }
}