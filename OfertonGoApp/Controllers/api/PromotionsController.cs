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
    public class PromotionsController : ApiController
    {
        private ModelDB2 db = new ModelDB2();

        // GET: api/Promotions
        public IQueryable<Promotion> GetPromotion()
        {
            return db.Promotion;
        }

        // GET: api/Promotions/5
        [ResponseType(typeof(Promotion))]
        public IHttpActionResult GetPromotion(int id)
        {
            Promotion promotion = db.Promotion.Find(id);
            if (promotion == null)
            {
                return NotFound();
            }

            return Ok(promotion);
        }
        // GET: api/Stores/5/Promotions
        [Route("api/Stores/{StoreId}/Promotions")]
        public IQueryable<Promotion> GetStorePromotion(int storeId)
        {
            return db.Promotion.Where(x => x.id_store == storeId);
        }

        // PUT: api/Promotions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPromotion(int id, Promotion promotion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != promotion.id_promotion)
            {
                return BadRequest();
            }

            db.Entry(promotion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PromotionExists(id))
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

        // POST: api/Promotions
        [ResponseType(typeof(Promotion))]
        public IHttpActionResult PostPromotion(Promotion promotion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Promotion.Add(promotion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = promotion.id_promotion }, promotion);
        }

        // DELETE: api/Promotions/5
        [ResponseType(typeof(Promotion))]
        public IHttpActionResult DeletePromotion(int id)
        {
            Promotion promotion = db.Promotion.Find(id);
            if (promotion == null)
            {
                return NotFound();
            }

            db.Promotion.Remove(promotion);
            db.SaveChanges();

            return Ok(promotion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PromotionExists(int id)
        {
            return db.Promotion.Count(e => e.id_promotion == id) > 0;
        }
    }
}