using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public static DataTable Classes()
    {
        return HomeM.SelectClasses();
    }

    public static DataTable ClassesTiming(String id_Classe)
    {
        return HomeM.SelectClassesTiming(id_Classe);
    }
}