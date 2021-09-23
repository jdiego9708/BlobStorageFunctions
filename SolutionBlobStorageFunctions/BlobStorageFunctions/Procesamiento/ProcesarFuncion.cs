namespace BlobStorageFunctions.Procesamiento
{
    using BlobFunctions.Entities.Helpers;
    using BlobFunctions.Entities.Models;
    using BlobFunctions.Servicio.Interface;
    using System;
    using System.Text;
    using System.Threading.Tasks;

    public class ProcesarFuncion
    {
        public IBlobStorageService IBlobStorageService { get; set; }
        public ProcesarFuncion()
        {        
            this.IBlobStorageService = DIHelper.GetService<IBlobStorageService>();
        }

        public async Task<ModeloRespuesta> ProcesarDescarga(InfoArchivo infoArchivo)
        {
            ModeloRespuesta respuesta = new();
            byte[] archivo = 
                await IBlobStorageService.DescargarArchivoDeContenedorBlobStorage(infoArchivo.NombreArchivo, infoArchivo.ContenedorArchivo);
            if (archivo != null)
            {
                respuesta.EsExitoso = true;
                respuesta.Respuesta = "Se descargó correctamente el archivo";
                respuesta.RespuestaArchivo = Convert.ToBase64String(archivo);
            }
            else
            {
                respuesta.EsExitoso = false;
                respuesta.Respuesta = "No se pudo descargar el archivo";
            }

            return respuesta;
        }

        public async Task<ModeloRespuesta> ProcesarSubida(InfoArchivo infoArchivo)
        {
            ModeloRespuesta respuesta = new();

            byte[] archivo = Convert.FromBase64String(infoArchivo.Archivo);

            string rpta = 
                await IBlobStorageService.SubirArchivoDeContenedorBlobStorage(infoArchivo.NombreArchivo, infoArchivo.ContentType,
                infoArchivo.ContenedorArchivo, archivo);
            if (archivo != null)
            {
                respuesta.EsExitoso = true;
                respuesta.Respuesta = "Se subió correctamente el archivo";
                respuesta.RespuestaArchivo = rpta;
            }
            else
            {
                respuesta.EsExitoso = false;
                respuesta.Respuesta = "No se pudo subir el archivo";
            }

            return respuesta;
        }
    }
}
