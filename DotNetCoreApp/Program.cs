using System;

namespace DotNetCoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var _vaultClientId = Environment.GetEnvironmentVariable("VaultClientId");
            var _vaultClientKey = Environment.GetEnvironmentVariable("VaultClientKey");
            var _vaultURI = Environment.GetEnvironmentVariable("VaultURI");
            
            Console.WriteLine(string.Format("Client Id: {0}", _vaultClientId));
            Console.WriteLine(string.Format("Client Key: {0}", _vaultClientKey));
            Console.WriteLine(string.Format("Client URI: {0}", _vaultURI));
        }
    }
}