<%@ Page Language="C#" MasterPageFile="~/App/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="AdamDotCom.Resume.Service.Proxy"%>
<%@ Import Namespace="AdamDotCom.Common.Website" %>
<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Adam.Kahtava.com / AdamDotCom - Resume / Curriculum Vitae / Software Developer / Web Developer 
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
<div id="resume">
    <h3>Summary</h3>
    <ul class="summary">
        <li>
    <%= ViewData.Get<Resume>().Summary %>
        </li>
    </ul>
    <h3>Specialties</h3>
    <ul class="specialties">
        <li>
    <%= ViewData.Get<Resume>().Specialties %>
        </li>
    </ul>
    <h3>Experience</h3>
    <ul class="experience">
    <% foreach(Position item in ViewData.Get<Resume>().Positions) {%>
        <li>
        <strong class="title"><%= item.Title %></strong>
        <strong class="company"><%= item.Company %></strong>
        <span class="period"><%= item.Period %></span>
        <%= (item.Description) %>
        </li>
    <% }%>
    </ul>
    <h3>Education</h3>
    <ul class="education">
    <% foreach (Education item in ViewData.Get<Resume>().Educations) {%>
        <li><strong><%= item.Certificate %></strong>, <%= item.Institute %></li>
    <% } %>
    </ul>
</div>
</asp:Content>
