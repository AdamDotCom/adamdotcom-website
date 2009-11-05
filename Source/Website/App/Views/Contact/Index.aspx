<%@ Page Language="C#" MasterPageFile="~/App/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="AdamDotCom.Common.Website"%>
<%@ Import Namespace="AdamDotCom.Website.App.Controllers"%>

<asp:Content ID="titleContent" ContentPlaceHolderID="TitleContent" runat="server">
    Adam.Kahtava.com / AdamDotCom - Contact Me
</asp:Content>

<asp:Content ID="headContent" ContentPlaceHolderID="HeadContent" runat="server">
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
        #contact input[type=text], #contact textarea
        {
	        border: solid 1px #7B7542;
            padding: 4px;
        }
        #contact input[type=text], #contact textarea, #contact #message_wrap
        {
	        margin: 5px;
            float: left;
            background-color: #F7F7F7;
            font-family: Arial, Sans-Serif;
            font-size: 13px;
        }
        #contact input[type=submit]
        {
            clear: both;
            display: block;	
            margin-left: 330px;
            font-size: 26px;
        }
        #contact form span
        {
        	font-weight: bold;
        }
        #contact form
        {
        	padding: 20px 0px 20px 0px;
        }
    </style>
    <%= Html.JavaScriptIncludeTag("htmlbox.min") %>
    <script>
        $(function() {
            $('input:submit').click(function() {
                $.ajax({
                    type: 'POST',
                    url: '/contact-me',
                    data: $($('form[name="contact"]')).serialize(),
                    complete: function(xhr, textStatus) {
                        if (textStatus === "success") {
                            window.location = 'contact/thanks';
                        }
                        else {
                            alert(xhr.responseText);
                        }
                    }
                });
                return false;
            });          

            $("#message").css("height", "250px").css("width", "469px").htmlbox({
                idir: "/public/images/htmlbox",
                toolbars: [
                   ["paste", "separator_dots", "bold", "italic", "underline", "link", "unlink", "image", "code"]
                ],
                icons: "silk",
                skin: "grey"
            });
        });
    </script>
</asp:Content>

<asp:Content ID="mainContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="contact">
        Hey! Send me a message, drop me a line... 
        <% using (Html.BeginForm("index", "contact", FormMethod.Post, new { name = "contact" }))
            { %>
            <label for="name">Name</label><%= Html.TextBox("name", string.Empty, new { size = "50" }) %>
            <label for="email"><span>Email</span></label><%= Html.TextBox("email", string.Empty, new { size = "50" })%>
            <label for="subject">Subject</label><%= Html.TextBox("subject", string.Empty, new { size = "50" })%>
            <label for="message"><span>Message</span></label><%= Html.TextArea("message", string.Empty, new { rows = "12", cols = "65" })%>
            <%= Html.AntiForgeryToken() %>
            <input title="Submit" type="submit" value="Send" />
        <%  } %>
        <div style="padding-left: 180px;"><strong>Privacy:</strong> I don’t collect, distribute, or sell e-mail addresses.</div>
    </div>
</asp:Content>

<asp:Content ID="sidebarContent" ContentPlaceHolderID="SidebarContent" runat="server">
    <% Html.RenderPartial("_ContactBlock"); %>
</asp:Content>