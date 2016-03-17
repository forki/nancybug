using System;
using Xunit;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;

namespace xUnitNancyv2Bug
{
    public class MyClass
    {
        [Fact]
        public async Task Should_Return_200_On_Allowed_Path()
        {
            //Given
            var client = this.CreateHttpClient();

            //When
            var response = await client.PostAsync("http://localhost/api/system/debug/allowedroute", new StringContent(string.Empty));

            //Then
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        private HttpClient CreateHttpClient()
        {
            var setup = new OwinTestSetup();
            return setup.CreateHttpClient(with =>
                {
                    with.Module<SystemModule>();

                });
        }
    }
}

