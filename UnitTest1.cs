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
            logicalServerList.Find(ls => ls.Features == Features.SecureCoreServer)
                .Should().NotBeNull("There should be at least one CORE server present");
        }

        [Test]
        public void TestBasicServer_Expect_BasicServerPresent() 
        {
            logicalServerList.Find(ls => ls.Features == Features.BasicServer)
                .Should().NotBeNull("There should be at least one Basic server present");
        }

        [Test]
        public void TestFreeSErver_Expect_FreeServerPresent() 
        {
            logicalServerList.FindAll(s => s.Domain.Contains("-free"))
                .Should().NotBeNullOrEmpty("There Should be at least one FREE server present");
        }
    }
}