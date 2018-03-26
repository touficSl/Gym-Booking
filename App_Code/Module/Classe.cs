using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Classe
/// </summary>
public class Classe
{
    private int id;
    private String name;
    private String imgURL;

    public int Id
    {
        get
        {
            return this.id;
        }
        set
        {
            this.id = value;
        }
    }
    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            this.name = value;
        }
    }
    public string ImgURL
    {
        get
        {
            return this.imgURL;
        }
        set
        {
            this.imgURL = value;
        }
    }
    public Classe()
    { 
    }
}