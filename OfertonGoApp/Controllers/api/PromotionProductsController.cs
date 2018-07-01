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
    public class PromotionProductsController : ApiController
    {
        private ModelDB2 db = new ModelDB2();

        // GET: api/PromotionProducts
        public IQueryable<PromotionProduct> GetPromotionProduct()
        {
            return db.PromotionProduct;
        }

        // GET: api/PromotionProducts/5
        [ResponseType(typeof(PromotionProduct))]
        public IHttpActionResult GetPromotionProduct(int id)
        {
            PromotionProduct promotionProduct = db.PromotionProduct.Find(id);
            if (promotionProduct == null)
            {
                return NotFound();
            }

            return Ok(promotionProduct);
        }


        // GET: api/Stores/5/Locations
        [Route("api/Stores/{StoreId}/PromotionProducts")]
        public IQueryable<PromotionProduct> GetStorePromotionProducts(int storeId)
        {
            return db.PromotionProduct.Where(x => x.id_store == storeId);
        }


        // PUT: api/PromotionProducts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPromotionProduct(int id, PromotionProduct promotionProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != promotionProduct.id_promotion_product)
            {
                return BadRequest();
            }

            db.Entry(promotionProduct).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PromotionProductExists(id))
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

        // POST: api/PromotionProducts
        [ResponseType(typeof(PromotionProduct))]
        public IHttpActionResult PostPromotionProduct(PromotionProduct promotionProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PromotionProduct.Add(promotionProduct);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = promotionProduct.id_promotion_product }, promotionProduct);
        }

        // DELETE: api/PromotionProducts/5
        [ResponseType(typeof(PromotionProduct))]
        public IHttpActionResult DeletePromotionProduct(int id)
        {
            PromotionProduct promotionProduct = db.PromotionProduct.Find(id);
            if (promotionProduct == null)
            {
                return NotFound();
            }

            db.PromotionProduct.Remove(promotionProduct);
            db.SaveChanges();

            return Ok(promotionProduct);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PromotionProductExists(int id)
        {
            return db.PromotionProduct.Count(e => e.id_promotion_product == id) > 0;
        }
    }
}