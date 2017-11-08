using ODataTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Query;
using System.Web.OData.Routing;

namespace ODataTest.Controllers
{
    [ODataRoutePrefix("Companies")]
    [EnableQuery]
    public class CompaniesController: ODataController
    {
        public CompaniesController()
        {
            if (Companies==null)
            {
                Companies = new[] 
                {
                    new Company() {Id = Guid.Parse ("C26F0FE8-98BC-41F0-8957-78270AB2C545"), Name = "Profit Inc"  , Addresses = new []{ new Address {Id = Guid.Parse("C04CCD62-91EE-485B-88A3-F1936AFD30AE"), Street="Street", StreetSuffix="No 1", ZipCode = "123123" } } },
                    new Company() { Id = Guid.Parse("C69B1B42-F13F-4308-A673-7139D22BE1BB"), Name="Fat Corp."}
                };
            }
        }
        private static readonly ODataValidationSettings settings = new ODataValidationSettings()
        {
            // Initialize settings as needed.
            AllowedFunctions = AllowedFunctions.All | AllowedFunctions.Any,
            MaxExpansionDepth = 4
        };
        private static IEnumerable<Company> Companies { get; set; }
        public async Task<IHttpActionResult> Get(ODataQueryOptions<Company> options)
        {
            return Ok(Companies);
        }
        public async Task<IHttpActionResult> Get(Guid key, ODataQueryOptions<Company> options = null)
        {
            var result = Companies.FirstOrDefault(f => f.Id == key);
            return Ok(result);
        }
        public async Task<IHttpActionResult> Post(Company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Companies = Companies.Union(new[] { company });
            return Created(company);
        }
        public IHttpActionResult Delete(Guid key)
        {
            Companies = Companies.Where(f => f.Id != key);
            return StatusCode(HttpStatusCode.NoContent);

        }
        [AcceptVerbs("PUT", "POST")]
        public async Task<IHttpActionResult> CreateRef([FromODataUri]Guid key, string navigationProperty, [FromBody] Uri link)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //navigationProperty must be 'Addresses' here
            var result = Companies.FirstOrDefault(f => f.Id == key);
            if (result == null)
            {
                return NotFound();
            }
          //  companyDelta.Patch(result);
            return Updated(result);

        }
    }
}