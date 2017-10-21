using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PFoursquare.API.Base;

namespace PFoursquare.API.Controllers.v1
{
    public class VenuesController : BaseController
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return null;
        }
    }
}
