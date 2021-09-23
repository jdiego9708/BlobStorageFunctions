namespace BlobFunctions.Core.Servicio
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Storage.Blob;
    using Microsoft.WindowsAzure.Storage;
    using BlobFunctions.Core.Interface;
    using BlobFunctions.Entities.Helpers;
    using Entities.Models;

    public class HelperBlobStorage : IHelperBlobStorage
    {
        public async Task<string> SubirArchivoDeContenedorBlobStorage(string nombreArchivo, 
            string contentType, string contenedor, byte[] archivo)
        {
            try
            {
                CloudBlobContainer container = await ConfiguracionContainer(contenedor);
                CloudBlockBlob blob = container.GetBlockBlobReference(nombreArchivo);
                Stream mem = new MemoryStream();
                blob.Properties.ContentType = contentType;

                if (blob != null)
                {
                    await blob.UploadFromStreamAsync(new MemoryStream(archivo));

                    if (blob.Properties.Length >= 0)
                    {
                        string AbsoluteUri = blob.Uri.AbsoluteUri;
                        return AbsoluteUri;
                    }
                    else
                        throw new Exception();
                }
                else
                    throw new Exception();
            }
            catch (Exception ex)
            {
                ErrorHelper.ObtenerError(new ModeloError(ex));
                return null;
            }
        }
        public async Task<byte[]> DescargarArchivoDeContenedorBlobStorage(string nombreArchivo, string contenedor)
        {
            try
            {
                CloudBlobContainer container = await ConfiguracionContainer(contenedor);
                CloudBlockBlob blob = container.GetBlockBlobReference(nombreArchivo);
                Stream mem = new MemoryStream();

                if (blob != null)
                {
                    await blob.DownloadToStreamAsync(mem);
                }
                return ((MemoryStream)mem).ToArray();
            }
            catch (Exception ex)
            {
                ErrorHelper.ObtenerError(new ModeloError(ex));
                return null;
            }
        }
        private static async Task<CloudBlobContainer> ConfiguracionContainer(string contenedor)
        {
            // Create Reference to Azure Storage Account
            string defaultEndpointsProtocol = Convert.ToString(Environment.GetEnvironmentVariable("DefaultEndpointsProtocol"));
            string accountName = Convert.ToString(Environment.GetEnvironmentVariable("AccountName"));
            string acountKey = Convert.ToString(Environment.GetEnvironmentVariable("AccountKey"));
            string endPointSuffix = Convert.ToString(Environment.GetEnvironmentVariable("EndpointSuffix"));

            string strorageconn = $"DefaultEndpointsProtocol={defaultEndpointsProtocol};AccountName={accountName};AccountKey={acountKey};EndpointSuffix={endPointSuffix}";
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
