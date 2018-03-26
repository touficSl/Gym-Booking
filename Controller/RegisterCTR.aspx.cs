using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        { 
            if (Request["I"].ToString() == "")
            {
                Redirect("Home.aspx");
            }
        }
        catch (Exception ex)
        {
            Redirect("Home.aspx");
        }
    }

    protected void Register_Click(object sender, EventArgs e)
    {
        try
        {
            User user = new User();
            user.Email = mail.Value;
            user.Name = name.Value;
            user.Pass = password.Value;
            if (tel.Value != "")
            {
                user.Tel = Int32.Parse(tel.Value);
            }
            user.Adress = Address.Value;
            user.Isadmin = false;

            if (Request["I"].ToString() == "0")
            {
                JustRegisterUserInfo(user);
                return;
            }
            if (Register(user, Request["I"].ToString()) == false)
            {
                Response.Write("<script>alert('This Email Exist');</script>");
            }
            else
            {
                Session["user"] = user.Email;
                Session["user_name"] = user.Name;
                Redirect("MyPrograms.aspx");
            }
        }
        catch (Exception ex) { }
    }

    public void JustRegisterUserInfo(User user)
    {
        if (Module.CheckIfUserEmailExist(user.Email) == false)
        {
            RegisterM.InsertUserInfo(user);
            Session["user"] = user.Email;
            Session["user_name"] = user.Name;
            Redirect("Home.aspx");
        }
        else
        {
            Response.Write("<script>alert('This Email Exist');</script>");
            return;
        }
    }

    public static bool Register(User user, String id_timing)
    {
        if (Module.CheckIfUserEmailExist(user.Email) == false)
        {
            RegisterM.InsertRegisterUserAndThisDance(user, id_timing);
            return true;
        }
        else
        {
            return false;
        }

    }
    protected void Redirect(string path)
    {
        Response.Redirect(path, true);
        Context.ApplicationInstance.CompleteRequest();
    }
}