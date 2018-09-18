using System;

namespace DotNetCoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var kvHelper = new KeyVaultHelper();
            var subscriptionId = kvHelper.GetSecret("subscription-id"); 
            var clientId = kvHelper.GetSecret("client-id"); 
            var clientKey = kvHelper.GetSecret("client-key");
            var tenantId = kvHelper.GetSecret("tenant-id");   
            Console.WriteLine(string.Format("subscriptionId: {0}", subscriptionId));
            Console.WriteLine(string.Format("clientId: {0}", clientId));
            Console.WriteLine(string.Format("clientKey: {0}", clientKey));
            Console.WriteLine(string.Format("tenantId: {0}", tenantId));
        }
    }
}