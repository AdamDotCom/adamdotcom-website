<%@ Page Language="C#" MasterPageFile="~/App/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="AdamDotCom.Website.App.Controllers"%>
<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Adam.Kahtava.com / AdamDotCom - Resume / Curriculum Vitae / Software Developer / Web Developer 
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
<script>

    $(function() {
        function postAsync() {
            $.post('/contact/', $($('form[name="contact"]')).serialize()); 
            return false;
        }
        $('input:submit').click(postAsync);
    });

</script>
<div id="contact">
    <%--form_remote_tag--%>
    <% using (Html.BeginForm("index", "contact", FormMethod.Post, new { name = "contact" }))
        { %>
        <%= Html.TextBox("name") %><br />
        <%= Html.TextBox("email") %><br />
        <%= Html.TextBox("subject", "Hey Adam, I was on your site and...") %><br />
        <%= Html.TextBox("message") %><br />
        <%= Html.AntiForgeryToken() %>
        <input title="Submit" type="submit" value="Send" />
    <%  } %>
</div>
</asp:Content>