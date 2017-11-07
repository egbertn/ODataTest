using Microsoft.Owin.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    /// <summary>
    /// Simplified test environment for our internal WebApi services.
    /// </summary>
    public class ApiTestProvider<TStartup>
    {
        private static TestServer _server;
        private string _id_token;
        private string _username;
        private string _password;
        public ApiTestProvider()
        {
            _server = TestServer.Create<TStartup>();
        }
        public HttpClient Client

        {
            get
            {


                return
                    _server.HttpClient;
            }
        }
        /// <summary>
        /// Constructs and sends bearer token in the request headers
        /// </summary>
        /// <param name="id_token">Tha bearer token</param>
        public ApiTestProvider(string id_token)
            : this()
        {

            _id_token = id_token;
        }
        /// <summary>
        /// constructs and sends basic authentication credentials in headers
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public ApiTestProvider(string username, string password)
            : this()
        {

            _username = username;
            _password = password;
        }


        public RequestBuilder GetRequest(string path)
        {
            var builder = _server.CreateRequest(path);
            _server.BaseAddress = new Uri("http://localhost");
            if (!string.IsNullOrEmpty(_id_token))
            {
                builder.AddHeader("Authorization", $"Bearer {_id_token}");
            }
            else if (!string.IsNullOrEmpty(_username))
            {
                builder.AddHeader("Authorization", $"Basic {Convert.ToBase64String(Encoding.ASCII.GetBytes(_username + ":" + _password))}");
            }
            return builder;
        }

        public void Dispose()
        {
            _server.Dispose();

        }
    }
}
