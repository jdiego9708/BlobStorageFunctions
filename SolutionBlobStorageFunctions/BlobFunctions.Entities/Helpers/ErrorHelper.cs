namespace BlobFunctions.Entities.Helpers
{
    using BlobFunctions.Entities.Models;
    using System.Collections.Generic;

    public class ErrorHelper
    {
        public static void ObtenerError(ModeloError modeloError)
        {
            MainController main = MainController.GetInstancia();
            if (main.Errores == null)
                main.Errores = new List<ModeloError>();

            main.Errores.Add(modeloError);
        }
    }
}
