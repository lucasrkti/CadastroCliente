using CadastroClientes.View;
using CadastroClientes.ViewModel;

namespace CadastroClientes
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
