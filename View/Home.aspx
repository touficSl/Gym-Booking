<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage.master" AutoEventWireup="true" CodeFile="~/Controller/HomeCTR.aspx.cs" Inherits="Home" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
    <div style="margin-left:30px" class="container">
        <img src="images/Schedule.png" style="width:100%;height:500px;">
        <br />
        <br />
        <div class="v-links-list container"> 
	        <ul>
               <%  DataTable dt = Classes();
                   foreach (DataRow row in dt.Rows)
                   { %>  
		                <li><a href="#<% Response.Write(row["nom_classe"].ToString().ToUpper().Replace(" ", "")); %>" style="color:red"><% Response.Write(row["nom_classe"].ToString().ToUpper()); %></a></li>
                <% } %>
	        </ul>
        </div>

        <br />

       <%  
            foreach (DataRow row in dt.Rows)
            { %>  
                <fieldset  id="<% Response.Write(row["nom_classe"].ToString().ToUpper().Replace(" ", "")); %>" class="container" >
                    <legend style="color:red"><% Response.Write(row["nom_classe"].ToString().ToUpper()); %></legend>
                        <table style ="width:100%">
                            <tr>
                                <th style ="width:20%">
                                    <div id="img">
                                        <img src="images/<% Response.Write(row["image_classe"].ToString()); %>" alt="<% Response.Write(row["nom_classe"].ToString().ToUpper()); %>" style="width:304px;height:228px;">
                                    </div>
                                </th>
                                <th style ="width:20%">Days</th>
                                <th style ="width:20%">Month</th>
                                <th style ="width:20%">Cost</th>
                                <th style ="width:5%"></th>
                                <th style ="width:15%"></th>
                            </tr>
                        
                        <%  DataTable dt1 = ClassesTiming(row["id_classe"].ToString());
                        foreach (DataRow row1 in dt1.Rows)
                        { %>  
                            <tr>
                                <td></td>
                                <td>
                                    <div>
                                    <% Response.Write(row1["days"].ToString()); %>
                                    </div>
                                </td>
                                <td>
                                    <div>
                                        <% if (row1["month"].ToString() != "") { Response.Write(row1["month"].ToString()); } else { Response.Write("<strong style='color:red'>X</strong>"); }%>
                                    </div>
                                </td>
                                <td>
                                    <div>
                                        <% Response.Write(row1["cost"].ToString()); %>
                                    </div>
                                </td>
                                <th>$</th>
                                <th>
                                    <a href="SignIn.aspx?I=<% Response.Write(row1["id_timing"].ToString()); %>" class="btn">REGISTER</a>
                                </th>
                            </tr>
                        <% } %>
                        </table>
                </fieldset>
    
         <% } %>
    </div>
    <script>
        function RedirectNewWindow(Url) {
            window.open(Url, '_newtab');
        }
    </script>
</asp:Content>

