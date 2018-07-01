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
    public class FavoritesController : ApiController
    {
        private ModelDB2 db = new ModelDB2();

        // GET: api/Favorites
        public IQueryable<Favorite> GetFavorite()
        {
            return db.Favorite;
        }

        // GET: api/Favorites/5
        [ResponseType(typeof(Favorite))]
        public IHttpActionResult GetFavorite(int id)
        {
            Favorite favorite = db.Favorite.Find(id);
            if (favorite == null)
            {
                return NotFound();
            }

            return Ok(favorite);
        }

        // GET: api/Users/5/favorites
        [Route("api/Users/{userId}/Favorites")]
        public IQueryable<Favorite> GetUserFavorites(int userId)
        {
            return db.Favorite.Where(x=>x.id_user ==userId);
        }


        // PUT: api/Favorites/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFavorite(int id, Favorite favorite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != favorite.id_favorite)
            {
                return BadRequest();
            }

            db.Entry(favorite).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavoriteExists(id))
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

        // POST: api/Favorites
        [ResponseType(typeof(Favorite))]
        public IHttpActionResult PostFavorite(Favorite favorite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Favorite.Add(favorite);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = favorite.id_favorite }, favorite);
        }

        // DELETE: api/Favorites/5
        [ResponseType(typeof(Favorite))]
        public IHttpActionResult DeleteFavorite(int id)
        {
            Favorite favorite = db.Favorite.Find(id);
            if (favorite == null)
            {
                return NotFound();
            }

            db.Favorite.Remove(favorite);
            db.SaveChanges();

            return Ok(favorite);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FavoriteExists(int id)
        {
            return db.Favorite.Count(e => e.id_favorite == id) > 0;
        }
    }
}