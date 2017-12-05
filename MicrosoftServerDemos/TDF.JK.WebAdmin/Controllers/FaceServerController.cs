using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        public async Task<ActionResult> ImgFaceDetect()
        {
            var files = Request.Files;
            var file = files["FileModel"];
            var imgStream = file.InputStream;

            var img = Image.FromStream(imgStream);
            var initialWidth = img.Width;
            var initialHeight = img.Height;

            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", FaceApiConfig.subscriptionKey);

            // Request parameters
            //queryString["returnFaceLandmarks"] = "true";
            queryString["returnFaceAttributes"] = "age,gender";
            var uri = FaceApiConfig.uriBase + "detect?"+ queryString;

            HttpResponseMessage response;

            // Request body
            //byte[] byteData = Encoding.UTF8.GetBytes("{body}");
            imgStream.Position = 0;
            byte[] byteData = StreamToBytes(imgStream);
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                response = await client.PostAsync(uri, content);
                var code = response.StatusCode;
                var contentStr = response.Content.ReadAsStringAsync();
                var result = contentStr.Result;
                if (code == HttpStatusCode.OK)
                {
                    JToken jt = JToken.Parse(result);
                    if (jt.Type == JTokenType.Array)
                    {
                        List<FaceDataModel> faceList = JsonConvert.DeserializeObject<List<FaceDataModel>>(result);
                        return Json(new { Success = true, InitialWidth = initialWidth, InitialHeight = initialHeight, Result = faceList });
                    }
                    else
                    {
                        var faceError = JsonConvert.DeserializeObject<FaceApiErrorModel>(result);
                        return Json(new { Success = false, InitialWidth = initialWidth, InitialHeight = initialHeight, Result = faceError });
                    }
                }
                
                return Json(new { Success = false, Result = result });
            }
        }

        [HttpGet]
        public async Task<ActionResult> FaceVerify(string faceId1, string faceId2)
        {
            
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", FaceApiConfig.subscriptionKey);
            var uri = FaceApiConfig.uriBase + "verify?" + queryString;

            byte[] byteData =
                Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new {faceId1 = faceId1, faceId2 = faceId2}));
            HttpResponseMessage response;
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);
                var code = response.StatusCode;
                var contentStr = response.Content.ReadAsStringAsync();
                var result = contentStr.Result;
                if (code == HttpStatusCode.OK)
                {
                    return Json(new { Success = true, Result= result }, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(new { Success = false, Result = "" }, JsonRequestBehavior.AllowGet);
        }

        /// 将 Stream 转成 byte[]
        public byte[] StreamToBytes(Stream stream)
        {
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            // 设置当前流的位置为流的开始
            stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }
    }
}