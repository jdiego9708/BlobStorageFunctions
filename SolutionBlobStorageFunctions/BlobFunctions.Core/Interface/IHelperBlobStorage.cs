using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobFunctions.Core.Interface
{
    public interface IHelperBlobStorage
    {
        Task<byte[]> DescargarArchivoDeContenedorBlobStorage(string nombreArchivo, string contenedor);
    }
}
