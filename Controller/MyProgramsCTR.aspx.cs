using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_MyClasses : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Session["user"] as string))
        {
            Redirect("signIn.aspx?I=0");
        }
    }

    public static DataTable ListPrograms(String user_email, String id_classe)
    {
        return MyProgramsM.SelectPrograms(user_email, id_classe);
    }

    public static DataTable ListMyClassesPrograms(String user_email)
    {
        return MyProgramsM.SelectHisClasses(user_email);
    }
    protected void Redirect(string path)
    {
        Response.Redirect(path, true);
        Context.ApplicationInstance.CompleteRequest();
    }
}