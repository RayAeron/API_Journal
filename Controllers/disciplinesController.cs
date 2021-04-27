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
    public class disciplinesController : ApiController
    {
        private Journal_appEntities db = new Journal_appEntities();

        // GET: api/disciplines
        public IQueryable<object> Getdiscipline()
        {
            return from a in db.discipline
                   join p in db.@group on a.id_group equals p.id_group into Group
                   join p in db.users on a.id_teacher equals p.id_user into Teacher
                   select new
                   {
                       id_discipline = a.id_discipline,
                       Name_discipline = a.Name_discipline,
                       group_name = Group.Select(ap => ap.Name_group),
                       surname_teacher = Teacher.Select(ap => ap.Surname),
                       name_teacher = Teacher.Select(ap => ap.Name),
                       patronymic_teacher = Teacher.Select(ap => ap.Patronymic),
                   };
        }

        // GET: api/disciplines/5
        [ResponseType(typeof(discipline))]
        public IHttpActionResult Getdiscipline(int id)
        {
            discipline discipline = db.discipline.Find(id);
            if (discipline == null)
            {
                return NotFound();
            }

            return Ok(discipline);
        }

        // PUT: api/disciplines/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putdiscipline(int id, discipline discipline)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != discipline.id_discipline)
            {
                return BadRequest();
            }

            db.Entry(discipline).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!disciplineExists(id))
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

        // POST: api/disciplines
        [ResponseType(typeof(discipline))]
        public IHttpActionResult Postdiscipline(discipline discipline)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.discipline.Add(discipline);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = discipline.id_discipline }, discipline);
        }

        // DELETE: api/disciplines/5
        [ResponseType(typeof(discipline))]
        public IHttpActionResult Deletediscipline(int id)
        {
            discipline discipline = db.discipline.Find(id);
            if (discipline == null)
            {
                return NotFound();
            }

            db.discipline.Remove(discipline);
            db.SaveChanges();

            return Ok(discipline);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool disciplineExists(int id)
        {
            return db.discipline.Count(e => e.id_discipline == id) > 0;
        }
    }
}