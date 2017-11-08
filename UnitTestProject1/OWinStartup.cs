using Microsoft.Owin;
using ODataTest.Models;
using Owin;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
[assembly: OwinStartup(typeof(UnitTestProject1.OWinStartup))]
namespace UnitTestProject1
{
    /// <summary>
    /// Startup class
    /// </summary>
    public partial class OWinStartup
    {
        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        public void Configuration(Owin.IAppBuilder app)
        {
            var config = new HttpConfiguration();


            config.MapHttpAttributeRoutes();//for some reason, this must happen after Cors

            ODataConfiguration(app, config);

            config.EnableDependencyInjection();

            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            //make sure no funny one tries XML instead of JSON
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            //  config.Services.Replace(typeof(IHostBufferPolicySelector), new NoBufferPolicySelector());
            app.UseWebApi(config);

            config.EnsureInitialized();


        }
        /// <summary>
        /// Lah di dah
        /// </summary>
        /// <param name="app">passes stuff for Lah di dah</param>
        /// <param name="config">Extra stuff</param>
        public static void ODataConfiguration(IAppBuilder app, HttpConfiguration config)
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
