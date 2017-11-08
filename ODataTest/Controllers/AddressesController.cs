using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using System.Web.Http.OData.Routing;
using ODataTest.Models;
using Microsoft.Data.OData;
using System.Web.OData.Routing;

namespace ODataTest.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using ODataTest.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Address>("Addresses");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    [ODataRoutePrefix("Addresses")]
    public class AddressesController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();

        // GET: odata/Addresses
        public async Task<IHttpActionResult> GetAddresses(ODataQueryOptions<Address> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            // return Ok<IEnumerable<Address>>(addresses);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // GET: odata/Addresses(5)
        public async Task<IHttpActionResult> GetAddress([FromODataUri] System.Guid key, ODataQueryOptions<Address> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            // return Ok<Address>(address);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PUT: odata/Addresses(5)
        public async Task<IHttpActionResult> Put([FromODataUri] System.Guid key, Delta<Address> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Put(address);

            // TODO: Save the patched entity.

            // return Updated(address);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // POST: odata/Addresses
        public async Task<IHttpActionResult> Post(Address address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Add create logic here.

            // return Created(address);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PATCH: odata/Addresses(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] System.Guid key, Delta<Address> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Patch(address);

            // TODO: Save the patched entity.

            // return Updated(address);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // DELETE: odata/Addresses(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] System.Guid key)
        {
            // TODO: Add delete logic here.

            // return StatusCode(HttpStatusCode.NoContent);
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}
