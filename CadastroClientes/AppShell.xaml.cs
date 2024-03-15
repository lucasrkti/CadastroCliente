using CadastroClientes.View;

namespace CadastroClientes
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ClientesView), typeof(ClientesView));
            Routing.RegisterRoute(nameof(CadastroClienteView), typeof(CadastroClienteView));
            Routing.RegisterRoute(nameof(AtualizarClienteView), typeof(AtualizarClienteView));
        }
    }
}
