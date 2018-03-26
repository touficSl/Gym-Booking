using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClassesM
/// </summary>
public class ClassesM
{
    public ClassesM()
    {
    }

    public static DataTable SelectClasses()
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
                    cmd.CommandText = "select * from Classes";
                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = cmd;
                    sda.Fill(dt);
                }
            }
        }
        catch (Exception ex) { }

        return dt;
    }

    public static void UpdateActivation(String index, int id_classe)
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
                    cmd.CommandText = "Update Classes set active_classe = @active_classe where id_classe = @id_classe";
                    if (index == "ACTIVATION")
                    {
                        cmd.Parameters.AddWithValue("active_classe", true);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("active_classe", false);
                    }
                    cmd.Parameters.AddWithValue("id_classe", id_classe);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex) { }
    }

    public static void UpdateClasse(Classe c)
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
                    cmd.CommandText = "Update Classes set nom_classe = @nom_classe, image_classe = @image_classe where id_classe = @id_classe";
                    cmd.Parameters.AddWithValue("nom_classe", c.Name);
                    cmd.Parameters.AddWithValue("image_classe", c.ImgURL);
                    cmd.Parameters.AddWithValue("id_classe", c.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex) { }
    }
}