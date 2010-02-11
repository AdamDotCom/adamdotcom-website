<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="AdamDotCom.Common.Website"%>
<%@ Import Namespace="AdamDotCom.OpenSource.Service.Proxy"%>

<%@ OutputCache Duration="172800" VaryByParam="None" %>
<ul>
<% foreach (Project project in ViewData.Get<Projects>()){ %>
   <li class="<%= project.Url.Contains("github") ? "github" : "google-code" %>"><a href="<%= project.Url %>"><%= project.Name %></a> <span class="extended"><%= project.Description %></span> <span class="hover"><%= project.LastMessage %> - <%= project.LastModified %></span></li>
<% } %>
</ul>