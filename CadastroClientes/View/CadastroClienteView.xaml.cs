using CadastroClientes.Services;
using CadastroClientes.ViewModel;
using CommunityToolkit.Maui.Views;

namespace CadastroClientes.View;

public partial class CadastroClienteView : Popup
{
    readonly CadastroClienteViewModel ViewModel;
    public CadastroClienteView(IClienteService clienteService)
    {
        InitializeComponent();
        ViewModel = new CadastroClienteViewModel(clienteService);
        BindingContext = ViewModel;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Close();
    }
}