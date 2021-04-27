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
using API_Journal.Models;

namespace API_Journal.Controllers
{
    public class groupsController : ApiController
    {
        private Journal_appEntities db = new Journal_appEntities();

        // GET: api/groups
        [ResponseType(typeof(List<ResponseUser>))]
        public IHttpActionResult GetJournalApp_user()
        {
            return Ok(db.users.ToList().ConvertAll(p => new ResponseUser(p)));
        }

        // GET: api/groups/5
        [ResponseType(typeof(group))]
        public IHttpActionResult Getgroup(int id)
        {
            group group = db.group.Find(id);
            if (group == null)
            {
                return NotFound();
            }

            return Ok(group);
        }

        // PUT: api/groups/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putgroup(int id, group group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != group.id_group)
            {
                return BadRequest();
            }

            db.Entry(group).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!groupExists(id))
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

        // POST: api/groups
        [ResponseType(typeof(group))]
        public IHttpActionResult Postgroup(group group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.group.Add(group);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = group.id_group }, group);
        }

        // DELETE: api/groups/5
        [ResponseType(typeof(group))]
        public IHttpActionResult Deletegroup(int id)
        {
            group group = db.group.Find(id);
            if (group == null)
            {
                return NotFound();
            }

            db.group.Remove(group);
            db.SaveChanges();

            return Ok(group);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool groupExists(int id)
        {
            return db.group.Count(e => e.id_group == id) > 0;
        }
    }
}