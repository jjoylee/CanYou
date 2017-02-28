﻿using Spring.Aop.Config;
using Spring.Context;
using Spring.Context.Support;
using Spring.Data.Config;
using Spring.Objects.Factory.Xml;
using Spring.Transaction.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CanYou
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            LoadSpringConfig();
        }
        private void LoadSpringConfig()
        {
            NamespaceParserRegistry.RegisterParser(typeof(DatabaseNamespaceParser));
            NamespaceParserRegistry.RegisterParser(typeof(TxNamespaceParser));
            NamespaceParserRegistry.RegisterParser(typeof(AopNamespaceParser));

            string[] param={"~/AppConfig/Config.xml"};
            IApplicationContext context = new XmlApplicationContext(param);
            ContextRegistry.RegisterContext(context);
        }
    }
}
