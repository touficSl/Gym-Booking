<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/View/MasterPage.master" CodeFile="~/Controller/MyProfile.aspx.cs" Inherits="View_MyProfile" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
   <!-- DisplayProfile() -->
     <%  DataTable dt = getUser();  %>  
    <table>
       <tr>
           <th>Name</th>
           <td><% Response.Write(dt.Rows[0]["nom"].ToString()); %></td>
       </tr>
        <tr>
           <th>Adress</th>
           <td><% Response.Write(dt.Rows[0]["adress"].ToString()); %></td>
       </tr>
        <tr>
           <th>Email</th>
           <td><% Response.Write(dt.Rows[0]["email"].ToString()); %></td>
       </tr>
        <tr>
           <th>Tel</th>
           <td><% Response.Write(dt.Rows[0]["teleph"].ToString()); %></td>
       </tr>
    </table>

</asp:Content>
