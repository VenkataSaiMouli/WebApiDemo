using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEBAPISBA.Models;
namespace WEBAPISBA.Controllers
{
    public class SuppliersController : ApiController
    {
        WCFEntities db = new WCFEntities();
        public IHttpActionResult Get()
        {
            return Ok(db.SUPPLIERs.ToArray());
        }
        public IHttpActionResult Get(string id)
        {
            if (id == null)
            {
                return BadRequest("Invalid SUPLNO. should not be null");
            }

            var Obj = db.SUPPLIERs.Find(id);
            if (Obj == null)
            {
                return NotFound();
            }
            return Ok(Obj);

        }

        //post
        public IHttpActionResult Post(SUPPLIER obj)
        {
            db.SUPPLIERs.Add(obj);
            int NoOfRowsAffected = db.SaveChanges();
            if (NoOfRowsAffected > 0)
            {
                return StatusCode(HttpStatusCode.Created);
            }
            {
                return BadRequest("Failed to add Suppliers");
            }
        }

        //update
        public IHttpActionResult Put(SUPPLIER obj)
        {
            db.SUPPLIERs.Attach(obj);
            db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            var NoOfRowsAffected = db.SaveChanges();
            if (NoOfRowsAffected > 0)
            {
                return StatusCode(HttpStatusCode.Accepted);

            }
            else
            {
                return BadRequest("Failed to update Suppliers");
            }

        }

        public IHttpActionResult Delete(string id)
        {
            var obj = db.SUPPLIERs.Find(id);
            if (id ==null)
            {
                return NotFound();
            }
            db.SUPPLIERs.Remove(obj);
            var NoOfRowsAffected = db.SaveChanges();
            if (NoOfRowsAffected > 0)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                return BadRequest("Failed to delete");
            }
        }
    }
}
