using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TDF.JK.WebAdmin.Repository;

namespace TDF.JK.WebAdmin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            return View();
        }

        public ActionResult Index3()
        {
            return View();
        }

        public ActionResult Index4()
        {
            return View();
        }

        [HttpPost]
        public bool AddUserInfo(UserInfo userInfo)
        {
            using (var db = new ImageModelContainer())
            {
                userInfo.Id = Guid.NewGuid();
                db.UserInfoSet.Add(userInfo);
                db.SaveChanges();
            }
            return  true;
        }

       
        public ActionResult Add()
        {
            
            return View();
        }
    }
}