<%@ Page Language="C#" MasterPageFile="~/App/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HandleErrorInfo>" %>

<asp:Content ID="errorTitle" ContentPlaceHolderID="TitleContent" runat="server">
 Adam.Kahtava.com / AdamDotCom - Oh no!! Abort, abort. Something went horribly wrong.
</asp:Content>

<asp:Content ID="errorContent" ContentPlaceHolderID="MainContent" runat="server">
  <h2>
    Sorry, an error occurred while processing your request.
  </h2>
</asp:Content>
