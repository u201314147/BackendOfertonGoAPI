﻿using System;
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
    public class StoresController : ApiController
    {
        private ModelDB2 db = new ModelDB2();

        // GET: api/Stores
        public IQueryable<Store> GetStore()
        {
            return db.Store;
        }

        // GET: api/Stores/5
        [ResponseType(typeof(Store))]
        public IHttpActionResult GetStore(int id)
        {
            Store store = db.Store.Find(id);
            if (store == null)
            {
                return NotFound();
            }

            return Ok(store);
        }

        // PUT: api/Stores/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStore(int id, Store store)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != store.id_store)
            {
                return BadRequest();
            }

            db.Entry(store).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoreExists(id))
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

        // POST: api/Stores
        [ResponseType(typeof(Store))]
        public IHttpActionResult PostStore(Store store)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Store.Add(store);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = store.id_store }, store);
        }

        // GET: api/Businesses/5/Stores
        [Route("api/Businesses/{businessId}/Stores")]
        public IQueryable<Store> GetBusinessStores(int businessId)
        {
            return db.Store.Where(x => x.id_business == businessId);
        }


        // DELETE: api/Stores/5
        [ResponseType(typeof(Store))]
        public IHttpActionResult DeleteStore(int id)
        {
            Store store = db.Store.Find(id);
            if (store == null)
            {
                return NotFound();
            }

            db.Store.Remove(store);
            db.SaveChanges();

            return Ok(store);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StoreExists(int id)
        {
            return db.Store.Count(e => e.id_store == id) > 0;
        }
    }
}