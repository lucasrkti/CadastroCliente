using CadastroClientes.Services;
using CadastroClientes.View;
using CadastroClientes.ViewModel;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Compatibility.Hosting;

namespace CadastroClientes
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<IClienteService, ClienteService>();
            builder.Services.AddSingleton<ClienteViewModel>();
            builder.Services.AddSingleton<AtualizarClienteViewModel>();

            builder.Services.AddSingleton<ClientesView>();
            builder.Services.AddSingleton<AtualizarClienteView>();

            return builder.Build();
        }
    }
}
