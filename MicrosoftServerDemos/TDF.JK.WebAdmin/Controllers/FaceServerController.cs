using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TDF.JK.WebAdmin.Models.FaceApi;

namespace TDF.JK.WebAdmin.Controllers
{
    public class FaceServerController : Controller
    {
        // GET: FaceServer
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ImgFaceDetect()
        {
            var files = Request.Files;
            var file = files["FileModel"];
            var imgStream = file.InputStream;

            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", FaceApiConfig.subscriptionKey);


            HttpResponseMessage response;


            return Json("");
        }
    }
}