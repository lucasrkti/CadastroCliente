using CadastroClientes.Services;
using CadastroClientes.View;
using CadastroClientes.ViewModel;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using PopupService = CadastroClientes.Services.PopupService;

namespace CadastroClientes
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddTransient<IPopupService, PopupService>();
            builder.Services.AddTransientPopup<CadastroClienteView, CadastroClienteViewModel>();
            builder.Services.AddTransientPopup<AtualizarClienteView, AtualizarClienteViewModel>();
            builder.Services.AddSingleton<IClienteService, ClienteService>();
            builder.Services.AddTransient<ClienteViewModel>();
            builder.Services.AddTransient<ClientesView>();

            return builder.Build();
        }
    }
}
