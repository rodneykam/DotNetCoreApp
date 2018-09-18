using System;

namespace DotNetCoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var _clientId = Environment.GetEnvironmentVariable("ClientId");
            var _clientKey = Environment.GetEnvironmentVariable("ClientKey");
            var _secretsURI = Environment.GetEnvironmentVariable("SecretsURI");
            
            Console.WriteLine(string.Format("Client Id: {0}", _clientId));
            Console.WriteLine(string.Format("Client Key: {0}", _clientKey));
            Console.WriteLine(string.Format("Client URI: {0}", _secretsURI));
        }
    }
}