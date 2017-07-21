using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using smsg_DAL;
using smsg_MVC4.Utils;

namespace smsg_MVC4
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            RegisterAdmin();
        }

        private void RegisterAdmin()
        {
            //create admin
            using (smsg_User_List ul = new smsg_User_List(SiteUtils.ConnectionStringUsers))
            {
                var i=ul.LoadFromDB.LoadFrom_IDUserQ(SiteUtils.UserAdministratorID).Count();
                if (i != 1)
                {
                    smsg_User admin = new smsg_User();
                    admin.IDUser = SiteUtils.UserAdministratorID;
                    admin.UserEmail = "ignatandrei@yahoo.com";
                    admin.UserName = "admin";
                    ul.Add(admin);
                    ul.SaveNew();
                }
            }

            

            
           
        }
    }
}