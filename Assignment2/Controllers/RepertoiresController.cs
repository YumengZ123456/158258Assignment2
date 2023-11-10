using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment2.Data;
using Assignment2.Models;
using Assignment2.ViewModels;
using static Assignment2.ViewModels.RepertoireIndexViewModel;
using PagedList;
using System.Data.SqlTypes;

namespace Assignment2.Controllers
{
    public class RepertoiresController : Controller
    {
        private Assignment2Context db = new Assignment2Context();

        // GET: Repertoires
        public ActionResult Index(string season,string search,int? page)
        {
            RepertoireIndexViewModel viewModel = new RepertoireIndexViewModel();
            var repertoires = db.Repertoires.Include(r => r.Season);
            if (!String.IsNullOrEmpty(search))
            {
                repertoires = repertoires.Where(p => p.ShortProgram.Contains(search) ||
                p.LongProgram.Contains(search) ||
                p.Season.Name.Contains(search)||
                p.Gala.Contains(search));
                viewModel.Search = search;
            }
            viewModel.SeasWithCount = from matchingProducts in repertoires
                                      where matchingProducts.SeasonID != null
                                      group matchingProducts by
                                      matchingProducts.Season.Name into catGroup
                                      select new SeasonWithCount()
                                      {
                                          SeasonName = catGroup.Key,
                                          RepertoireCount = catGroup.Count()
                                      };
            if (!String.IsNullOrEmpty(season))
            {
                repertoires = repertoires.Where(p => p.Season.Name == season);
                viewModel.Season = season;
            }

            repertoires = repertoires.OrderBy(p => p.ID);
            const int PageItems = 5;
            int currentPage = (page ?? 1);
            viewModel.Repertoires = repertoires.ToPagedList(currentPage, PageItems);

   
            return View(viewModel);
        }

        // GET: Repertoires/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repertoire repertoire = db.Repertoires.Find(id);
            if (repertoire == null)
            {
                return HttpNotFound();
            }
            return View(repertoire);
        }

        // GET: Repertoires/Create
        public ActionResult Create()
        {
            ViewBag.SeasonID = new SelectList(db.Seasons, "ID", "Name");
            return View();
        }

        // POST: Repertoires/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ShortProgram,LongProgram,Gala,SeasonID")] Repertoire repertoire)
        {
            if (ModelState.IsValid)
            {
                db.Repertoires.Add(repertoire);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SeasonID = new SelectList(db.Seasons, "ID", "Name", repertoire.SeasonID);
            return View(repertoire);
        }

        // GET: Repertoires/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repertoire repertoire = db.Repertoires.Find(id);
            if (repertoire == null)
            {
                return HttpNotFound();
            }
            ViewBag.SeasonID = new SelectList(db.Seasons, "ID", "Name", repertoire.SeasonID);
            return View(repertoire);
        }

        // POST: Repertoires/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ShortProgram,LongProgram,Gala,SeasonID")] Repertoire repertoire)
        {
            if (ModelState.IsValid)
            {
                db.Entry(repertoire).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SeasonID = new SelectList(db.Seasons, "ID", "Name", repertoire.SeasonID);
            return View(repertoire);
        }

        // GET: Repertoires/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repertoire repertoire = db.Repertoires.Find(id);
            if (repertoire == null)
            {
                return HttpNotFound();
            }
            return View(repertoire);
        }

        // POST: Repertoires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Repertoire repertoire = db.Repertoires.Find(id);
            db.Repertoires.Remove(repertoire);
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
