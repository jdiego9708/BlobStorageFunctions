namespace BlobFunctions.Entities.Helpers
{
    using Microsoft.Extensions.DependencyInjection;

    public class DIHelper
    {
        public static T GetService<T>() where T : class
        {
            MainController main = MainController.GetInstancia();
            using var serviceProvider = main.ServiceColletionMain.BuildServiceProvider();
            return (T)serviceProvider.GetService(typeof(T));
        }
    }
}
