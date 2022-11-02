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
using WebApiLast.Entity;
using WebApiLast.Models;

namespace WebApiLast.Controllers
{
    public class ProductStaffsController : ApiController
    {
        private StaffEntities db = new StaffEntities();

        // GET: api/ProductStaffs
        [ResponseType(typeof(List<ProductModel>))]
        public IHttpActionResult GetProductStaff()
        {
            return Ok(db.ProductStaff.ToList().ConvertAll(x => new ProductModel(x)));
        }

        // GET: api/ProductStaffs/5
        [ResponseType(typeof(ProductStaff))]
        public IHttpActionResult GetProductStaff(int id)
        {
            ProductStaff productStaff = db.ProductStaff.Find(id);
            if (productStaff == null)
            {
                return NotFound();
            }

            return Ok(productStaff);
        }

        // PUT: api/ProductStaffs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProductStaff(int id, ProductStaff productStaff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productStaff.id)
            {
                return BadRequest();
            }

            db.Entry(productStaff).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductStaffExists(id))
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

        // POST: api/ProductStaffs
        [ResponseType(typeof(ProductStaff))]
        public IHttpActionResult PostProductStaff(ProductStaff productStaff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductStaff.Add(productStaff);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = productStaff.id }, productStaff);
        }

        // DELETE: api/ProductStaffs/5
        [ResponseType(typeof(ProductStaff))]
        public IHttpActionResult DeleteProductStaff(int id)
        {
            ProductStaff productStaff = db.ProductStaff.Find(id);
            if (productStaff == null)
            {
                return NotFound();
            }

            db.ProductStaff.Remove(productStaff);
            db.SaveChanges();

            return Ok(productStaff);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductStaffExists(int id)
        {
            return db.ProductStaff.Count(e => e.id == id) > 0;
        }
    }
}