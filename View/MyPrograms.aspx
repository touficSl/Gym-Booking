<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage.master" AutoEventWireup="true" CodeFile="~/Controller/MyProgramsCTR.aspx.cs" Inherits="View_MyClasses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
    <div style="margin-left:30px" class="container">
       <%   

           DataTable dt = ListMyClassesPrograms(Session["user"].ToString());
           foreach (DataRow row in dt.Rows)
           { %>  
                <fieldset id="<% Response.Write(row["nom_classe"].ToString().ToUpper().Replace(" ", "")); %>" class="container">
                    <legend style="color:red"><% Response.Write(row["nom_classe"].ToString().ToUpper()); %></legend>
                        <table style="width:100%">
                            <tr>
                                <th>
                                    <div id="img">
                                        <img src="images/<% Response.Write(row["image_classe"].ToString()); %>" alt="<% Response.Write(row["nom_classe"].ToString().ToUpper()); %>" style="width:304px;height:228px;">
                                    </div>
                                </th>
                                <th>Days</th>
                                <th>Month</th>
                                <th>Start Date</th>
                                <th>End Date</th>
                                <th>Cost</th>
                            </tr>
                        
                        <%  DataTable dt1 = ListPrograms(Session["user"].ToString(), row["id_classe"].ToString());
                            Decimal total = 0;
                            foreach (DataRow row1 in dt1.Rows)
                            {
                                total += Convert.ToDecimal(row1["cost"].ToString());
                                %>  
                            <tr>
                                <td></td>
                                <td>
                                    <div>
                                    <% Response.Write(row1["days"].ToString()); %>
                                    </div>
                                </td>
                                <td>
                                    <div>
                                        <% Response.Write(row1["month"].ToString()); %>
                                    </div>
                                </td>
                                <td>
                                    <div>
                                        <% Response.Write(row1["startdate"].ToString()); %>
                                    </div>
                                </td>
                                <td>
                                    <div>
                                        <% Response.Write(row1["enddate"].ToString()); %>
                                    </div>
                                </td>
                                <td>
                                    <div>
                                        <% Response.Write(row1["cost"].ToString()); %>
                                    </div>
                                </td>
                                <th>$</th> 
                                <th>
                                    <img src="images/x.png" width="15" height="15" onclick="Redirect('Settings.aspx?C=<% Response.Write(row1["id_abn"].ToString()); %>')" />
                                </th> 
                            </tr>
                        <% } %>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>

                                <th>Total</th>
                                <th><% Response.Write(total); %></th>
                                <th>$</th>
                            </tr>
                        </table>
                </fieldset>
    
         <% } %>
    </div>
    <br />
    <br /> 
</asp:Content>

