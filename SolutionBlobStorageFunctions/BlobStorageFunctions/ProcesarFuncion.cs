using BlobFunctions.Entities.Helpers;
using BlobFunctions.Entities.Models;
using BlobFunctions.Servicio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobStorageFunctions
{
    public class ProcesarFuncion
    {
        public IBlobStorageService IBlobStorageService { get; set; }
        public ProcesarFuncion()
        {        
            this.IBlobStorageService = DIHelper.GetService<IBlobStorageService>();
        }

        public void Procesar(InfoArchivo infoArchivo)
        {
            Task.Factory.StartNew(async () => 
            await IBlobStorageService.DescargarArchivoDeContenedorBlobStorage(infoArchivo.NombreArchivo, infoArchivo.ContenedorArchivo));
        }
    }
}
