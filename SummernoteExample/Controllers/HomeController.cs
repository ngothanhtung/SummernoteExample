using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SummernoteExample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(string summernote)
        {
            ViewBag.Summernote = summernote;
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        #region SUMMERNOTE UPLOAD IMAGES

        [HttpPost]
        public ActionResult SummernoteUploadImage()
        {
            foreach (var fileKey in Request.Files.AllKeys)
            {
                var file = Request.Files[fileKey];
                try
                {
                    var fileName = Path.GetFileName(file?.FileName);
                    if (fileName != null)
                    {
                        var path = Server.MapPath("~/Uploads/SummernoteImages");
                        if (System.IO.File.Exists(path) == false)
                        {
                            Directory.CreateDirectory(path);
                        }

                        path = Path.Combine(Server.MapPath("~/Uploads/SummernoteImages"), fileName);
                        file.SaveAs(path);
                        return Json(new { Url = Url.Content("~/Uploads/SummernoteImages/" + fileName) });
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { Message = $"Error in saving file ({ex.Message})" });
                }
            }
            return Json(new { Message = "File saved" });
        }

        #endregion
    }
}