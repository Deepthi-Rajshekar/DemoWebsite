using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TechnicalCourses.Models;

namespace TechnicalCourses.Controllers
{
    public class TutorsController : ApiController
    {
        private TechnicalCoursesContext db = new TechnicalCoursesContext();

        // GET: api/Tutors
        public IQueryable<Tutor> GetTutors()
        {
            return db.Tutors;
        }

        // GET: api/Tutors/5
        [ResponseType(typeof(Tutor))]
        public async Task<IHttpActionResult> GetTutor(int id)
        {
            Tutor tutor = await db.Tutors.FindAsync(id);
            if (tutor == null)
            {
                return NotFound();
            }

            return Ok(tutor);
        }

        // PUT: api/Tutors/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTutor(int id, Tutor tutor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tutor.Id)
            {
                return BadRequest();
            }

            db.Entry(tutor).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TutorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Tutors
        [ResponseType(typeof(Tutor))]
        public async Task<IHttpActionResult> PostTutor(Tutor tutor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tutors.Add(tutor);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tutor.Id }, tutor);
        }

        // DELETE: api/Tutors/5
        [ResponseType(typeof(Tutor))]
        public async Task<IHttpActionResult> DeleteTutor(int id)
        {
            Tutor tutor = await db.Tutors.FindAsync(id);
            if (tutor == null)
            {
                return NotFound();
            }

            db.Tutors.Remove(tutor);
            await db.SaveChangesAsync();

            return Ok(tutor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TutorExists(int id)
        {
            return db.Tutors.Count(e => e.Id == id) > 0;
        }
    }
}