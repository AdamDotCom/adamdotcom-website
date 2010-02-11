<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Projects>" %>
<%@ Import Namespace="AdamDotCom.Website.App.Models"%>
<%@ Import Namespace="AdamDotCom.Common.Website"%>

<%@ OutputCache Duration="172800" VaryByParam="None" Shared="true" %>
<div id="northsidebar">
  <div class="widget">
    <h3>Contact</h3>
    <div style="padding-bottom: 0px; padding-left: 33px;">
      <script type="text/javascript" src="http://download.skype.com/share/skypebuttons/js/skypeCheck.js"></script>
      <a href="skype:adam.kahtava.com?call"><img src="http://mystatus.skype.com/balloon/adam%2Ekahtava.com" style="border: none;" width="150" height="60" alt="My status" /></a>
    </div>
    <div>
      <img src="/public/images/contact-me/Adam-Kahtava-2009-150px.png" width="155" height="154" />
    </div>
    <div>
      <a class="contact-me" href="/contact-me/" title="Contact me"><span>Contact me</span></a><br />
    </div>
  </div>
  <div class="widget">
    <h3>Connect</h3>
    <div>
      <a href="http://www.linkedin.com/in/kahtava" >
        <img src="/public/images/contact-me/btn_myprofile_160x33.gif" width="160" height="33" border="0" alt="View Adam Kahtava's profile on LinkedIn">
      </a>
    </div>
    <div style="padding-left: 35px;">
        <a href="http://twitter.com/AdamDotCom"><img src="/public/images/contact-me/twitterbutton-0108.png" title="By: TwitterButtons.com" width="142" height="48" /></a>
    </div>
    <div>
      <a href="http://www.facebook.com/kahtava"><img src="/public/images/contact-me/findmeonfacebook3.png" /></a>
    </div>
    <div>
      <div class="delicious-networkbadge"><span class="delicious-network-username"><a href="http://delicious.com/kahtava"><img width="15" height="15" border="0" alt="kahtava" src="/public/images/contact-me/delicious.med.gif"/></a> I am <a href="http://delicious.com/kahtava">kahtava</a> on <a href="http://delicious.com">Delicious</a></span><br/><span class="delicious-network-add"><a href="http://delicious.com/network?add=kahtava"><img width="15" height="15" border="0" alt="delicious" src="/public/images/contact-me/add.gif"/></a> <a href="http://delicious.com/network?add=kahtava">Add me to your  network</a></span><br/></div>
    </div>
  </div>

  <div class="widget contribute">
    <h3>Contribute / Code Samples</h3>
    <%= Html.Action("Index", "Projects", new { gitHubId="adamdotcom", googleCodeId = "adam.kahtava.com" })%>
  </div>

</div>