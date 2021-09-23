using Microsoft.Extensions.DependencyInjection;

namespace BlobFunctions.Entities.Helpers
{
    public class MainController
    {
        public ServiceCollection ServiceColletionMain { get; set; }

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
