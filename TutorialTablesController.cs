using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Open_Source_Data
{
    public class TutorialTablesController : Controller
    {
        int servermode = 1;
        public TutorialsEntities db = new TutorialsEntities();

        // GET: TutorialTables
        public ActionResult Index()
        {
            if (servermode == 0) return RedirectToAction("Index", "Home");
            return View(db.TutorialTables.ToList());
        }

        // GET: TutorialTables/Details/5
        public ActionResult Details(int? id)
        {
            if (servermode == 0) return RedirectToAction("Index", "Home");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TutorialTable TutorialTable = db.TutorialTables.Find(id);
            if (TutorialTable == null)
            {
                return HttpNotFound();
            }
            return View(TutorialTable);
        }

        // GET: TutorialTables/Create
        public ActionResult Create()
        {
            if (servermode == 0) return RedirectToAction("Index", "Home");
            return View();
        }

        // POST: TutorialTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,Difficulty,Time,Programming_Language,Summary,Outcomes,BodyHtml,LastUpdated,ShortSummary,CodeSources")] TutorialTable TutorialTable)
        {
            if (servermode == 0) return RedirectToAction("Index", "Home");
            if (ModelState.IsValid)
            {
                db.TutorialTables.Add(TutorialTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(TutorialTable);
        }

        // GET: TutorialTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (servermode == 0) return RedirectToAction("Index", "Home");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TutorialTable TutorialTable = db.TutorialTables.Find(id);
            if (TutorialTable == null)
            {
                return HttpNotFound();
            }
            return View(TutorialTable);
        }

        // POST: TutorialTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,Difficulty,Time,Programming_Language,Summary,Outcomes,BodyHtml,LastUpdated,ShortSummary,CodeSources,TopicName")] TutorialTable TutorialTable)
        {
            if (servermode == 0) return RedirectToAction("Index", "Home");
            if (ModelState.IsValid)
            {
                db.Entry(TutorialTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(TutorialTable);
        }

        // GET: TutorialTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (servermode == 0) return RedirectToAction("Index", "Home");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TutorialTable TutorialTable = db.TutorialTables.Find(id);
            if (TutorialTable == null)
            {
                return HttpNotFound();
            }
            return View(TutorialTable);
        }

        // POST: TutorialTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (servermode == 0) return RedirectToAction("Index", "Home");
            TutorialTable TutorialTable = db.TutorialTables.Find(id);
            db.TutorialTables.Remove(TutorialTable);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
