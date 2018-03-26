using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SignInM
/// </summary>
public class SignInM
{
    public SignInM()
    {
    }

    public static void InsertThisDance(String email, String id_timing)
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
                    cmd.CommandText = "Select days from timing where id_timing = @id_timing";
                    cmd.Parameters.AddWithValue("id_timing", id_timing);
                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = cmd;
                    sda.Fill(dt);
                }

                int NbreOfDays = Int32.Parse(dt.Rows[0]["days"].ToString());
                DateTime today = DateTime.Now;
                DateTime endDate = today.AddDays(NbreOfDays);

                dt = new DataTable();
                String command = "insert into abonnement (email, startdate, enddate, id_timing) values (@email, @startdate, @enddate, @id_timing)";

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = command;
                    cmd.Parameters.AddWithValue("email", email); 
                    cmd.Parameters.AddWithValue("startdate", DateTime.Now);
                    cmd.Parameters.AddWithValue("enddate", endDate);
                    cmd.Parameters.AddWithValue("id_timing", id_timing); 
                    cmd.ExecuteNonQuery();
                } 
            }
        }
        catch (Exception ex) { }
    }

    public static bool CheckIfValidUserPass(String email, String pass)
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
                    cmd.CommandText = "select password from Client where email = @email;";
                    cmd.Parameters.AddWithValue("email", email);
                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = cmd;
                    sda.Fill(dt);

                    if (dt.Rows[0]["password"].ToString() == pass)
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

    public static String SelectUserName(String email)
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
                    cmd.CommandText = "select nom from Client where email = @email;";
                    cmd.Parameters.AddWithValue("email", email);
                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = cmd;
                    sda.Fill(dt);

                    return dt.Rows[0]["nom"].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            return "";
        }
    }
}