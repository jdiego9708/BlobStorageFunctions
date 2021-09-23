namespace BlobFunctions.Servicio.Servicio
{
    using BlobFunctions.Core.Interface;
    using BlobFunctions.Servicio.Interface;
    using System.Threading.Tasks;

    public class BlobStorageService : IBlobStorageService
    {
        public IHelperBlobStorage HelperBlobStorage;
        public BlobStorageService(IHelperBlobStorage HelperBlobStorage) 
        {
            this.HelperBlobStorage = HelperBlobStorage;  
        }

        public async Task<string> SubirArchivoDeContenedorBlobStorage(string nombreArchivo,
           string contentType, string contenedor, byte[] archivo)
        {
            return await this.HelperBlobStorage.SubirArchivoDeContenedorBlobStorage(nombreArchivo, contentType, contenedor, archivo);
        }

        public async Task<byte[]> DescargarArchivoDeContenedorBlobStorage(string nombreArchivo, string contenedor)
        {
            return await this.HelperBlobStorage.DescargarArchivoDeContenedorBlobStorage(nombreArchivo, contenedor);
        }
    }
}
