using BlobFunctions.Entities.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace BlobFunctions.Entities.Helpers
{
    public class MainController
    {
        public ServiceCollection ServiceColletionMain { get; set; }
        public List<ModeloError> Errores {  get; set; }

        #region PATRON SINGLETON
        private static MainController _Instancia;
        public static MainController GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new MainController();
            }
            return _Instancia;
        }
        #endregion
    }
}
