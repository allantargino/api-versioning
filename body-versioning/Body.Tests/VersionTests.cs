using Body.Util;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Body.Tests
{
    public class VersionTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public VersionTests()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task Test1()
        {
            // Act
            var response = await _client.GetObject<IEnumerable<string>>("/api/operations");

            // Assert
            Assert.Contains("value1", response);
            Assert.Contains("value2", response);
        }
    }
}
