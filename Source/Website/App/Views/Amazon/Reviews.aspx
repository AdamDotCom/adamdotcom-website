<%@ Page Language="C#" MasterPageFile="~/App/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="AdamDotCom.Amazon.Service.Proxy"%>
<%@ Import Namespace="AdamDotCom.Common.Website" %>
<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .reviews
        {
        	margin-left: 10px;
        }
        .reviews h2
        {
        	margin-left: -10px;
        }
        ul.review-list
        {
            list-style: none;	
        }
        ul.review-list img
        {
        	float: left;
        	margin-left: -95px;
        }
        ul.review-list li p
        {
        	padding-top: 7px;
        }
        ul.review-list li
        {
        	display: block;
        	float: left;
        	padding: 5px 5px 5px 100px;
        	margin-top: 10px;
            border-radius: 10px;
            -moz-border-radius: 10px;
            -webkit-border-radius: 10px;
            border: solid 2px #EFEFF7;
            
        }
        li.zebra 
        {
            background: #EFEFF7;
        }
    </style>

    <h2>Reviews</h2>
    <ul class="review-list">
    <% int zebra = 0;
       foreach (Review item in ViewData.Get<Reviews>())
       { %>
        <li class="<%= zebra % 2 == 0 ? "" : "zebra" %>"><a href="<%= item.Url %>"><img alt="<%= item.Title %>" src="<%= item.ImageUrl %>" /><strong><%= item.Title %> by <%= item.AuthorsMLA %></strong></a><p><%= item.Content %></p></li>
    <%  zebra++;
       } %>
    </ul>  
</asp:Content>

<asp:Content ID="sidebarContent" ContentPlaceHolderID="SidebarContent" runat="server">
    <% Html.RenderPartial("_ContactBlock"); %>
</asp:Content>