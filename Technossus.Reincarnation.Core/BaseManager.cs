using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Configuration;
using Technossus.Reincarnation.Data;

namespace Technossus.Reincarnation.Core
{
    public abstract class BaseManager
    {
        protected ReincarnationContext Context{ get; set;}
        public BaseManager(ReincarnationContext context) => Context = context;
        public CloudBlobContainer GetContainerByContainerName(string containerName)
        {
            //To do 
            //string connString = AppSettingsHelper.Instance.AzureStorageConnectionString;
            string connString = ConfigurationManager.AppSettings["AzureStorageConnectionString"];

            //Parse the connection string and return a reference to the storage account.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connString);

            //Create the blob client object.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            //Get a reference to a container to use for the sample code, and create it if it does not exist.
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);

            //create blob if not exist
            if (!container.Exists())
            {
                container.CreateIfNotExists();
            }

            return container;
        }
    }
}
