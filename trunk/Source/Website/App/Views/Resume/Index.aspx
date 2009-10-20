﻿<%@ Page Language="C#" MasterPageFile="~/App/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="AdamDotCom.Resume.Service.Proxy"%>
<%@ Import Namespace="AdamDotCom.Common.Website" %>
<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Adam.Kahtava.com / AdamDotCom - Resume / Curriculum Vitae / Software Developer / Web Developer 
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
<style>
    #resume .enrich
    {
    	display: none;
    }
    #resume ul
    {
    	list-style:none;
        padding: 5px 5px 20px 10px;
    }
    #resume .experience .title, #resume .experience .period, #resume .experience .company
    {
    	display: block;
    	margin-left: -10px;
    	padding-bottom: 5px;
    }
    #resume .experience .title 
    {
    	font-size: 110%;
    }
    #resume .experience .company
    {
    	font-style: italic;
    }
    #resume .experience li
    {
    	padding: 2px 0px 2px 15px;
    	margin: 0px 0px 13px 0px;
        border-radius: 10px;
        -moz-border-radius: 10px;
        -webkit-border-radius: 10px;
        background:#EFEFF7;
        float:left;
    }
    #resume ul.education
    {
    	list-style: square inside;
    	padding: 5px 5px 20px 10px;
    }   
</style>
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