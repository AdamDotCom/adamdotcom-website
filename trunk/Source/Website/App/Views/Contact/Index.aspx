<%@ Page Language="C#" MasterPageFile="~/App/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="AdamDotCom.Website.App.Controllers"%>
<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Adam.Kahtava.com / AdamDotCom - Resume / Curriculum Vitae / Software Developer / Web Developer 
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
<script src="http://remiya.com/demos/htmlbox-4.0/htmlbox.min.js"></script>
<script>

    $(function() {
        function postAsync() {
            $.post('/contact/', $($('form[name="contact"]')).serialize()); 
            return false;
        }
        $('input:submit').click(postAsync);
        
        var hb_silk_icon_set_default = $("#message").css("height","100").css("width","600").htmlbox({
            toolbars:[
               ["cut","copy","paste","separator_dots","bold","italic","underline","strike","sub","sup","separator_dots","undo","redo","separator_dots",
             "left","center","right","justify","separator_dots","ol","ul","indent","outdent","separator_dots","link","unlink","image"],
             ["code","removeformat","striptags","separator_dots","quote","paragraph","hr","separator_dots",
               {icon:"new.png",tooltip:"New",command:function(){hb_silk_icon_set_blue.set_text("<p></p>");}},
               {icon:"open.png",tooltip:"Open",command:function(){alert('Open')}},
               {icon:"save.png",tooltip:"Save",command:function(){alert('Save')}}
              ]
          ],
          icons:"silk",
          skin:"default"
        });
    });
</script>

</script>
<div id="contact">
    <%--form_remote_tag--%>
    <% using (Html.BeginForm("index", "contact", FormMethod.Post, new { name = "contact" }))
        { %>
        <%= Html.TextBox("name") %><br />
        <%= Html.TextBox("email") %><br />
        <%= Html.TextBox("subject", "Hey Adam, I was on your site and...") %><br />
        <%= Html.TextArea("message") %><br />
        <%= Html.AntiForgeryToken() %>
        <input title="Submit" type="submit" value="Send" />
    <%  } %>
</div>
</asp:Content>