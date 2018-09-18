using System;
using Microsoft.Azure.KeyVault;

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

            // I put my GetToken method in a Utils class. Change for wherever you placed your method.
            var kv = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(Utils.GetToken));
            var sec = (kv.GetSecretAsync(_secretsURI)).GetAwaiter().GetResult().Value;
            
            //I put a variable in a Utils class to hold the secret for general application use.
            Utils.EncryptSecret = sec;
            Console.WriteLine(string.Format("Secrets: {0}", sec));
        }
    }
}