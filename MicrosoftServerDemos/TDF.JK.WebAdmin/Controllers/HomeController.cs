using Newtonsoft.Json;
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
                     
            return Redirect("Home/Add"); 
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

        [HttpGet]
        public string GetUserInfo(int PageIndex,int PageSize,int draw)
        {
            using (var db = new ImageModelContainer())
            {               
                var resList =  db.UserInfoSet.Select(u => u);                                       
                var jsonResult = new { draw = draw, recordsTotal = 6, recordsFiltered = 6,error ="",data = resList };
                return JsonConvert.SerializeObject(jsonResult);
            };
        
        }
    }
}