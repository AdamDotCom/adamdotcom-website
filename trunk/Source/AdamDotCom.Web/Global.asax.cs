using System;
using System.Web;
using System.Web.Mvc;
using IronRubyMvc;
using NHaml.Web.Mvc;

namespace IronRubyMvcWeb
{
    public class GlobalApplication : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            this.InitializeIronRubyMvc();
            ViewEngines.Engines.Add(new NHamlViewMvcEngine());
        }
    }
}