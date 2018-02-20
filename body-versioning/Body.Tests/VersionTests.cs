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

        [Fact]
        public async Task OperationOnV2()
        {
            Models.V2.Project data = GetV2DataModel();

            var versionedObject = new VersionedObject()
            {
                Version = "v2",
                Data = data
            };

            var dataReturned = await _client.PostObject<Models.V2.Project>("/api/operations", versionedObject);

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

        private static Models.V2.Project GetV2DataModel()
        {
            var random = new Random();
            return new Models.V2.Project()
            {
                ProjectId = random.Next(),
                ProjectName = "MyFirstProject",
                ProjectDescription = "MyFirstProjectDescription",
                Tasks = new List<Models.V2.TaskItem>()
                    {
                        new Models.V2.TaskItem()
                        {
                            TaskId = random.Next(),
                            TaskName = "MyFirstTask",
                            TaskDescription = "MyFirstTaskDescription",
                            Users = new List<Models.V2.User>()
                            {
                                new Models.V2.User()
                                {
                                    UserId = random.Next(),
                                    UserName = "MyUser1"
                                }
                            }
                        },
                        new Models.V2.TaskItem()
                        {
                            TaskId = random.Next(),
                            TaskName = "MySecondTask",
                            TaskDescription = "MySecondTaskDescription",
                            Users = new List<Models.V2.User>()
                            {
                                new Models.V2.User()
                                {
                                    UserId = random.Next(),
                                    UserName = "MyUser1"
                                },
                                new Models.V2.User()
                                {
                                    UserId = random.Next(),
                                    UserName = "MyUser2"
                                }
                            }
                        }
                    }
            };
        }
    }
}
