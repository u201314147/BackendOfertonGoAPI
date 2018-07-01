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
using OfertonGoApp.Models;

namespace OfertonGoApp.Controllers.api
{
    public class BusinessesController : ApiController
    {
        private ModelDB2 db = new ModelDB2();

        // GET: api/Businesses
        public IQueryable<Business> GetBusiness()
        {
            return db.Business;
        }

        // GET: api/Businesses/5
        [ResponseType(typeof(Business))]
        public IHttpActionResult GetBusiness(int id)
        {
            Business business = db.Business.Find(id);
            if (business == null)
            {
                return NotFound();
            }

            return Ok(business);
        }

        // PUT: api/Businesses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBusiness(int id, Business business)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != business.id_business)
            {
                return BadRequest();
            }

            db.Entry(business).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessExists(id))
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

        // POST: api/Businesses
        [ResponseType(typeof(Business))]
        public IHttpActionResult PostBusiness(Business business)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Business.Add(business);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = business.id_business }, business);
        }

        // DELETE: api/Businesses/5
        [ResponseType(typeof(Business))]
        public IHttpActionResult DeleteBusiness(int id)
        {
            Business business = db.Business.Find(id);
            if (business == null)
            {
                return NotFound();
            }

            db.Business.Remove(business);
            db.SaveChanges();

            return Ok(business);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BusinessExists(int id)
        {
            return db.Business.Count(e => e.id_business == id) > 0;
        }
    }
}