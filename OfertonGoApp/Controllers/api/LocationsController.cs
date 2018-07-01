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
    public class LocationsController : ApiController
    {
        private ModelDB2 db = new ModelDB2();

        // GET: api/Locations
        public IQueryable<Location> GetLocation()
        {
            return db.Location;
        }

        // GET: api/Locations/5
        [ResponseType(typeof(Location))]
        public IHttpActionResult GetLocation(int id)
        {
            Location location = db.Location.Find(id);
            if (location == null)
            {
                return NotFound();
            }

            return Ok(location);
        }

        // GET: api/Stores/5/Locations
        [Route("api/Stores/{StoreId}/Locations")]
        public IQueryable<Location> GetBusinessStores(int storeId)
        {
            return db.Location.Where(x => x.id_store == storeId);
        }

        // PUT: api/Locations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLocation(int id, Location location)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != location.id_location)
            {
                return BadRequest();
            }

            db.Entry(location).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationExists(id))
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

        // POST: api/Locations
        [ResponseType(typeof(Location))]
        public IHttpActionResult PostLocation(Location location)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Location.Add(location);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = location.id_location }, location);
        }

        // DELETE: api/Locations/5
        [ResponseType(typeof(Location))]
        public IHttpActionResult DeleteLocation(int id)
        {
            Location location = db.Location.Find(id);
            if (location == null)
            {
                return NotFound();
            }

            db.Location.Remove(location);
            db.SaveChanges();

            return Ok(location);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LocationExists(int id)
        {
            return db.Location.Count(e => e.id_location == id) > 0;
        }
    }
}