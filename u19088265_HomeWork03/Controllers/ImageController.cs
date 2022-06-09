using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using u19088265_HomeWork03.Models;

namespace u19088265_HomeWork03.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        public ActionResult Index()
        {
            //Fetch files in each subfolder from the directory
            string[] imagePaths = Directory.GetFiles(Server.MapPath("~/Media/Images"));

            //Copy file names to model list
            List<FileModel> files = new List<FileModel>();
            foreach (string imagePath in imagePaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(imagePath) });
            }

            return View(files);
        }

        //Download file
        public FileResult DownloadFile(string fileName)
        {

            string imagePath = Server.MapPath("~/Media/Images/" + fileName);
            //string imagePath = Server.MapPath("~/Media/Images/");
            //string videoPath = Server.MapPath("~/Media/Videos");

            byte[] imgBytes = System.IO.File.ReadAllBytes(imagePath);

            return File(imgBytes, "application/octet-stream", fileName);

        }

        //Delete file
    }
}