using ODataTest.Models;
using Owin;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace ODataTest.App_Start
{
    /// <summary>
    /// raldi dal
    /// </summary>
    public static class ODataConfig
    {
        /// <summary>
        /// Lah di dah
        /// </summary>
        /// <param name="app">passes stuff for Lah di dah</param>
        /// <param name="config">Extra stuff</param>
        public static void Configuration(IAppBuilder app, HttpConfiguration config)
        {
            var builder = new ODataConventionModelBuilder(config) { Namespace = typeof(Company).Namespace };

            var companyEntity = builder.EntitySet<Company>("Companies").EntityType;
            builder.ComplexType<Address>();
            // this is what we support
            config.Count().Filter().OrderBy().Select().MaxTop(null).Expand();

            config.MapODataServiceRoute("ODataRoute", "odata", builder.GetEdmModel());
        }

      
      
    }
}