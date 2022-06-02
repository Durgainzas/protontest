using System.Collections.Generic;
using System.Net;
using Tests.Models;
using FluentAssertions;
using RestSharp;
using System.Threading.Tasks;

namespace Tests.Helpers
{
    public class ApiHelper
    {
        public RestClient Client {get ; private set;}

        public ApiHelper()
        {
            Client = new RestClient();
        }

        async public Task<List<LogicalServer>> GetVPNServerResponse() 
        {

            var request = new RestRequest("https://api.protonmail.ch/vpn/logicals", Method.Get);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Connection", "keep-alive");
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("Host", "api.protonmail.ch");
            request.AddHeader("Postman-Token", "940920c7-7d32-4b3a-b60c-90846b022a37,c060e700-5caa-4772-8c73-3d2f7b30c089");
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("User-Agent", "PostmanRuntime/7.15.2");

            var response = await Client.GetAsync<VPNLogicalsModel>(request);

            
            return response.LogicalServers;
        }
    }
}