using System.IO;
using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using BlobFunctions.Entities.Models;

namespace BlobStorageFunctions
{
    public static class Function2
    {
        [Function("BlobFunction_GetFile")]
        public static async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            try
            {
                ILogger logger = executionContext.GetLogger("BlobFunction_GetFile");
                logger.LogInformation("Function obtener archivo iniciada");

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                InfoArchivo infoArchivo = JsonConvert.DeserializeObject<InfoArchivo>(requestBody);




                HttpResponseData response = req.CreateResponse(HttpStatusCode.OK);
                response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

                response.WriteString(infoArchivo.Archivo);
                return response;
            }
            catch (Exception ex)
            {

            }       

            return null;
        }
    }
}
