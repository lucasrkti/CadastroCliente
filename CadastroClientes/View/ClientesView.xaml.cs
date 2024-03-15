using CadastroClientes.Services;
using CadastroClientes.ViewModel;

namespace CadastroClientes.View;

public partial class ClientesView : ContentPage
{
    readonly ClienteViewModel ViewModel;
    public ClientesView(IClienteService clienteService)
    {
        InitializeComponent();
        ViewModel = new ClienteViewModel(clienteService);
        BindingContext = ViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ViewModel.GetClientes();
    }
}