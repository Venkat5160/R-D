using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using smsg_MVC4.Areas.Messaging.Models;
using smsg_MVC4.Utils;

namespace smsg_MVC4.Areas.Messaging.Controllers
{
    public partial class MessageController : Controller
    {
        //
        // GET: /Messaging/Message/
        [Authorize]
        public virtual ActionResult Index()
        {
            MVCUserModel um = new MVCUserModel();
            um.User = SiteUtils.UserLoggedOn;
            return View(um);
        }

        public virtual ActionResult DisplayMessage(long ID)
        {
            var msg=SiteUtils.UserLoggedOn.FindMessage(ID);
            return View(msg);
        }
    }
}
