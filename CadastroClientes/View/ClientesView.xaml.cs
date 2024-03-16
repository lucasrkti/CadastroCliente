using CadastroClientes.Services;
using CadastroClientes.ViewModel;
using CommunityToolkit.Maui.Views;

namespace CadastroClientes.View;

public partial class ClientesView : ContentPage
{
    readonly ClienteViewModel ViewModel;
    public ClientesView(IClienteService clienteService, IPopupService popupService)
    {
        InitializeComponent();
        ViewModel = new ClienteViewModel(clienteService, popupService);
        BindingContext = ViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ViewModel.GetClientes();
    }
}