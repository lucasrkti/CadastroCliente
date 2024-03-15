using CadastroClientes.Services;
using CadastroClientes.ViewModel;

namespace CadastroClientes.View;

public partial class CadastroClienteView : ContentPage
{
    readonly CadastroClienteViewModel ViewModel;
    public CadastroClienteView(IClienteService clienteService)
    {
        InitializeComponent();
        ViewModel = new CadastroClienteViewModel(clienteService);
        BindingContext = ViewModel;
    }
}