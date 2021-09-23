using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobFunctions.Servicio.Interface
{
    public interface IBlobStorageService
    {
        Task<byte[]> DescargarArchivoDeContenedorBlobStorage(string nombreArchivo, string contenedor);
    }
}
