using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace u19088265_HomeWork03.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase UploadedFile, FormCollection Type)
        {
            //Retrieve selected Radio Button
            string selectedRadio = Type["FileType"].ToString();

            // For document file uploads
            if(selectedRadio == "doc" && UploadedFile != null && UploadedFile.ContentLength > 0)
            try
            {
                    string fileName = Path.GetFileName(UploadedFile.FileName);

                    string filePath = "";
                    filePath = Server.MapPath("~/Media/Documents");
                    if(!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    filePath = Path.Combine(filePath, fileName);
                    UploadedFile.SaveAs(filePath);

                    ViewBag.Message = "Document file uploaded successfully";
            }
            catch(Exception ex)
            {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
            }

            //For image file uploads
            if (selectedRadio == "img" && UploadedFile != null && UploadedFile.ContentLength > 0)
                try
                {
                    string fileName = Path.GetFileName(UploadedFile.FileName);

                    string filePath = "";
                    filePath = Server.MapPath("~/Media/Images");
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    filePath = Path.Combine(filePath, fileName);
                    UploadedFile.SaveAs(filePath);

                    ViewBag.Message = "Image file uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }

            //For video file uploads
            if (selectedRadio == "vid" && UploadedFile != null && UploadedFile.ContentLength > 0)
                try
                {
                    string fileName = Path.GetFileName(UploadedFile.FileName);

                    string filePath = "";
                    filePath = Server.MapPath("~/Media/Videos");
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    filePath = Path.Combine(filePath, fileName);
                    UploadedFile.SaveAs(filePath);

                    ViewBag.Message = "Video file uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }

            //When no radio button is selected
            if((selectedRadio == "" && UploadedFile != null && UploadedFile.ContentLength > 0) || (selectedRadio == ""))
            {
                ViewBag.Message = "Please select an option";
            }

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

       
    }
}