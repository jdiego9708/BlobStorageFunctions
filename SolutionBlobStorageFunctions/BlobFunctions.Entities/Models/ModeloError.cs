namespace BlobFunctions.Entities.Models
{
    using System;

    public class ModeloError
    {
        public ModeloError()
        {

        }
        public ModeloError(Exception ex)
        {
            this.CodigoError = ex.HResult;
            this.MensajeError = ex.Message;
            this.MensajeErrorDetallado = $"{ex.InnerException.Message},{ex.InnerException.StackTrace}";
        }

        public int CodigoError { get; set; }
        public string MensajeError { get; set; }
        public string MensajeErrorDetallado { get; set; }
        public object ErrorPersonalizado { get; set; }
    }
}
