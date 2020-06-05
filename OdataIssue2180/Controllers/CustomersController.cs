using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using OdataIssue2180.Code;

namespace OdataIssue2180.Controllers
{
    public class CustomersController : ODataController
    {
        [HttpGet]
        [EnableQuery]
        public IActionResult Get([FromServices]AppDbContext appDbContext)
        {
            // I am shocked to see the error does not occur when 
            //var nonDatabaseCustomers = appDbContext.Customers.ToList();
            //return Ok(nonDatabaseCustomers);
            return Ok(appDbContext.Customers);
        }
    }
}