using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TechnicalCourses.Models;

namespace TechnicalCourses.Controllers
{
    public class Offices1Controller : Controller
    {
        private TechnicalCoursesContext db = new TechnicalCoursesContext();

        int page_size = 15;

        // GET: Offices1
        public async Task<ActionResult> Index(int page = 0)
        {
            var offices = db.Offices.Include(a => a.Tutor).OrderBy(a => a.Location)
                           .Skip(page * page_size)
                           .Take(page_size);

            return View(await offices.ToListAsync());
        }

        // GET: Offices1/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Office office = await db.Offices.FindAsync(id);
            if (office == null)
            {
                return HttpNotFound();
            }
            return View(office);
        }

        // GET: Offices1/Create
        public ActionResult Create()
        {
            ViewBag.TutorId = new SelectList(db.Tutors, "Id", "Name");
            return View();
        }

        // POST: Offices1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Officeid,Location,TutorId")] Office office)
        {
            if (ModelState.IsValid)
            {
                db.Offices.Add(office);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.TutorId = new SelectList(db.Tutors, "Id", "Name", office.TutorId);
            return View(office);
        }

        // GET: Offices1/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Office office = await db.Offices.FindAsync(id);
            if (office == null)
            {
                return HttpNotFound();
            }
            ViewBag.TutorId = new SelectList(db.Tutors, "Id", "Name", office.TutorId);
            return View(office);
        }

        // POST: Offices1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Officeid,Location,TutorId")] Office office)
        {
            if (ModelState.IsValid)
            {
                db.Entry(office).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.TutorId = new SelectList(db.Tutors, "Id", "Name", office.TutorId);
            return View(office);
        }

        // GET: Offices1/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Office office = await db.Offices.FindAsync(id);
            if (office == null)
            {
                return HttpNotFound();
            }
            return View(office);
        }

        // POST: Offices1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Office office = await db.Offices.FindAsync(id);
            db.Offices.Remove(office);
            await db.SaveChangesAsync();
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
