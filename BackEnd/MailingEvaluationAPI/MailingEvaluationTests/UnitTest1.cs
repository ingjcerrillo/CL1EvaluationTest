using MailingEvaluationAPI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net;
using Xunit;

namespace MailingEvaluationTests
{
    public class UnitTest1
    {
        protected TestServer testServer;
        [Fact]
        public async void GetEmailSubscriberEndpointIsAccesible()
        {
            //Arrange
            var webBuilder = new WebHostBuilder();
            webBuilder.UseStartup<Startup>();

            testServer = new TestServer(webBuilder);
            //Act
            var response = await testServer.CreateRequest("/api/mailing/getSubscribers?LastName&SortAscending=true").SendAsync("GET");

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
