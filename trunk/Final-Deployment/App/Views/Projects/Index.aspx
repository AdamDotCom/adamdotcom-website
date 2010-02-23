<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="AdamDotCom.Website.App"%>
<%@ Import Namespace="AdamDotCom.Common.Website"%>
<%@ Import Namespace="AdamDotCom.OpenSource.Service.Proxy"%>

<style type="text/css">
  #northsidebar .widget > div#project-badge {
  	padding-left: 35px;
  }
  #project-badge {
    font-size: 14px;
    width: 230px;
    font-family: helvetica,arial,freesans,clean,sans-serif;
    background-color: #FFF;
  }
  #project-badge a {
    font-weight: bold;
    color: #4183C4;
    text-decoration: none;	
  }
  #project-badge ul {
    padding: 5px 0 0 0;
    margin: 0px;
  }
  #project-badge li{
    padding-left: 24px;
    list-style-type: none;
    border: 1px solid #FFF;
    border-bottom: 1px solid #e5e5e5;
    display: block;
    line-height: 27px;
  }
  #project-badge ul.entered li.entered{
    background-color: #FFF;
    border: 1px solid #e5e5e5;
  }
  #project-badge ul.entered li {
    background-color: #e5e5e5;
  }
  #project-badge li.github {
    background: transparent url(/public/images/projects/github-public-icon.png) no-repeat scroll 4px 6px;
  }
  #project-badge li.google-code {
    background: transparent url(/public/images/projects/google-code-icon.png) no-repeat scroll 4px 6px;
  }
  #project-badge li > a, #project-badge ul li .entered a {
    display: block;
  }
  #project-badge .entered a {
    color: #9BABBF;
  }
  #project-badge li.entered a {
    color: #4183C4;
  }
  #project-badge li.entered .extended{
    display: block;
    position: absolute;
    margin-left: 1px;
    width: 194px;
    overflow: hidden;
    font-size: 12px;
    border: solid 1px #e5e5e5;
    border-top: 0px;
    background: #FFF;
    padding: 4px;
    cursor: default;
    line-height: 16px;
    -moz-border-radius: 0px 0px 10px 10px;
    -webkit-border-radius: 0px 0px 10px 10px;
  }
  #project-badge li.entered .last-commit {
    padding: 2px 0px 0px 4px;
    font-style: italic;
    display: block;
    font-size: 11px;
  }
  #project-badge .extended {
    display: none;
  }
  #project-badge span.credits {
    padding-left: 24px;
  }
  #project-badge .credits a, #project-badge .credits {
    color: #CCC;
    font-size: 12px;
    font-weight: normal;
  }
</style>

<script type="text/javascript">
  $(document).ready(function () {
    var projectsBadge = $('#project-badge');

    // mouse behaviours    
    var projectsList = projectsBadge.find('ul');
    var projects = projectsList.find('li');

    projects.bind('mouseenter', function() {
        projects.removeClass('entered');
        $(this).addClass('entered');
        projectsList.addClass("entered");
    });

    projects.bind('mouseleave', function() {
        projects.removeClass('entered');
        projectsList.removeClass("entered");
    });
  });
</script>

<div id="project-badge">
  <ul>
    <% var projects = ViewData.Get<Projects>();
       for ( var i = 0; i < projects.Count ; i++ ) { %>
      <li class="<%= ((projects[i].Url.IndexOf("github") != -1) ? "github" : "google-code") %><%= (i % 2 == 1 ? " even" : "") %>">
        <a href="<%= projects[i].Url %>"><%= projects[i].Name %></a>
        <div class="extended">
          <span class="description"><%= projects[i].Description %></span>
          <span class="last-commit">Last commit: <%= projects[i].LastMessage %> <em>- <%= projects[i].LastModified %></em></span>
        </div>
      </li>
    <% } %>
  </ul>
  <span class="credits"><a href="http://github.com/AdamDotCom/project-badge">Project badge</a> by <a href="http://AdamDotCom.com">AdamDotCom</a></span>
</div>