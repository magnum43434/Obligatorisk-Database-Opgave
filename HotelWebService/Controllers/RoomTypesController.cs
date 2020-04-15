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
    public class RoomTypesController : ApiController
    {
        private HotelDBContext db = new HotelDBContext();

        // GET: api/RoomTypes
        public IQueryable<RoomType> GetRoomTypes()
        {
            return db.RoomTypes;
        }

        // GET: api/RoomTypes/5
        [ResponseType(typeof(RoomType))]
        public IHttpActionResult GetRoomType(string id)
        {
            RoomType roomType = db.RoomTypes.Find(id);
            if (roomType == null)
            {
                return NotFound();
            }

            return Ok(roomType);
        }

        // PUT: api/RoomTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRoomType(string id, RoomType roomType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != roomType.Type)
            {
                return BadRequest();
            }

            db.Entry(roomType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomTypeExists(id))
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

        // POST: api/RoomTypes
        [ResponseType(typeof(RoomType))]
        public IHttpActionResult PostRoomType(RoomType roomType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RoomTypes.Add(roomType);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RoomTypeExists(roomType.Type))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = roomType.Type }, roomType);
        }

        // DELETE: api/RoomTypes/5
        [ResponseType(typeof(RoomType))]
        public IHttpActionResult DeleteRoomType(string id)
        {
            RoomType roomType = db.RoomTypes.Find(id);
            if (roomType == null)
            {
                return NotFound();
            }

            db.RoomTypes.Remove(roomType);
            db.SaveChanges();

            return Ok(roomType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RoomTypeExists(string id)
        {
            return db.RoomTypes.Count(e => e.Type == id) > 0;
        }
    }
}