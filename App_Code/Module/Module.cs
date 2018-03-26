using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Module
/// </summary>
public class Module
{
    public Module()
    {
    }
    public static bool CheckIfUserEmailExist(String email)
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
                    cmd.CommandText = "select email from Client where email = @email;";
                    cmd.Parameters.AddWithValue("email", email);
                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = cmd;
                    sda.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        return true; //exist
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    } 
}