<%@ Page Language="C#" MasterPageFile="~/App/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HandleErrorInfo>" %>
<%@ Import Namespace="AdamDotCom.Website.App"%>

<asp:Content ID="errorTitle" ContentPlaceHolderID="TitleContent" runat="server">
 Adam.Kahtava.com / AdamDotCom - Oh no!! Abort, abort. Something went horribly wrong.
</asp:Content>

<asp:Content ID="errorContent" ContentPlaceHolderID="MainContent" runat="server">
  <h2>
    Sorry, an error occurred while processing your request.
  </h2>
  <p>
    Send me an email <a href="mailto:<%= MyWebPresence.EmailAccount %>?subject=I got this horrible error on your site and ..."><%= MyWebPresence.EmailAccount %></a> and tell me more about this error.<br />
    Thanks, <br />
    &nbsp;&nbsp;-Adam
  </p> 
</asp:Content>

<asp:Content ID="sidebarContent" ContentPlaceHolderID="SidebarContent" runat="server">
  <% Html.RenderPartial("_ContactBlock"); %>
</asp:Content>