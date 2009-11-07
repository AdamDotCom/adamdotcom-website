<%@ Page Language="C#" MasterPageFile="~/App/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HandleErrorInfo>" %>
<%@ Import Namespace="AdamDotCom.Website.App"%>

<asp:Content ID="errorTitle" ContentPlaceHolderID="TitleContent" runat="server">
 Adam.Kahtava.com / AdamDotCom - Oh no!! Abort, abort. Something went horribly wrong.
</asp:Content>

<asp:Content ID="errorContent" ContentPlaceHolderID="MainContent" runat="server">
  <h2>
    Sorry, an error occurred while processing your request.
  </h2>
  <p style="padding-top: 40px; line-height: 20pt;">
    Send me an email (<a href="mailto:<%= MyWebPresence.EmailAccount %>?subject=I found this ugly error on your site, it might be a bug and ..."><%= MyWebPresence.EmailAccount %></a>) and tell me more about this error.<br />
    Thanks,<br />
    &nbsp;&nbsp;&nbsp;-Adam
  </p> 
</asp:Content>

<asp:Content ID="sidebarContent" ContentPlaceHolderID="SidebarContent" runat="server">
  <% Html.RenderPartial("_ContactBlock"); %>
</asp:Content>