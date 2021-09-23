using System.IO;
using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using BlobFunctions.Entities.Models;
using BlobFunctions.Entities.Helpers;
using BlobStorageFunctions.Procesamiento;

namespace BlobStorageFunctions.Controladores
{
    public static class FunctionsBlob
    {
        [Function("Blob_ObtenerArchivo")]
        public static async Task<HttpResponseData> Blob_ObtenerArchivo([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            ILogger logger = executionContext.GetLogger("Blob_ObtenerArchivo");
            try
            {
                logger.LogInformation("Function obtener archivo iniciada");

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                InfoArchivo infoArchivo = JsonConvert.DeserializeObject<InfoArchivo>(requestBody);

                ProcesarFuncion procesarFuncion = new();
                ModeloRespuesta modeloRespuesta = await procesarFuncion.ProcesarDescarga(infoArchivo);
                string rpta = JsonConvert.SerializeObject(modeloRespuesta);

                logger.LogInformation("Function obtener archivo terminada");

                if (modeloRespuesta.EsExitoso)
                    return RespuestasHelper.Respuesta(HttpStatusCode.OK, req, rpta);
                else
                    return RespuestasHelper.Respuesta(HttpStatusCode.NoContent, req, rpta);
            }
            catch (Exception ex)
            {
                logger.LogInformation($"Error en la aplicación, detalle: {ex.Message}");
                return RespuestasHelper.Respuesta(HttpStatusCode.BadRequest, req, ex.Message);
            }
        }

        [Function("Blob_SubirArchivo")]
        public static async Task<HttpResponseData> Blob_SubirArchivo([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            ILogger logger = executionContext.GetLogger("Blob_SubirArchivo");
            try
            {
                logger.LogInformation("Function subir archivo iniciada");

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                InfoArchivo infoArchivo = JsonConvert.DeserializeObject<InfoArchivo>(requestBody);

                ProcesarFuncion procesarFuncion = new();
                ModeloRespuesta modeloRespuesta = await procesarFuncion.ProcesarSubida(infoArchivo);
                string rpta = JsonConvert.SerializeObject(modeloRespuesta);

                logger.LogInformation("Function obtener archivo terminada");

                if (modeloRespuesta.EsExitoso)
                    return RespuestasHelper.Respuesta(HttpStatusCode.OK, req, rpta);
                else
                    return RespuestasHelper.Respuesta(HttpStatusCode.NoContent, req, rpta);
            }
            catch (Exception ex)
            {
                logger.LogInformation($"Error en la aplicación, detalle: {ex.Message}");
                return RespuestasHelper.Respuesta(HttpStatusCode.BadRequest, req, ex.Message);
            }
        }
    }
}
