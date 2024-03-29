﻿<%@ Page Language="C#" MasterPageFile="~/App/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Resume>" %>
<%@ Import Namespace="AdamDotCom.Website.App.Models"%>
<%@ Import Namespace="AdamDotCom.Resume.Service.Proxy"%>
<%@ Import Namespace="AdamDotCom.Common.Website" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
  Resume of a Software Developer, Web Developer, and Front-end Engineeer (Curriculum Vitae, CV) &raquo; Adam.Kahtava.com / AdamDotCom
</asp:Content>

<asp:Content ID="headContent" ContentPlaceHolderID="HeadContent" runat="server">
  <style type="text/css">
    #resume .enrich
    {
      display: none;
    }
    #resume ul
    {
      list-style:none;
      padding: 5px 0px 20px 10px;
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
      padding: 5px 0px 5px 15px;
      margin: 0px 0px 13px 0px;
      border-radius: 10px;
      -moz-border-radius: 10px;
      -webkit-border-radius: 10px;
      border: solid 2px #EFEFF7;
      float:left;
    }
    #resume .experience li.zebra a
    {
      background: #EFEFF7;
    }
    #resume ul.education
    {
      list-style: square inside;
      padding: 5px 5px 20px 10px;
    }
    #resume li.zebra
    {
      background: #EFEFF7;
    } 
  </style>
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
  <div id="resume">
    <h3>Summary</h3>
    <ul class="summary">
      <li><%= Model.Summary %></li>
    </ul>
    <h3>Specialties</h3>
    <ul class="specialties">
      <li><%= Model.Specialties %></li>
    </ul>
    <h3>Experience</h3>
    <ul class="experience">
  <%  int zebra = 0;
    foreach(Position item in Model.Positions) {%>
      <li <%= zebra % 2 == 0 ? "" : "class=\"zebra\"" %>><strong class="title"><%= item.Title %></strong> <strong class="company"><%= item.Company %></strong> <span class="period"><%= item.Period %></span> <%= (item.Description) %></li>
  <%  zebra++;
    }%>
    </ul>
    <h3>Education</h3>
    <ul class="education">
  <%  foreach (Education item in Model.Educations) {%>
      <li><strong><%= item.Certificate %></strong>, <%= item.Period %>, <%= item.Institute %></li>
  <%  } %>
    </ul>
  </div>
</asp:Content>