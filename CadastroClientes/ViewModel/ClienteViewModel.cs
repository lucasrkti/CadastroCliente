using CadastroClientes.Model;
using CadastroClientes.Services;
using CadastroClientes.View;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Text;

namespace CadastroClientes.ViewModel
{
    public partial class ClienteViewModel : ObservableObject
    {
        private readonly IClienteService _clienteService;

        public ObservableCollection<Cliente> listaClientes { get; set; } = new();
        public List<string> listEntrysPreenchidas = new List<string>();
        Cliente csCliente = new Cliente();

        public ClienteViewModel(IClienteService clienteService) // MANTER PARA CARREGAR OS CLIENTES DO BANCO AO INICIAR O APP?
        {
            _clienteService = clienteService;
            
        }

        #region Vinculações Entrys
        [ObservableProperty]
        private List<Cliente> _clientes;

        [ObservableProperty]
        private Cliente clienteAtual;
        #endregion


        #region Commands

        [RelayCommand]
        public async Task GetClientes()
        {
            listaClientes.Clear();

            try
            {
                await _clienteService.InitializeAsync();
                var clientes = await _clienteService.GetClientes();

                if (clientes.Count > 0)
                    foreach (var cliente in clientes)
                    {
                        listaClientes.Add(cliente);
                    }

                clienteAtual = null;
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", "" + ex.Message, "Ok");
            }
        }

        [RelayCommand]
        public async Task AdicionarCliente()
        {
            await Shell.Current.Navigation.PushAsync(new CadastroClienteView(_clienteService));
        }

        [RelayCommand]
        public async Task AtualizarCliente()
        {
            if (ClienteAtual != null)
            {
                await Shell.Current.Navigation.PushAsync(new AtualizarClienteView(clienteAtual, _clienteService));
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Selecione um cliente para atualizar!", "", "Ok");
            }
        }

        [RelayCommand]
        public async Task RemoverCliente()
        {
            int excluido = 0;

            if (clienteAtual != null)
            {
                excluido = await _clienteService.DeletaCliente(clienteAtual);
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Selecione um cliente para excluir!", "", "Ok");
            }

            if (excluido == 1)
            {
                await App.Current.MainPage.DisplayAlert("Cliente excluido com sucesso!", "", "Ok");
                listaClientes.Remove(clienteAtual);
                clienteAtual = null;
            }

        }

        #endregion

        #region  Métodos

        public async Task InformarEntryVazia(StringBuilder entrys) =>  await App.Current.MainPage.DisplayAlert("Favor Preencher: ", "" + entrys, "Ok");
 
        #endregion
    }
}
