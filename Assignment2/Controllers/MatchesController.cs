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
using static Assignment2.ViewModels.MatchIndexViewModel;
using PagedList;

namespace Assignment2.Controllers
{
    public class MatchesController : Controller
    {
        private Assignment2Context db = new Assignment2Context();

        // GET: Matches
        public ActionResult Index(string season,string search,int? page,string sortBy)
        {
            MatchIndexViewModel viewModel = new MatchIndexViewModel();
            var matches = db.Matches.Include(m => m.Season);

            if (!String.IsNullOrEmpty(search))
            {
                matches = matches.Where(p => p.Name.Contains(search) ||
                p.Date.Contains(search) ||
                p.Medal.Contains(search) ||
                p.Season.Name.Contains(search));
                viewModel.Search = search;
            }
            viewModel.SeasWithCount = from matchingProducts in matches
                                      where matchingProducts.SeasonID != null
                                      group matchingProducts by
                                      matchingProducts.Season.Name into catGroup
                                      select new SeasonWithCount()
                                      {
                                          SeasonName = catGroup.Key,
                                          MatchCount = catGroup.Count()
                                      };

            if (!String.IsNullOrEmpty(season))
            {
                matches = matches.Where(p => p.Season.Name == season);
                viewModel.Season = season;
            }
            matches = matches.OrderBy(p => p.ID); 

            switch (sortBy)
            {
                case "date_earliest":
                    matches = matches.OrderBy(p => p.Date);
                  
                    break;
                case "date_latest":
                    matches = matches.OrderByDescending(p => p.Date);
                    break;
                default:
                    matches = matches.OrderBy(p => p.Date);
                    break;
            }

                const int PageItems = 10;
            int currentPage = (page ?? 1);
            viewModel.Matches = matches.ToPagedList(currentPage, PageItems);
                viewModel.SortBy = sortBy;

                viewModel.Sorts = new Dictionary<string, string> { 
{"Date past to now","date_earliest" },
{ "Date now to past","date_latest"}
            };
            return View(viewModel);
        }
        


        // GET: Matches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            return View(match);
        }

        // GET: Matches/Create
        public ActionResult Create()
        {
            ViewBag.SeasonID = new SelectList(db.Seasons, "ID", "Name");
            return View();
        }

        // POST: Matches/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Date,Name,Medal,SeasonID")] Match match)
        {
            if (ModelState.IsValid)
            {
                db.Matches.Add(match);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SeasonID = new SelectList(db.Seasons, "ID", "Name", match.SeasonID);
            return View(match);
        }

        // GET: Matches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            ViewBag.SeasonID = new SelectList(db.Seasons, "ID", "Name", match.SeasonID);
            return View(match);
        }

        // POST: Matches/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Date,Name,Medal,SeasonID")] Match match)
        {
            if (ModelState.IsValid)
            {
                db.Entry(match).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SeasonID = new SelectList(db.Seasons, "ID", "Name", match.SeasonID);
            return View(match);
        }

        // GET: Matches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            return View(match);
        }

        // POST: Matches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Match match = db.Matches.Find(id);
            db.Matches.Remove(match);
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
