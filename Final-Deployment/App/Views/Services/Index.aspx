﻿<%@ Page Language="C#" MasterPageFile="~/App/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="AdamDotCom.Amazon.Service.Proxy"%>
<%@ Import Namespace="AdamDotCom.Website.App.Models"%>
<%@ Import Namespace="AdamDotCom.Common.Website" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
  Publicly available web services hosted on http://adam.kahtava.com/services/ &raquo; Adam.Kahtava.com / AdamDotCom
</asp:Content>

<asp:Content ID="headContent" ContentPlaceHolderID="HeadContent" runat="server">
  <style type="text/css">
    #main {
      width: 936px;
    }
    #main ul {
      list-style-type: none;
    }
    #main > ul > li {
      padding-bottom: 10px;
    }
    #main > ul > li > ul {
      padding-top: 10px;
      padding-left: 10px;
    }
    #main > ul > li > ul > li ul {
      padding-left: 30px;
    }
    #main > ul > li > ul > li > ul > li {
      padding-bottom: 10px;
    }
    #main > ul > li > a {
        font-weight: bold;
        display:block;
        font-size: 15px;
        color: #000;
    }        
    #main > ul > li > ul > li{
      padding-bottom: 10px;
    }
    #main .uri {
      font-weight: bold;
    }
    #main > p {
      padding: 7px 0px 7px 0px;
    }
    #main > ul {
      padding-top: 10px;
      padding-left: 10px;
    }
  </style>
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
  <h2>Publicly available web services hosted on http://adam.kahtava.com/services/</h2>
  <p>
    The source for these services can be found at <a href="http://code.google.com/p/adamdotcom-services/">http://code.google.com/p/adamdotcom-services/</a>.
    Additional service information can be found on my blog under the <a href="http://adam.kahtava.com/journal/category/open-source/adc-services/">services category</a>. 
  </p>
  <p>
    Active services include:
  </p>
  <ul>
    <li>
      <a name="amazon">The Amazon Service, get your Wishlist or Review list from Amazon</a><br />
      Possible URIs \ end points:
      <ul>
        <li>User profile discovery URI: 
          <ul>
            <li><span class="uri">http://adam.kahtava.com/services/amazon/discover/user/{firstname-lastname}.{json|xml}[?callback={callback}]</span></li>
          </ul>
          Example:
          <ul>
            <li><a href="http://adam.kahtava.com/services/amazon/discover/user/adam-kahtava.xml">http://adam.kahtava.com/services/amazon/discover/user/adam-kahtava.xml</a></li>
            <li><a href="http://adam.kahtava.com/services/amazon/discover/user/adam-kahtava.json">http://adam.kahtava.com/services/amazon/discover/user/adam-kahtava.json</a></li>
            <li><a href="http://adam.kahtava.com/services/amazon/discover/user/adam-kahtava.json?callback=callback">http://adam.kahtava.com/services/amazon/discover/user/adam-kahtava.json?callback=callback</a></li>
          </ul>            
        </li>
        <li>Review retrieval URI by Amazon customer ID: 
          <ul>
            <li><span class="uri">http://adam.kahtava.com/services/amazon/reviews/id/{customer-id}.{json|xml}[?callback={callback}]</span></li>
          </ul>
          Example:
          <ul>
            <li><a href="http://adam.kahtava.com/services/amazon/reviews/id/A2JM0EQJELFL69.xml">http://adam.kahtava.com/services/amazon/reviews/id/A2JM0EQJELFL69.xml</a></li>
          </ul>
        </li>
        <li>Review retrieval URI by Amazon user's firstname lastname combination: 
          <ul>
            <li><span class="uri">http://adam.kahtava.com/services/amazon/reviews/user/{firstname-lastname}.{json|xml}[?callback={callback}]</span></li>
          </ul>
          Example:
          <ul>
            <li><a href="http://adam.kahtava.com/services/amazon/reviews/user/adam-kahtava.json?callback=callback">http://adam.kahtava.com/services/amazon/reviews/user/adam-kahtava.json?callback=callback</a></li>
          </ul>             
        </li>
        <li>Whishlist retrieval URI by Amazon wishlist ID: 
          <ul>
            <li><span class="uri">http://adam.kahtava.com/services/amazon/wishlist/id/{list-id}.{json|xml}[?callback={callback}]</span></li>
          </ul>
          Example:
          <ul>
            <li><a href="http://adam.kahtava.com/services/amazon/wishlist/id/1XZDXVXHE3946.xml">http://adam.kahtava.com/services/amazon/whishlist/id/1XZDXVXHE3946.xml</a></li>
          </ul>
        </li>
        <li>Wishlist retrieval URI by Amazon user's firstname lastname combination: 
          <ul>
            <li><span class="uri">http://adam.kahtava.com/services/amazon/wishlist/user/{firstname-lastname}.{json|xml}[?callback={callback}]</span></li>
          </ul>
          Example: 
          <ul>
            <a href="http://adam.kahtava.com/services/amazon/wishlist/user/adam-kahtava.json?callback=callback">http://adam.kahtava.com/services/amazon/wishlist/user/adam-kahtava.json?callback=callback</a>
          </ul>
        </li>
      </ul>
    </li>
    <li>
      <a name="open-source">The Open Source Projects Service, get your project details from GitHub or Google Code</a><br />
      Possible URIs \ end points:
      <ul>
        <li>Single project host retrieval URI: 
          <ul>
            <li><span class="uri">http://adam.kahtava.com/services/open-source/projects/{project-host}.{json|xml}?user={username}[&amp;callback={callback}]</span></li>
          </ul>  
          Examples: 
          <ul>
            <li><a href="http://adam.kahtava.com/services/open-source/projects/github.xml?user=adamdotcom">http://adam.kahtava.com/services/open-source/projects/github.xml?user=adamdotcom</a></li>
            <li><a href="http://adam.kahtava.com/services/open-source/projects/googlecode.json?user=adam.kahtava.com&callback=callback">http://adam.kahtava.com/services/open-source/projects/googlecode.json?user=adam.kahtava.com&amp;callback=callback</a></li>
          </ul>
        </li>	
        <li>Multiple project host retrieval URI: 
          <ul>
            <li><span class="uri">http://adam.kahtava.com/services/open-source/projects.{json|xml}?project-host:username={project-host1:username1,project-host2:username2,...}[&amp;callback={callback}]</span></li>
          </ul>
          Examples:
          <ul>
            <li><a href="http://adam.kahtava.com/services/open-source/projects.json?project-host:username=github:adamdotcom,googlecode:adam.kahtava.com">http://adam.kahtava.com/services/open-source/projects.json?project-host:username=github:adamdotcom,googlecode:adam.kahtava.com</a></li>
            <li><a href="http://adam.kahtava.com/services/open-source/projects.xml?project-host:username=googlecode:adam.kahtava.com">http://adam.kahtava.com/services/open-source/projects.xml?project-host:username=googlecode:adam.kahtava.com</a></li>
          </ul>
        </li>
      </ul>		
    </li>
    <li>          
      <a name="resume">The Resume Service, get your resume from LinkedIn</a><br />
      Possible URIs \ end points:
      <ul>
        <li>Resume retrieval URI: 
          <ul>
            <li><span class="uri">http://adam.kahtava.com/services/resume/linkedIn/{firstname-lastname}.{json|xml}[?callback={callback}]</span></li>
          </ul>
          Example: 
          <ul>
            <li><a href="http://adam.kahtava.com/services/resume/linkedin/adam-kahtava.json?callback=callback">http://adam.kahtava.com/services/resume/linkedin/adam-kahtava.json?callback=callback</a></li>
          </ul>
        </li>
      </ul>
    </li>
    <li>
      <a name="whois">The Whois Service</a><br />
      Possible URIs \ end points:
      <ul>
        <li>Normal Whois retrieval URI: 
          <ul>
            <li><span class="uri">http://adam.kahtava.com/services/whois.{json|xml|csv}[?query={ip-address}][&amp;callback={callback}]</span></li>
          </ul>
          Examples:
          <ul>
            <li><a href="http://adam.kahtava.com/services/whois.xml?query=68.140.1.1">http://adam.kahtava.com/services/whois.xml?query=68.140.1.1</a></li>
            <li><a href="http://adam.kahtava.com/services/whois.xml">http://adam.kahtava.com/services/whois.xml</a></li>
            <li><a href="http://adam.kahtava.com/services/whois.json?callback=callback">http://adam.kahtava.com/services/whois.json?callback=callback</a></li>
          </ul>
        </li>
        <li>Enhanced Whois retrieval URI: 
          <ul>
            <li><span class="uri">http://adam.kahtava.com/services/whois/enhanced.{json|xml|csv}?query={ip-address}&amp;filters={filter1,filter2,...}&amp;referrer={referrer}[&amp;callback={callback}]</span></li>
          </ul>
          Example:
          <ul>
            <li><a href="http://adam.kahtava.com/services/whois/enhanced.xml?query=74.125.127.99&filters=Calgary&referrer=Twitter">http://adam.kahtava.com/services/whois/enhanced.xml?query=74.125.127.99&amp;filters=Calgary&amp;referrer=Twitter</a></li>
            <li><a href="http://adam.kahtava.com/services/whois/enhanced.csv?query=74.125.127.99&referrer=LinkedIn">http://adam.kahtava.com/services/whois/enhanced.csv?query=74.125.127.99&amp;referrer=LinkedIn</a></li>
          </ul>              
        </li>
      </ul>	
    </li>
  </ul>
  <p>
    Contributions, code reviews, and thoughts are welcomed. Feel free to <a class="contact-me" href="/contact-me/">contact me</a>. Thanks for stopping by!
  </p>
</asp:Content>

<asp:Content ID="sidebarContent" ContentPlaceHolderID="SidebarContent" runat="server" />