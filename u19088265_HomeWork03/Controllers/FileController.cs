using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using u19088265_HomeWork03.Models;
using System.IO;

namespace u19088265_HomeWork03.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult Index()
        {
            //Fetch files in each subfolder from the directory
            string[] imagePaths = Directory.GetFiles(Server.MapPath("~/Media/Images"));
            string[] documentPaths = Directory.GetFiles(Server.MapPath("~/Media/Documents"));
            string[] videoPaths = Directory.GetFiles(Server.MapPath("~/Media/Videos"));

            //Copy file names to model list
            List<FileModel> files = new List<FileModel>();
            foreach (string imagePath in imagePaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(imagePath) });
            }

            foreach (string documentPath in documentPaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(documentPath) });
            }

            foreach (string videoPath in videoPaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(videoPath) });
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
        public ActionResult DeleteFile(string fileName)
        {
            //Fetch path
            string[] documentPaths = Directory.GetFiles(Server.MapPath("~/Media/Documents"));

            //Remove from model list
            List<FileModel> files = new List<FileModel>();
            foreach (string documentPath in documentPaths)
            {
                files.Remove(new FileModel { FileName = Path.GetFileName(documentPath) });
            }

            return RedirectToAction("Index");
        }
    }
}