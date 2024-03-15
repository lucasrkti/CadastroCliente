using CadastroClientes.Model;
using CadastroClientes.Services;
using CadastroClientes.ViewModel;

namespace CadastroClientes.View;

public partial class AtualizarClienteView : ContentPage
{
    readonly AtualizarClienteViewModel ViewModel;

    public AtualizarClienteView(Cliente cliente, IClienteService clienteService)
    {
        InitializeComponent();
        ViewModel = new AtualizarClienteViewModel(cliente, clienteService);
        BindingContext = ViewModel;
    }
}