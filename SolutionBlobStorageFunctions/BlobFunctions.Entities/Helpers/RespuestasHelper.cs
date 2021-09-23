namespace BlobFunctions.Entities.Helpers
{
    using System.Net;
    using Microsoft.Azure.Functions.Worker.Http;

    public class RespuestasHelper
    {
        public static HttpResponseData Respuesta(HttpStatusCode code, HttpRequestData req, string rpta)
        {
            HttpResponseData response = req.CreateResponse(code);
            response.Headers.Add("Content-Type", "application/json; charset=utf-8");
            response.WriteString(rpta);
            return response;
        }
    }
}
