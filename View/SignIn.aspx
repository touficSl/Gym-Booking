<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Controller/SignInCTR.aspx.cs" Inherits="SignIn" %>

<!DOCTYPE html>
<html >
  <head>
    <meta charset="UTF-8">
    <title>LOGIN</title>
    <style>
        .send { 
            background: red!important;
        }
    </style>
        <link rel="stylesheet" href="JS_CSS/css/Loginstyle.css">
  </head>

  <body>
    <form runat="server">
        <asp:ScriptManager runat="server"/>
        <div class="main-wrap">
            <div class="login-main">
                <input type="text" runat="server" id="email" placeholder="Email" class="box1 border1"/>
                <asp:TextBox TextMode="Password" runat="server" id="pass" placeholder="password" class="box1 border2"/>
                <asp:Button class="send" runat="server" onclick="Login_Click" Text="Go"/>
                <%--<p>Forgot Your Password? <a href="#">click here</a></p>--%>    
                <p><a href="Register.aspx?I=<% Response.Write(Request["I"].ToString()); %>" style ="color :red">REGISTER</a></p>
            </div>
        
        </div>
    </form>
  </body>
</html>