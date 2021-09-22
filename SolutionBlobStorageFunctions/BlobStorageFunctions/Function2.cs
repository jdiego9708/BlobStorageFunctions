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
                var bodyStr = "";
                using (StreamReader reader
                   = new StreamReader(req.Body, Encoding.UTF8, true, 1024, true))
                {
                    bodyStr = reader.ReadToEnd();
                }
                //InfoArchivo info = await JsonSerializer.DeserializeAsync<InfoArchivo>(await req.Body.ReadAsync());

                //InfoArchivo info = await System.Text.Json.JsonSerializer.DeserializeAsync<InfoArchivo>(req.Body, SerializerOptions);
                //var myclass = await System.Text.Json.JsonSerializer.DeserializeAsync<InfoArchivo>(req.Body);

                //string requestBody = await new StreamReader(req.ReadFromJsonAsync()).ReadToEndAsync();
                //dynamic infoArchivo = JsonConvert.DeserializeObject(requestBody);
                //InfoArchivo infoArchivo = JsonConvert.DeserializeObject<InfoArchivo>(value.ToString());
                HttpResponseData response = req.CreateResponse(HttpStatusCode.OK);
                response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

                //response.WriteString(info.Archivo);
                return response;
            }
            catch (Exception ex)
            {

            }       

            return null;
        }
    }
}
