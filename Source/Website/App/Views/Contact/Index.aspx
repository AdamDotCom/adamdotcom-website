<%@ Page Language="C#" MasterPageFile="~/App/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Adam.Kahtava.com / AdamDotCom - Resume / Curriculum Vitae / Software Developer / Web Developer 
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
<div id="contact">
    <%--form_remote_tag--%>
    <% using (Html.BeginForm()) { %>
        <%=Html.TextBox("name")%><br />
        <%=Html.TextBox("email")%><br />
        <%=Html.TextBox("message")%><br />
        <input title="Submit" type="submit" value="Send" />
    <% } %>
</div>
</asp:Content>