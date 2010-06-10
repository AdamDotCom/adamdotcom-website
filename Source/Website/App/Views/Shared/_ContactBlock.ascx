<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="AdamDotCom.OpenSource.Service.Proxy"%>
<%@ Import Namespace="AdamDotCom.Website.App.Models"%>
<%@ Import Namespace="AdamDotCom.Common.Website"%>

<%@ OutputCache Duration="172800" VaryByParam="None" Shared="true" %>
<div id="northsidebar">
  <div class="widget">
    <h3>Contact</h3>
<%--
    <div style="padding-bottom: 0px; padding-left: 33px;">
      <script type="text/javascript" src="http://download.skype.com/share/skypebuttons/js/skypeCheck.js"></script>
      <a href="skype:adam.kahtava.com?call"><img src="http://mystatus.skype.com/balloon/adam%2Ekahtava.com" style="border: none;" width="150" height="60" alt="My status" /></a>
    </div>
--%>
    <div>
      <img src="/public/images/contact-me/Adam-Kahtava-2009-150px.png" width="155" height="154" />
    </div>
    <div>
      <a class="contact-me" href="/contact-me/" title="Contact me"><span>Contact me</span></a><br />
    </div>
  </div>
  <div class="widget contribute">
    <h3>Contribute / Code Samples</h3>
    <%= Html.Action("Index", "Projects", new { gitHubId = "adamdotcom", googleCodeId = "adam.kahtava.com" })%>
  </div>  
  <div class="widget connect">
    <h3>Connect</h3>
    <div>
        <ul>
            <li><a href="http://www.twitter.com/AdamDotCom"><img src="/public/images/connect/twitter_16x16.png">&nbsp;Follow me on Twitter</a></li>
            <li><a href="http://www.linkedin.com/in/kahtava"><img src="/public/images/connect/linkedin_16x16.png">&nbsp;Profile at LinkedIn</a></li>
            <li><a href="http://del.icio.us/kahtava"><img src="/public/images/connect/delicious_16x16.gif">&nbsp;Bookmarks at del.icio.us</a></li>
            <li><a class="contact-me" href="/contact-me/"><img src="/public/images/connect/vcard_16x16.gif">&nbsp;Contact me</a></li>
        </ul>
    </div>
  </div>
</div>