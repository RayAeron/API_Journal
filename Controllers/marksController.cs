using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using API_Journal.Entities;

namespace API_Journal.Controllers
{
    public class marksController : ApiController
    {
        private Journal_appEntities db = new Journal_appEntities();

        // GET: api/marks
        public IQueryable<object> Getmark()
        {
            return from a in db.mark
                   join p in db.mark on a.id_mark equals p.id_mark into Mark
                   join p in db.discipline on a.id_discipline equals p.id_discipline into Discipline
                   join p in db.users on a.id_student equals p.id_user into Student
                   select new
                   {
                       id_mark = a.id_mark,
                       mark = a.Mark,
                       date_mark = a.Date_mark,
                       email = Student.Select(ap => ap.Email),
                       discipline = Discipline.Select(ap => ap.Name_discipline),
                       surname_student = Student.Select(ap => ap.Surname),
                       name_student = Student.Select(ap => ap.Name),
                       patronymic_student = Student.Select(ap => ap.Patronymic),
                   };
        }

        // GET: api/marks/5
        [ResponseType(typeof(mark))]
        public IHttpActionResult Getmark(int id)
        {
            mark mark = db.mark.Find(id);
            if (mark == null)
            {
                return NotFound();
            }

            return Ok(mark);
        }

        // PUT: api/marks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putmark(int id, mark mark)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mark.id_mark)
            {
                return BadRequest();
            }

            db.Entry(mark).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!markExists(id))
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

        // POST: api/marks
        [ResponseType(typeof(mark))]
        public IHttpActionResult Postmark(mark mark)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.mark.Add(mark);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mark.id_mark }, mark);
        }

        // DELETE: api/marks/5
        [ResponseType(typeof(mark))]
        public IHttpActionResult Deletemark(int id)
        {
            mark mark = db.mark.Find(id);
            if (mark == null)
            {
                return NotFound();
            }

            db.mark.Remove(mark);
            db.SaveChanges();

            return Ok(mark);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool markExists(int id)
        {
            return db.mark.Count(e => e.id_mark == id) > 0;
        }
    }
}