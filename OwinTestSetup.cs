using System;
using Nancy.Testing;
using Microsoft.Owin.Testing;
using System.Net.Http;

namespace xUnitNancyv2Bug
{
    public class OwinTestSetup
    {
        public HttpClient CreateHttpClient(Action<ConfigurableBootstrapper.ConfigurableBootstrapperConfigurator> configureBootstrapperAction)
        {
            var appRegistrations = new AppRegistrations();

            appRegistrations.Bootstrapper = new ConfigurableBootstrapper(configureBootstrapperAction);

            var client = TestServer.Create(builder =>
                new Startup(appRegistrations)
                .Configuration(builder))
                .HttpClient;

            client.DefaultRequestHeaders.Add("Accept", "application/json");
           
            return client;
        }
    }
}

