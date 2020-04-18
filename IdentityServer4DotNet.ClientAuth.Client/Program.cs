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


            var client = new HttpClient();
            var tclient = new TokenClient(client, new TokenClientOptions
            {
                Address = "http://localhost:5000/connect/token",
                ClientId = "client",
                ClientSecret = "secret"
            });
            var response = await tclient.RequestClientCredentialsTokenAsync("api1");
            //var response = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            //{
            //    Address = "http://localhost:5000/connect/token",
            //    ClientId = "client",
            //    ClientSecret = "secret"
            //    ,
            //    Scope = "api1"

            //});

            Console.WriteLine(response.AccessToken);
            var nclient = new HttpClient();
            client.SetBearerToken(response.AccessToken);
            //nclient.RequestClientCredentialsAsync("api1");
            string resStr = await client.GetStringAsync("http://localhost:5001/identity");
            Console.WriteLine(resStr);
            Console.ReadLine();
            //var disco = await DiscoveryClient.GetAsync("http://localhost:5000");
            //if (disco.IsError)
            //{
            //    Console.WriteLine(disco.Error);
            //    return;
            //}

            ////向IdentityServer请求令牌
            //var tokenClient = new TokenClient(disco.TokenEndpoint, "client", "secret");
            //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

            //if (tokenResponse.IsError)
            //{
            //    Console.WriteLine(tokenResponse.Error);
            //    return;
            //}

            //Console.WriteLine(tokenResponse.Json);
        }


    }
}
