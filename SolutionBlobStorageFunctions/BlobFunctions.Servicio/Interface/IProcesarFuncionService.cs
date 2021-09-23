namespace BlobFunctions.Servicio.Interface
{
    using BlobFunctions.Entities.Models;
    using System.Threading.Tasks;

    public interface IProcesarFuncionService
    {
        Task<ModeloRespuesta> ProcesarDescarga(InfoArchivo infoArchivo);
        Task<ModeloRespuesta> ProcesarSubida(InfoArchivo infoArchivo);
    }
}
