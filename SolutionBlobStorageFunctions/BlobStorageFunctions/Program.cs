namespace BlobStorageFunctions
{
    using BlobFunctions.Core.Interface;
    using BlobFunctions.Core.Servicio;
    using BlobFunctions.Entities.Helpers;
    using BlobFunctions.Servicio.Interface;
    using BlobFunctions.Servicio.Servicio;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Program
    {
        public static void Main()
        {
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .Build();

            MainController main = MainController.GetInstancia();
            LoadDependencyInjection(main);
            using var serviceProvider = main.ServiceColletionMain.BuildServiceProvider();

            host.Run();
        }

        public static void LoadDependencyInjection(MainController main)
        {
            main.ServiceColletionMain = new ServiceCollection();
            ConfigureServices(main.ServiceColletionMain);
        }
        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped<IBlobStorageService, BlobStorageService>()
                .AddScoped<IHelperBlobStorage, HelperBlobStorage>();
        }
    }
}