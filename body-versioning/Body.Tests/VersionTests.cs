using Body.Models;
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
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task BasicGet()
        {
            var response = await _client.GetObject<IEnumerable<string>>("/api/operations");

            Assert.Contains("value1", response);
            Assert.Contains("value2", response);
        }

        [Fact]
        public async Task OperationOnV1()
        {
            Models.V1.Project data = GetV1DataModel();

            var versionedObject = new VersionedObject()
            {
                Version = "v1",
                Data = data
            };

            var dataReturned = await _client.PostObject<Models.V1.Project>("/api/operations", versionedObject);

            Assert.Equal(dataReturned.ProjectId, data.ProjectId);
        }

        private static Models.V1.Project GetV1DataModel()
        {
            return new Models.V1.Project()
            {
                ProjectId = Guid.NewGuid(),
                ProjectName = "MyFirstProject",
                Tasks = new List<Models.V1.TaskItem>()
                    {
                        new Models.V1.TaskItem()
                        {
                            TaskId = Guid.NewGuid(),
                            TaskName = "MyFirstTask"
                        },
                                                new Models.V1.TaskItem()
                        {
                            TaskId = Guid.NewGuid(),
                            TaskName = "MySecondTask"
                        }
                    }
            };
        }
    }
}
