using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using u19088265_HomeWork03.Models;

namespace u19088265_HomeWork03.Controllers
{
    public class VideoController : Controller
    {
        // GET: Video
        public ActionResult Index()
        {
            //Fetch files in each subfolder from the directory
            string[] videoPaths = Directory.GetFiles(Server.MapPath("~/Media/Videos"));

            //Copy file names to model list
            List<FileModel> files = new List<FileModel>();
            foreach (string videoPath in videoPaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(videoPath) });
            }

            return View(files);
        }

        //Download file
        public FileResult DownloadFile(string fileName)
        {

            string videoPath = Server.MapPath("~/Media/Videos/" + fileName);
            //string imagePath = Server.MapPath("~/Media/Images/");
            //string videoPath = Server.MapPath("~/Media/Videos");

            byte[] vidBytes = System.IO.File.ReadAllBytes(videoPath);

            return File(vidBytes, "application/octet-stream", fileName);

        }

        //Delete file
    }
}