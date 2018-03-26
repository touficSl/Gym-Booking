using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Uer
/// </summary>
public class User
{
    private String email;
    private String name;
    private String pass;
    private String adress;
    private int tel;
    private bool isadmin;
    
    public User()
    { 
    }

    public string Email
    {
        get
        {
            return this.email;
        }
        set
        {
            this.email = value;
        }
    }

    public string Pass
    {
        get
        {
            return this.pass;
        }
        set
        {
            this.pass = value;
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

    public string Adress
    {
        get
        {
            return this.adress;
        }
        set
        {
            this.adress = value;
        }
    }

    public int Tel
    {
        get
        {
            return this.tel;
        }
        set
        {
            this.tel = value;
        }
    }

    public bool Isadmin
    {
        get
        {
            return this.isadmin;
        }
        set
        {
            this.isadmin = value;
        }
    }

    
}