using System.Collections.Generic;
using System.IO;
using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using BlobFunctions.Entities.Models;
using System.Text;
using HttpMultipartParser;
using Newtonsoft.Json.Linq;

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

                var bodyStr = await new StreamReader(req.Body).ReadToEndAsync();
                InfoArchivo infoArchivo = JsonConvert.DeserializeObject<InfoArchivo>(bodyStr);

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
