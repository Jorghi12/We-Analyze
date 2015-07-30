using Open_Source_Data.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Open_Source_Data.Controllers
{
    public class SiteController : Controller
    {
        // GET: Site
        public ActionResult Tutorials(int topicID = 0)
        {
            TutorialsEntities db = new TutorialsEntities();
            TutorialTable tutorialsTable = db.TutorialTables.Find(topicID);
            if (tutorialsTable == null)
            {
                tutorialsTable = db.TutorialTables.Find(0);
            }
            ViewBag.Message = "Examples";
            ViewBag.topicID = tutorialsTable.Id;
            ViewBag.ShortSummary = tutorialsTable.ShortSummary;
            ViewBag.TopicName = tutorialsTable.TopicName;
            ViewBag.Date = tutorialsTable.LastUpdated.ToString("MM/dd/yyyy");

            return View();
        }
        public ActionResult DownloadCode(String fileName)
        {
            return File(Server.MapPath("~/App_Data/" + fileName), "application/txt", fileName);
        }

        public ActionResult TutView(int topicID = 0)
        {
            ViewBag.Message = "Tutorial";
            
            TutorialsEntities db = new TutorialsEntities();
            TutorialTable tutorialsTable = db.TutorialTables.Find(topicID);

            ViewBag.CodeSources = tutorialsTable.CodeSources.Split(';');
            return View(tutorialsTable);
        }
    }
}