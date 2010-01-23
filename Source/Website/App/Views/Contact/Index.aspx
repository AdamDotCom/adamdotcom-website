<%@ Page Language="C#" MasterPageFile="~/App/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage"
 %>
<%@ Import Namespace="AdamDotCom.Common.Website"%>
<%@ Import Namespace="AdamDotCom.Website.App.Controllers"%>

<asp:Content ID="titleContent" ContentPlaceHolderID="TitleContent" runat="server">
  Contact Me &raquo; Adam.Kahtava.com / AdamDotCom
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
    #contact input[type=text], #contact textarea, #contact #body_wrap
    {
      margin: 5px;
      float: left;
      background-color: #F7F7F7;
      font-family: Arial, Sans-Serif;
      font-size: 13px;
    }
    #contact input[type=submit]
    {
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
    #contact #form-footer
    {
      padding-left: 90px;
      position:relative; 
      text-align:center; 
      clear:both;
    }
    #contact #form-footer img, #contact #form-footer input
    {
      display: block;
      margin-left: auto;
      margin-right: auto;
    }
  </style>
  <%= Html.StylesheetLinkTag("jquery.modaldialog") %>
  <%= Html.JavaScriptIncludeTag("htmlbox.min", "jquery.modaldialog") %>
  <script>
    $(function() {
      $('input:submit').click(function() {
        var contactFormItems = $('form[name="contact"]').find('input[type=submit]');
        contactFormItems.attr('disabled', 'disabled');
        $('#spinner').toggle();
        
        $.ajax({
          type: 'POST',
          url: '/contact/send',
          data: $('form[name="contact"]').serialize(),
          complete: function(xhr, textStatus) {
            if (textStatus === 'success') {
              window.location = '/contact/thanks';
            }
            else {
              contactFormItems.removeAttr('disabled')
              $('#spinner').toggle();
              
              $.modaldialog.prompt(xhr.responseText, {
                title: 'Oh-oh!',
                timeout: 20
              });
            }
          }
        });
        return false;
      });      

      $("#body").css("height", "250px").css("width", "445px").htmlbox({
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
    Hey! Send me a message, drop me a line. 
    <% using (Html.BeginForm("send", "contact", FormMethod.Post, new { name = "contact" }))
      { %>
      <label for="name">Name</label><%= Html.TextBox("fromName", string.Empty, new { size = "50" })%>
      <label for="email"><span>Email</span></label><%= Html.TextBox("fromAddress", string.Empty, new { size = "50" })%>
      <label for="subject">Subject</label><%= Html.TextBox("subject", string.Empty, new { size = "50" })%>
      <label for="body"><span>Message</span></label><%= Html.TextArea("body", string.Empty, new { rows = "12", cols = "65" })%>
      <%= Html.AntiForgeryToken() %>
      <div id="form-footer">
        <input title="Submit" type="submit" value="Send" />
        <img id="spinner" src="/public/images/spinner.gif" alt="spinner" style="display: none;" />
        <div style="padding-top: 20px;"><strong>Privacy:</strong> I don’t collect, distribute, or sell e-mail addresses.</div>
      </div>
    <%  } %>
  </div>
</asp:Content>

<asp:Content ID="sidebarContent" ContentPlaceHolderID="SidebarContent" runat="server">
  <% Html.RenderPartial("_ContactBlock"); %>
</asp:Content>