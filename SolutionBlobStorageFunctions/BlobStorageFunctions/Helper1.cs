using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobStorageFunctions
{
    public class Helper1
    {
        public async Task<byte[]> DescargarArchivoDeContenedorBlobStorage(string nombreArchivo)
        {
            try
            {
                JObject objSettings = new();
                CloudBlobContainer container = await ConfiguracionContainer(objSettings);
                CloudBlockBlob blob = container.GetBlockBlobReference(nombreArchivo);
                Stream mem = new MemoryStream();

                if (blob != null)
                {
                    await blob.DownloadToStreamAsync(mem);
                }
                return ((MemoryStream)mem).ToArray();
            }
            catch (Exception)
            {
                return null;
            }
        }
        private async Task<CloudBlobContainer> ConfiguracionContainer(JObject settings)
        {

            // Create Reference to Azure Storage Account
            string defaultEndpointsProtocol = Convert.ToString(settings["DefaultEndpointsProtocol"]);
            string accountName = Convert.ToString(settings["AccountName"]);
            string acountKey = Convert.ToString(settings["AccountKey"]);
            string endPointSuffix = Convert.ToString(settings["EndpointSuffix"]);
            string contenedor = Convert.ToString(settings["ContainerReference"]);

            string strorageconn = string.Format("DefaultEndpointsProtocol={0};AccountName={1};AccountKey={2};EndpointSuffix={3}", defaultEndpointsProtocol, accountName, acountKey, endPointSuffix);
            CloudStorageAccount storageacc = CloudStorageAccount.Parse(strorageconn);

            //Create Reference to Azure Blob
            CloudBlobClient blobClient = storageacc.CreateCloudBlobClient();

            //create if not exists a container

            CloudBlobContainer container = blobClient.GetContainerReference(contenedor);
            await container.CreateIfNotExistsAsync();

            return container;
        }
    }
}
