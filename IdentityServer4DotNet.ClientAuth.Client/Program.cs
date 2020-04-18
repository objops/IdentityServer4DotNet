using System;
using System.IO;
using System.Net;
using System.Net.Http;
using IdentityModel.Client;

namespace IdentityServer4DotNet.ClientAuth.Client
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {

            var disco = await DiscoveryClient.GetAsync("http://localhost:5000");
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return;
            }

            //向IdentityServer请求令牌
            var tokenClient = new TokenClient(disco.TokenEndpoint, "client", "secret");
            var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }

            Console.WriteLine(tokenResponse.Json);
        }

        
    }
}
