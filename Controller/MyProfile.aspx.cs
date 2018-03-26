using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_MyProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Session["user"] as string))
        {
            Redirect("Home.aspx");
        }
    }
    protected void Redirect(string path)
    {
        Response.Redirect(path, true);
        Context.ApplicationInstance.CompleteRequest();
    }
    protected DataTable getUser()
    {
        return DB.selectUser(Session["user"].ToString());
    }
}
