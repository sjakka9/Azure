using System;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.Core;


class Program
{
    static async Task Main(string[] args)
    {
        
        //string subscriptionId = "65175cec-5ae8-4d72-8711-a94c4b213ba5";

        // Resource and storage account details
        string resourceGroupName = "exampro123";
        //string storageAccountName = "hellowrold123456"; // Must be globally unique
        string location = "WestUS2";

        
        var credential = new DefaultAzureCredential();
        // First, initialize the ArmClient and get the default subscription
        ArmClient client = new ArmClient(credential);

        // Now we get a ResourceGroupResource collection for that subscription
        SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
        ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();

        // With the collection, we can create a new resource group with an specific name
        ResourceGroupData resourceGroupData = new ResourceGroupData(location);
        ArmOperation<ResourceGroupResource> operation = await resourceGroups.CreateOrUpdateAsync(WaitUntil.Completed, resourceGroupName, resourceGroupData);
        ResourceGroupResource resourceGroup = operation.Value;

        Console.WriteLine("Resource Group created successfully!");

    }
}


