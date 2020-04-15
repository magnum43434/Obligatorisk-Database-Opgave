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
using HotelWebService;

namespace HotelWebService.Controllers
{
    public class HotelFacilitiesController : ApiController
    {
        private HotelDBContext db = new HotelDBContext();

        // GET: api/HotelFacilities
        public IQueryable<HotelFacility> GetHotelFacilities()
        {
            return db.HotelFacilities;
        }

        // GET: api/HotelFacilities/5
        [ResponseType(typeof(HotelFacility))]
        public IHttpActionResult GetHotelFacility(int id)
        {
            HotelFacility hotelFacility = db.HotelFacilities.Find(id);
            if (hotelFacility == null)
            {
                return NotFound();
            }

            return Ok(hotelFacility);
        }

        // PUT: api/HotelFacilities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHotelFacility(int id, HotelFacility hotelFacility)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hotelFacility.HF_Id)
            {
                return BadRequest();
            }

            db.Entry(hotelFacility).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelFacilityExists(id))
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

        // POST: api/HotelFacilities
        [ResponseType(typeof(HotelFacility))]
        public IHttpActionResult PostHotelFacility(HotelFacility hotelFacility)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HotelFacilities.Add(hotelFacility);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hotelFacility.HF_Id }, hotelFacility);
        }

        // DELETE: api/HotelFacilities/5
        [ResponseType(typeof(HotelFacility))]
        public IHttpActionResult DeleteHotelFacility(int id)
        {
            HotelFacility hotelFacility = db.HotelFacilities.Find(id);
            if (hotelFacility == null)
            {
                return NotFound();
            }

            db.HotelFacilities.Remove(hotelFacility);
            db.SaveChanges();

            return Ok(hotelFacility);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HotelFacilityExists(int id)
        {
            return db.HotelFacilities.Count(e => e.HF_Id == id) > 0;
        }
    }
}