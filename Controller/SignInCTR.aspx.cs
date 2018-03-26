using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SignIn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (!string.IsNullOrEmpty(Session["user"] as string))
            { 
                SignInM.InsertThisDance(Session["user"].ToString(), Request["I"].ToString());
                Redirect("MyPrograms.aspx");
            }

            if (Request["I"].ToString() == "")
            {
                Redirect("Home.aspx");
            }
        }
        catch (Exception ex){
            Redirect("Home.aspx");
        }
    }

    protected void Login_Click(object sender, EventArgs e)
    {
        try
        {
            if (CheckIfValidEmailAndPass(email.Value, pass.Text) == true)
            {
                if (Request["I"].ToString() != "0")
                {
                    SignInM.InsertThisDance(email.Value, Request["I"].ToString());
                }
                Session["user"] = email.Value;
                Session["user_name"] = GetUserName(email.Value);
                Redirect("MyPrograms.aspx");
            }
            else
            {
                Response.Write("<script>alert('This Email Exist or Invalid Email or pass');</script>");
            }
        }
        catch (Exception ex){}
    }

    public static bool CheckIfValidEmailAndPass(String email, String pass)
    {
        if (Module.CheckIfUserEmailExist(email) == true)
        {
            if (SignInM.CheckIfValidUserPass(email, pass) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    } 

    public static String GetUserName(String email)
    {
        return SignInM.SelectUserName(email);
    }

    protected void Redirect(string path)
    {
        Response.Redirect(path, true);
        Context.ApplicationInstance.CompleteRequest();
    }
}