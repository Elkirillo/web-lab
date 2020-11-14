using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebUI.Infrastructure;

namespace WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //сообщаем mvc, что она может использовать CartModelBinder 
            //для создания экземпляров Cart
            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
        }
    }
}
