<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage.master" AutoEventWireup="true" CodeFile="~/Controller/ClassesCTR.aspx.cs" Inherits="View_Admin_Side_Classes" %>

<asp:Content ID="CH" ContentPlaceHolderID="ContentPlaceHolderHeader" runat="server">
    <style>
        th {
            color: white !important;
        }
    </style>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <br />
    <asp:GridView ID="GridView1" runat="server" DataKeyNames="id_classe" AllowPaging="true" Width="100%" ShowFooter="True"
        AutoGenerateColumns="False" GridLines="None" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
        PageSize="5" CssClass="mGrid" OnPageIndexChanging="GridView1_PageIndexChanging"
        OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing">
        <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
        <FooterStyle ForeColor="White" BackColor="red"></FooterStyle>
        <PagerStyle ForeColor="red" HorizontalAlign="Left" BackColor="White"></PagerStyle>
        <HeaderStyle ForeColor="white" Font-Bold="True" BackColor="red"></HeaderStyle>
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="InactiveLB" runat="server" Visible='<%# Convert.ToBoolean(Eval("active_classe").ToString()) %>' OnClientClick="return confirm(Are you sure you want to inactivate this class?')" CommandArgument='<%# Eval("id_classe")%>' Text="Inactivate" OnClick="InactiveLB_Click"></asp:LinkButton>
                    <asp:LinkButton ID="activeLB" runat="server" Visible='<%# Reverce(Eval("active_classe").ToString()) %>' OnClientClick="return confirm('Are you sure you want to active this class?')" CommandArgument='<%# Eval("id_classe")%>' Text="Activate" OnClick="activeLB_Click"></asp:LinkButton>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:LinkButton ID="addLB" ForeColor="White" runat="server" Text="Add" OnClick="addLB_Click"></asp:LinkButton>
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <asp:Label ID="nom_classe" runat="server" Text='<%# Eval("nom_classe").ToString() %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="id_classe" runat="server" Text='<%# Eval("id_classe").ToString() %>' Visible="false"></asp:Label>
                    <asp:TextBox ID="nom_classeEDIT" runat="server" Text='<%# Eval("nom_classe").ToString() %>' placeholder="Name"></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="nom_classeF" runat="server" placeholder="Name"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Image URL">
                <ItemTemplate>
                    <asp:Image runat="server" ImageUrl='<%# "images/" + Eval("image_classe").ToString() %>' AlternateText='<%# Eval("image_classe").ToString() %>' Width="150" Height="100" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:FileUpload runat="server" ID="imgFU" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:FileUpload runat="server" ID="imgFUF" />
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Set Timing">
                <ItemTemplate>
                    <asp:LinkButton ID="timingLB" runat="server" CommandArgument='<%# Eval("id_classe") %>' Text="Timing" OnClick="timingLB_Click"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:CommandField ShowEditButton="True" />
        </Columns>

        <EmptyDataTemplate>
            <tr>
                <th scope="col">Name</th>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="nom_classe" runat="server" placeholder="Name"></asp:TextBox>
                </td>
            </tr>
        </EmptyDataTemplate>
    </asp:GridView>
</asp:Content>

