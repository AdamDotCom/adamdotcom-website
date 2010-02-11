<%@ Page Language="C#" MasterPageFile="~/App/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="AdamDotCom.Common.Website"%>
<%@ Import Namespace="AdamDotCom.Website.App.Controllers"%>

<asp:Content ID="titleContent" ContentPlaceHolderID="TitleContent" runat="server">
  Thanks! &raquo; Adam.Kahtava.com / AdamDotCom
</asp:Content>

<asp:Content ID="headContent" ContentPlaceHolderID="HeadContent" runat="server">
  <style type="text/css">
  </style>
</asp:Content>

<asp:Content ID="mainContent" ContentPlaceHolderID="MainContent" runat="server">
  <div id="contact">
    <h2>Thanks!</h2>
  </div>
</asp:Content>