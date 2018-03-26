using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RegisterM
/// </summary>
public class RegisterM
{
    public RegisterM()
    {
    }
    public static void InsertRegisterUserAndThisDance(User user, String id_timing)
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
                String command = "insert into Client (email, nom, adress, teleph, isadmin, password) values (@email, @nom, @adress, @teleph, @isadmin, @password);";
                command += "insert into abonnement (email, startdate, enddate, id_timing) values (@email, @startdate, @enddate, @id_timing)";

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = command;
                    cmd.Parameters.AddWithValue("email", user.Email);
                    cmd.Parameters.AddWithValue("nom", user.Name);
                    cmd.Parameters.AddWithValue("adress", user.Adress);
                    cmd.Parameters.AddWithValue("password", user.Pass);
                    cmd.Parameters.AddWithValue("teleph", user.Tel);
                    cmd.Parameters.AddWithValue("isadmin", user.Isadmin);
                    cmd.Parameters.AddWithValue("startdate", DateTime.Now);
                    cmd.Parameters.AddWithValue("enddate", endDate);
                    cmd.Parameters.AddWithValue("id_timing", id_timing);
                    cmd.ExecuteNonQuery();
                } 
            }
        }
        catch (Exception ex) { }
    } 

    public static void InsertUserInfo(User user)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(DB.connection))
            {
                con.Open();
                String command = "insert into Client (email, nom, adress, teleph, isadmin, password) values (@email, @nom, @adress, @teleph, @isadmin, @password);";

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = command;
                    cmd.Parameters.AddWithValue("email", user.Email);
                    cmd.Parameters.AddWithValue("nom", user.Name);
                    cmd.Parameters.AddWithValue("password", user.Pass);
                    cmd.Parameters.AddWithValue("adress", user.Adress);
                    cmd.Parameters.AddWithValue("teleph", user.Tel);
                    cmd.Parameters.AddWithValue("isadmin", user.Isadmin);
                    cmd.ExecuteNonQuery();
                } 
            }
        }
        catch (Exception ex) { }
    }
}