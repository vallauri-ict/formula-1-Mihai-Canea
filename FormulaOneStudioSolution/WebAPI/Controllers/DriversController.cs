using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using FormulaOneDLL;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DriversController : ApiController
    {
        DbTools dbTools = new DbTools();
        //Driver[] drivers = new Driver[]
        // {
        //    new Driver {PathImage = "Tomato Soup", Name = "Groceries", Team = "Ferrari" },
        //    new Driver {PathImage = "Yo-yo", Name = "Toys",  Team = "Ferrari"},
        //    new Driver {PathImage = "Hammer", Name = "Hardware",  Team = "Ferrari" }
        // };

        public IEnumerable<Driver> GetAllDrivers()
        {
            return dbTools.loadDrivers();
        }

        public IHttpActionResult GetDriver(int id)
        {
            return null;
        }
    }
}
