namespace BlobFunctions.Servicio.ProcesamientoServicio
{
    using BlobFunctions.Entities.Helpers;
    using BlobFunctions.Entities.Models;
    using BlobFunctions.Servicio.Interface;
    using System;
    using System.Text;
    using System.Threading.Tasks;

    public class ProcesarFuncionService : IProcesarFuncionService
    {
        public IBlobStorageService IBlobStorageService { get; set; }
        public ProcesarFuncionService(IBlobStorageService IBlobStorageService)
        {        
            this.IBlobStorageService = IBlobStorageService;
        }
        public async Task<ModeloRespuesta> ProcesarDescarga(InfoArchivo infoArchivo)
        {
            ModeloRespuesta rpta = new();
            byte[] archivo = 
                await IBlobStorageService.DescargarArchivoDeContenedorBlobStorage(infoArchivo.NombreArchivo, infoArchivo.ContenedorArchivo);
            if (archivo != null)
            {
                rpta.EsExitoso = true;
                rpta.Respuesta = "Se descargó correctamente el archivo";
                rpta.RespuestaArchivo = Convert.ToBase64String(archivo);
            }
            else
            {
                rpta.EsExitoso = false;
                rpta.Respuesta = "No se pudo descargar el archivo";
            }

            return rpta;
        }
        public async Task<ModeloRespuesta> ProcesarSubida(InfoArchivo infoArchivo)
        {
            ModeloRespuesta rpta = new();

            byte[] archivo = Convert.FromBase64String(infoArchivo.Archivo);

            string respuesta = 
                await IBlobStorageService.SubirArchivoDeContenedorBlobStorage(infoArchivo.NombreArchivo, infoArchivo.ContentType,
                infoArchivo.ContenedorArchivo, archivo);
            if (archivo != null)
            {
                rpta.EsExitoso = true;
                rpta.Respuesta = "Se subió correctamente el archivo";
                rpta.RespuestaArchivo = respuesta;
            }
            else
            {
                rpta.EsExitoso = false;
                rpta.Respuesta = "No se pudo subir el archivo";
            }

            return rpta;
        }
    }
}
