using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MyProgramsM
/// </summary>
public class MyProgramsM
{
    public MyProgramsM()
    {
    }

    public static DataTable SelectHisClasses(String user_email)
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
                    cmd.CommandText = "select Distinct nom_classe, id_classe, image_classe from View_MyPrograms where email = @email;";
                    cmd.Parameters.AddWithValue("email", user_email);
                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = cmd;
                    sda.Fill(dt);
                }
            }
        }
        catch (Exception ex) { }

        return dt;
    }

    public static DataTable SelectPrograms(String user_email, String id_classe)
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
                    cmd.CommandText = "select * from View_MyPrograms where email = @email and id_classe = @id_classe order by startdate desc;";
                    cmd.Parameters.AddWithValue("email", user_email);
                    cmd.Parameters.AddWithValue("id_classe", id_classe);
                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = cmd;
                    sda.Fill(dt);
                }
            }
        }
        catch (Exception ex) { }

        return dt;
    
    }

    public static void DeleteProgram(int id_abn)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(DB.connection))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    con.Open();

                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "delete from abonnement where id_abn = @id_abn";
                    cmd.Parameters.AddWithValue("id_abn", id_abn);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex) { }
    }
    } 