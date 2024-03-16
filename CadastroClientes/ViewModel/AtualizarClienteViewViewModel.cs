using CadastroClientes.Model;
using CadastroClientes.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Text;

namespace CadastroClientes.ViewModel
{
    public partial class AtualizarClienteViewModel : ObservableObject
    {
        Cliente csCliente = new Cliente();
        private readonly IClienteService _clienteService;

        public AtualizarClienteViewModel(Cliente cliente, IClienteService clienteService)
        {
            _clienteService = clienteService;

            csCliente = cliente;
            TxtId = Convert.ToString(csCliente.Id);
            TxtNome = csCliente.Name;
            TxtSobreNome = csCliente.Lastname;
            TxtIdade = csCliente.Age;
            txtEndereco = csCliente.Address;
        }

        #region Vinculações Entrys
        [ObservableProperty]
        string? txtId;
        [ObservableProperty]
        string? txtNome;
        [ObservableProperty]
        string? txtSobreNome;
        [ObservableProperty]
        string? txtIdade;
        [ObservableProperty]
        string? txtEndereco;
        [ObservableProperty]
        bool habilitarBtnAtualizar = true;
        #endregion

        #region Commands

        [RelayCommand]
        public async Task AtualizarCliente()
        {
            StringBuilder entrysVazias = new StringBuilder();

            if (string.IsNullOrEmpty(TxtNome)) entrysVazias.Append("Nome" + "\n\n");
            if (string.IsNullOrEmpty(TxtSobreNome)) entrysVazias.Append("SobreNome" + "\n\n");
            if (string.IsNullOrEmpty(Convert.ToString(TxtIdade))) entrysVazias.Append("Idade" + "\n\n");
            if (string.IsNullOrEmpty(TxtEndereco)) entrysVazias.Append("Endereço" + "\n\n");

            if (entrysVazias.ToString() != string.Empty)
            {
                await InformarEntryVazia(entrysVazias);
                return;
            }

            var strResult = await App.Current.MainPage.DisplayActionSheet("Confirma a atualização do cliente?", "Confirmar", "Cancelar");

            if (strResult == "Confirmar")
            {
                csCliente.Name = string.IsNullOrEmpty(TxtNome) ? string.Empty : TxtNome.Trim();
                csCliente.Lastname = string.IsNullOrEmpty(TxtSobreNome) ? string.Empty : TxtSobreNome.Trim();
                csCliente.Age = string.IsNullOrEmpty(TxtIdade) ? string.Empty : TxtIdade.Trim();
                csCliente.Address = string.IsNullOrEmpty(TxtEndereco) ? string.Empty : TxtEndereco.Trim();

                await _clienteService.AtualizaCliente(csCliente);
                await _clienteService.AtualizaViewCliente(csCliente);
                await Shell.Current.Navigation.PopAsync();
                HabilitarBtnAtualizar = false;
            }
            #endregion
        }

        #region  Métodos
        public async Task InformarEntryVazia(StringBuilder entrys) => await App.Current.MainPage.DisplayAlert("Favor Preencher: \n", "\n" + entrys, "Ok");

        #endregion
    }
}
