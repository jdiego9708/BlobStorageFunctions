using BlobFunctions.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobFunctions.Servicio.Servicio
{
    public class BlobStorageService
    {
        public IHelperBlobStorage HelperBlobStorage;
        public BlobStorageService(IHelperBlobStorage HelperBlobStorage) 
        {
            this.HelperBlobStorage = HelperBlobStorage;  
        }
        public async Task<byte[]> DescargarArchivoDeContenedorBlobStorage(string nombreArchivo, string contenedor)
        {
            return await this.HelperBlobStorage.DescargarArchivoDeContenedorBlobStorage(nombreArchivo, contenedor);
        }
    }
}
