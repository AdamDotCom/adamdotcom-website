<%@ Page Language="C#" MasterPageFile="~/App/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="AdamDotCom.Amazon.Domain"%>
<%@ Import Namespace="AdamDotCom.Website.App.Models"%>
<%@ Import Namespace="AdamDotCom.Common.Website" %>
<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><% foreach (Product item in ViewData.Get<HaveReadList>())
           { %>
           <%= ((Product)item).Title %><br />
           <% } %></h2>
    <p>
        To learn more about ASP.NET MVC visit <a href="http://asp.net/mvc" title="ASP.NET MVC Website">http://asp.net/mvc</a>.
    </p>
</asp:Content>
