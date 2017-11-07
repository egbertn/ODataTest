using Microsoft.Owin;
using ODataTest.App_Start;
using Owin;
using System.Web.Http;
using System.Web.OData.Extensions;

[assembly: OwinStartup(typeof(ODataTest.Startup))]

namespace ODataTest
{


    /// <summary>
    /// Startup class
    /// </summary>
    public partial class Startup
    {
        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();


            config.MapHttpAttributeRoutes();//for some reason, this must happen after Cors

            ODataConfig.Configuration(app, config);

            config.EnableDependencyInjection();

            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
          
            //make sure no funny one tries XML instead of JSON
            config.Formatters.Remove(config.Formatters.XmlFormatter);
          //  config.Services.Replace(typeof(IHostBufferPolicySelector), new NoBufferPolicySelector());
            app.UseWebApi(config);

            config.EnsureInitialized();

           
        }
    }
}