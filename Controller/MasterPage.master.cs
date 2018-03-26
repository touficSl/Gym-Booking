using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Session["user"] as string))
        {
            welc.Visible = false;
            logout.Visible = false;
            myprof1.Visible = false;
            myprof2.Visible = false;
            myprof.Visible = false;
        }
        else
        {
            welc.Visible = true;
            welc.InnerText = "Welcome " + Session["user_name"];
            logout.Visible = true;
            myprof1.Visible = true;
            myprof2.Visible = true;
            myprof.Visible = true;
        }
    }

    protected void logout_ServerClick(object sender, EventArgs e)
    {
        Session["user"] = "";
        Session["user_name"] = "";
        Redirect("Home.aspx");
    }
    protected void Redirect(string path)
    {
        Response.Redirect(path, true);
        Context.ApplicationInstance.CompleteRequest();
    }
}
