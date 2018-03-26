using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Admin_Side_Classes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BindGrid();
    } 

    protected void BindGrid()
    {
        GridView1.DataSource = ClassesM.SelectClasses();
        GridView1.DataBind();
    }

    public bool Reverce(String active)
    {
        bool rev = !Convert.ToBoolean(active);
        return rev;
    }

    protected void InactiveLB_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        ClassesM.UpdateActivation("INACTIVATION", Int32.Parse(lb.CommandArgument));
        BindGrid();
    }

    protected void activeLB_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        ClassesM.UpdateActivation("ACTIVATION", Int32.Parse(lb.CommandArgument));
        BindGrid();
    }

    protected void timingLB_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        Redirect("Timing.aspx?C=" + lb.CommandArgument);
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox nom_classe = (TextBox)GridView1.Rows[e.RowIndex].FindControl("nom_classeEDIT");
        Label id_classe = (Label)GridView1.Rows[e.RowIndex].FindControl("id_classe");
        FileUpload imgFU = (FileUpload)GridView1.Rows[e.RowIndex].FindControl("imgFU");
        Classe c = new Classe();
        c.Id = Int32.Parse(id_classe.Text);
        c.ImgURL = imgFU.FileName;
        c.Name = nom_classe.Text;

        if (imgFU.FileName != "" && (imgFU.FileName.Contains(".jpg") || imgFU.FileName.Contains(".png")))
        {
            ClassesM.UpdateClasse(c);
            GridView1.EditIndex = -1;
            BindGrid();
        }
        else
        {
            Response.Write("<script>alert('Please select an image (.jpg or .png)');</script>");
        }
    }

    protected void addLB_Click(object sender, EventArgs e)
    {

    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        BindGrid();
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        BindGrid();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        BindGrid();
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
    }
    protected void Redirect(string path)
    {
        Response.Redirect(path, true);
        Context.ApplicationInstance.CompleteRequest();
    } 
}