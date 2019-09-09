using System.Collections.Generic;
using Tests.Helpers;
using Tests.Models;
using Tests.Enums;
using NUnit.Framework;
using FluentAssertions;
using FluentAssertions.Execution;

namespace Tests
{
    public class Tests
    {
        ApiHelper apiHelper;
        private List<LogicalServer> logicalServerList;
        
        [SetUp]
        public void Setup()
        {
            apiHelper = new ApiHelper();
            logicalServerList = apiHelper.GetVPNServerResponse(); // Get list of LogicalServers from response
        }

        [Test]
        public void TestResponseValidation_Expect_DataAreValid()
        {
            using (new AssertionScope()) // Let me validate all items in list
            {
                foreach (var logicalServer in logicalServerList)
                {
                    TestHelper.ValidateLogicalServerObject(logicalServer);
                }
            }
        }

        [Test]
        public void TestSecureCoreSErver_Expect_SecureCoreServerPresent() 
        {
            var coreServers = logicalServerList.FindAll(ls => ls.Features == Features.SecureCoreServer);
            coreServers.Should().NotBeNullOrEmpty("There should be at least one CORE server present");
            coreServers.Find(ls => ls.Status == Status.On).Should().NotBeNull("At least one CORE server should be running");
        }

        [Test]
        public void TestBasicServer_Expect_BasicServerPresent() 
        {
            var basicServers = logicalServerList.FindAll(ls => ls.Features == Features.BasicServer);
            basicServers.Should().NotBeNullOrEmpty("There should be at least one Basic server present");
            basicServers.Find(ls => ls.Status == Status.On).Should().NotBeNull("At least one Basic server should be running");
        }

        [Test]
        public void TestFreeSErver_Expect_FreeServerPresent() 
        {
            var freeServers = logicalServerList.FindAll(ls => ls.Domain.Contains("-free"));
            freeServers.Should().NotBeNullOrEmpty("There should be at least one Basic server present");
            freeServers.Find(ls => ls.Status == Status.On).Should().NotBeNull("At least one Basic server should be running");
        }

        [Test]
        public void TestServerLoad_Expect_LoadNotHigh() 
        {
            using (new AssertionScope())
            {
                foreach (var logicalServer in logicalServerList)
                {
                    logicalServer.Load.Should().BeLessThan(90, $"Server {logicalServer.ID} Load should be in acceptable range");
                }
            }
        }
    }
}