<%@ Page Language="C#" MasterPageFile="~/App/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="AdamDotCom.Amazon.Service.Proxy"%>
<%@ Import Namespace="AdamDotCom.Website.App.Models"%>
<%@ Import Namespace="AdamDotCom.Common.Website" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
  Reading Lists (Books I'd like to read and books I recommend) &raquo; Adam.Kahtava.com / AdamDotCom
</asp:Content>

<asp:Content ID="headContent" ContentPlaceHolderID="HeadContent" runat="server">
  <style type="text/css">
    #main 
    {
      width: 936px;
    }
    #reading-lists .have-read, .to-read
    {
      width: 455px;
      float: left;
      margin-left: 10px;
    }
    #reading-lists .have-read h2, .to-read h2
    {
      margin-left: -10px;
    }
    #reading-lists ul.book-list
    {
      list-style: none;	
    }
    #reading-lists ul.book-list img
    {
      float: left;
      margin-left: -95px;
    }
    #reading-lists ul.book-list a
    {
      display: block;
      float: left;
      padding: 5px 5px 5px 100px;
      margin-top: 10px;
      border-radius: 10px;
      -moz-border-radius: 10px;
      -webkit-border-radius: 10px;
      border: solid 2px #EFEFF7;
      width: 300px;
    }
    #reading-lists li.zebra a
    {
      background: #EFEFF7;
    }
  </style>
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
  <div id="reading-lists">
    <div class="have-read">
      <h2>Books I Recommend</h2>
      <ul class="book-list">
    <%  int zebra = 0;
      foreach (Product item in ViewData.Get<HaveReadList>()) { %>
        <li <%= zebra % 2 == 0 ? "" : "class=\"zebra\"" %>><a href="<%= item.ProductPreviewUrl %>"><img alt="<%= item.Title %>" src="<%= item.ImageUrl %>" /><%= item.Title %> by <%= item.AuthorsMLA %></a></li>
    <%  zebra++;
      } %>
      </ul>
    </div>    
    <div class="to-read">
      <h2>Books I'd Like to Read</h2>
      <ul class="book-list">
    <%  zebra = 0; 
      foreach (Product item in ViewData.Get<ToReadList>()) { %>
        <li <%= zebra % 2 == 0 ? "class=\"zebra\"" : "" %>><a href="<%= item.ProductPreviewUrl %>"><img alt="<%= item.Title %>" src="<%= item.ImageUrl %>" /><%= item.Title %> by <%= item.AuthorsMLA %></a></li>  
    <%  zebra++;
      } %>
      </ul>
    </div>
  </div>  
</asp:Content>

<asp:Content ID="sidebarContent" ContentPlaceHolderID="SidebarContent" runat="server" />