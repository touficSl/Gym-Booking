using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Settings : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request["C"].ToString() == "" || string.IsNullOrEmpty(Session["user"] as string))
            {
                Redirect("Home.aspx");
            }
        }
        catch (Exception ex)
        {
            Redirect("Home.aspx");
        }
        MyProgramsM.DeleteProgram(Int32.Parse(Request["C"].ToString()));
        Redirect("MyPrograms.aspx");
    }

    protected void Redirect(string path)
    {
        Response.Redirect(path, true);
        Context.ApplicationInstance.CompleteRequest();
    }
}