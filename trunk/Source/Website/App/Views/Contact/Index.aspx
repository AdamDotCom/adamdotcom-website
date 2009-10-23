<%@ Page Language="C#" MasterPageFile="~/App/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="AdamDotCom.Website.App.Controllers"%>
<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Adam.Kahtava.com / AdamDotCom - Resume / Curriculum Vitae / Software Developer / Web Developer 
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
<style type="text/css">
    #contact label
    {
	    float: left;
	    width: 100px;
	    clear: both;
	    text-align: right;
	    padding: 4px 10px 4px 4px;
	    margin: 5px;
    }
    #contact input[type=text], #contact input[type=textarea]
    {
    	border: solid 1px #7B9EBD;
        padding: 4px;
    }
    #contact input[type=text], #contact input[type=textarea], #contact #message_wrap
    {
    	margin: 5px;
	    float: left;
	    background-color: #D6E3F7;
        font-family: Arial, Sans-Serif;
        font-size: 13px;
    }
    #contact input[type=submit]
    {
	    clear: both;
        display: block;	
        margin-left: 250px;
    }
</style>
<script src="http://remiya.com/demos/htmlbox-4.0/htmlbox.min.js"></script>
<script>
    $(function() {
        function postAsync() {
            $.post('/contact/', $($('form[name="contact"]')).serialize());
            return false;
        }
        $('input:submit').click(postAsync);

        var hb_silk_icon_set_default = $("#message").css("height", "250px").css("width", "450px").htmlbox({
            idir: "/public/images/htmlbox",
            toolbars: [
               ["paste", "separator_dots", "bold", "italic", "underline", "link", "unlink", "image", "code"]
            ],
            icons: "silk",
            skin: "blue"
        });

        $('#contact input[type=text]').attr('size', '50');


    });
</script>
<div id="contact">
    <%--form_remote_tag--%>
    <% using (Html.BeginForm("index", "contact", FormMethod.Post, new { name = "contact" }))
        { %>
        <label for="name">Name</label><%= Html.TextBox("name") %>
        <label for="email">Email</label><%= Html.TextBox("email") %>
        <label for="subject">Subject</label><%= Html.TextBox("subject") %>
        <label for="message">Message</label><%= Html.TextArea("message") %>
        <%= Html.AntiForgeryToken() %>
        <input title="Submit" type="submit" value="Send" />
    <%  } %>
</div>
</asp:Content>