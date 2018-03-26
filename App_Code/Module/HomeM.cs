using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Home
/// </summary>
public class HomeM
{
    public HomeM()
    {
        //
        // TODO: Add constructor logic here
        //
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
                    cmd.CommandText = "select * from Classes;";
                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = cmd;
                    sda.Fill(dt);
                }
            }
        }
        catch (Exception ex){}

        return dt;
    }

    public static DataTable SelectClassesTiming(String id_Classe)
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
                    cmd.CommandText = "select * from Classes as c, timing as t where c.id_classe = t.id_classe and t.id_classe = @id_Classe;";
                    cmd.Parameters.AddWithValue("id_Classe", id_Classe);
                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = cmd;
                    sda.Fill(dt);
                }
            }
        }
        catch (Exception ex) { }

        return dt;
    }
}