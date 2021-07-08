using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDinkToPdf
{
    public class TemplateGenerator
    {
        public string GetHTMLString(string documento)
        {
            //"gtitanalmc"
            //gtcomparte

            return GetBlob("gtcomparte", documento);
        }


        private string GetBlob(string containerName, string fileName)
        {
            string connectionString = $"DefaultEndpointsProtocol=https;AccountName=gtitanalmc;AccountKey=ppRogNGtN3/B4/GnLaewatL0+P9XQTomoRzGx/dfXV20mcsdNmyLLj+oNP9YX9QtRPCpcJTOCIm88fqvSkzJFQ==;EndpointSuffix=core.windows.net";

            // Setup the connection to the storage account
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);

            // Connect to the blob storage
            CloudBlobClient serviceClient = storageAccount.CreateCloudBlobClient();
            // Connect to the blob container
            CloudBlobContainer container = serviceClient.GetContainerReference($"{containerName}");
            // Connect to the blob file
            CloudBlockBlob blob = container.GetBlockBlobReference($"{fileName}");
            // Get the blob file as text
            string contents = blob.DownloadTextAsync().Result;

            return contents;
        }
    }
}
