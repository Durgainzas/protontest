using Tests.Models;
using Tests.Enums;
using FluentAssertions;

namespace Tests
{
    public static class TestHelper
    {
        public static void ValidateLogicalServerObject(LogicalServer logicalServer) 
        {
            logicalServer.ID.Should().NotBeNullOrEmpty("LogicalServer ID should not be Empty!");
            logicalServer.EntryCountry.Should().NotBeNullOrEmpty($"LogicalServer {logicalServer.ID} EntryCountry should not be Empty!");
            logicalServer.ExitCountry.Should().NotBeNullOrEmpty($"LogicalServer {logicalServer.ID} ExitCountry should not be Empty!");
            logicalServer.Name.Should().NotBeNullOrEmpty($"LogicalServer {logicalServer.ID} Name should not be Empty!");
            logicalServer.Domain.Should().NotBeNullOrEmpty($"LogicalServer {logicalServer.ID} Domain should not be Empty!");
            logicalServer.Load.Should().BeGreaterOrEqualTo(0, $"LogicalServer {logicalServer.ID} Load should not be Negative!");
            logicalServer.Tier.Should().BeOfType(typeof(int), $"LogicalServer {logicalServer.ID} Tier should be int!");
            logicalServer.Location.Lat.Should().NotBe(null, $"LogicalServer Latitude {logicalServer.ID} should not be null!");
            logicalServer.Location.Long.Should().NotBe(null, $"LogicalServer Longtitude {logicalServer.ID} should not be null!");
            logicalServer.Score.Should().BeOfType(typeof(double), $"LogicalServer {logicalServer.ID} Score should be of type double!");

            foreach (var server in logicalServer.Servers)
            {
                ValidateServerObject(server);
            }
        }

        private static void ValidateServerObject(Server server)
        {
            server.ID.Should().NotBeNullOrEmpty("Server ID should not be Empty!");
            server.EntryIP.Should().NotBeNullOrEmpty($"Server {server.ID} EntryIP should not be Empty!");
            server.ExitIP.Should().NotBeNullOrEmpty($"Server {server.ID} ExitIP should not be Empty!!");
            server.Domain.Should().NotBeNullOrEmpty($"Server {server.ID} Domain should not be Empty!");
        }
    }
}