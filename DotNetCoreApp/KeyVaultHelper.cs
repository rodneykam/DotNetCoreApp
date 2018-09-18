using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Threading.Tasks;
using Microsoft.Azure.KeyVault;

namespace DotNetCoreApp
{
    class KeyVaultHelper
    {
        private KeyVaultClient kvClient { get; set; }
        public KeyVaultHelper()
        {
            kvClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(KeyVaultHelper.GetToken));
        }

        //the method that will be provided to the KeyVaultClient
        public static async Task<string> GetToken(string authority, string resource, string scope)
        {
            var authContext = new AuthenticationContext(authority);
            ClientCredential clientCred = new ClientCredential(Environment.GetEnvironmentVariable("ClientId"),
                        Environment.GetEnvironmentVariable("ClientKey"));
            AuthenticationResult result = await authContext.AcquireTokenAsync(resource, clientCred);

            if (result == null)
                throw new InvalidOperationException("Failed to obtain the JWT token");

            return result.AccessToken;
        }

        public string GetSecret(string key)
        {
            var secretsURI = Environment.GetEnvironmentVariable("SecretsURI");
            var uri = secretsURI + "/secrets/" + key;
            // I put my GetToken method in a Utils class. Change for wherever you placed your method.
            //var kv = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(KeyVaultHelper.GetToken));
            var sec = (kvClient.GetSecretAsync(uri)).GetAwaiter().GetResult().Value;
            
            //I put a variable in a Utils class to hold the secret for general application use.
            return sec;
        }
    }
}