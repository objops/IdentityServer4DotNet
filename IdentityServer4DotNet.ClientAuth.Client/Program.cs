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
            var tokenClient = new TokenClient(client, new TokenClientOptions
            {
                Address = "http://localhost:5000/connect/token",
                ClientId = "client",
                ClientSecret = "secret"
            });
            var response = await tokenClient.RequestClientCredentialsTokenAsync("api1");

            Console.WriteLine(response.AccessToken);
            client.SetBearerToken(response.AccessToken);
            string resStr = await client.GetStringAsync("http://localhost:5001/identity");
            Console.WriteLine(resStr);
            Console.ReadLine();
        }


    }
}
