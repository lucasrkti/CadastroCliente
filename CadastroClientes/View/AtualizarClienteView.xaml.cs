using CadastroClientes.Model;
using CadastroClientes.Services;
using CadastroClientes.ViewModel;
using CommunityToolkit.Maui.Views;

namespace CadastroClientes.View;

public partial class AtualizarClienteView : Popup
{
    readonly AtualizarClienteViewModel ViewModel;

    public AtualizarClienteView(Cliente cliente, IClienteService clienteService)
    {
        InitializeComponent();
        ViewModel = new AtualizarClienteViewModel(cliente, clienteService);
        BindingContext = ViewModel;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Close();
    }
}