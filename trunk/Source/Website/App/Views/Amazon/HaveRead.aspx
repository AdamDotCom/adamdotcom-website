<%@ Page Language="C#" MasterPageFile="~/App/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="AdamDotCom.Amazon.Service.Proxy"%>
<%@ Import Namespace="AdamDotCom.Website.App.Models"%>
<%@ Import Namespace="AdamDotCom.Common.Website" %>
<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        #main 
        {
        	width: 936px;
        }
        .have-read
        {
        	width: 465px;
        	float: left;
        }
        .to-read
        {
        	width: 465px;
        	float: right;
        }
        .have-read
        {
        	list-style: none;
        	
        }
        .have-read img 
        {
        	float: left;
        }
        .have-read li
        {
        	clear: both;
        }
    </style>
    <div class="have-read">
    <h2>Books I've Read and Recommend</h2>
    <ul>
    <% foreach (Product item in ViewData.Get<HaveReadList>()) { %>
        <li>
            <a href="<%= item.ProductPreviewUrl %>">
            <%= item.Title %> by <%= item.AuthorsMLA %>
            <img title="item.Title" src="<%= item.ImageUrl %>" />
            </a>
        </li>
    <% } %>
    </ul>
    </div>
    <div class="to-read">
    <h2>Books I Want to Read</h2>
    <% foreach (Product item in ViewData.Get<HaveReadList>()) { %>
        <li><a href="<%= item.ProductPreviewUrl %>">
        <img title="item.Title" src="<%= item.ImageUrl %>" /><%= item.Title %> by <%= item.AuthorsMLA %></a></li>
    <% } %>
    </div>
</asp:Content>
