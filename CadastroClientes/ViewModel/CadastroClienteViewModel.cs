using CadastroClientes.Model;
using CadastroClientes.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Text;

namespace CadastroClientes.ViewModel
{
    public partial class CadastroClienteViewModel : ObservableObject
    {
        Cliente csCliente = new Cliente();
        private readonly IClienteService _clienteService;

        public CadastroClienteViewModel(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
       
        #region Vinculações Entrys
        [ObservableProperty]
        string? txtNome;
        [ObservableProperty]
        string? txtSobreNome;
        [ObservableProperty]
        string txtIdade;
        [ObservableProperty]
        string? txtEndereco;
        #endregion

        #region Readonly Entrys
        [ObservableProperty]
        bool bloquearEntrys = false;
        [ObservableProperty]
        bool habilitarSemana = true;
        [ObservableProperty]
        bool habilitarBtnSalvar = true;
        #endregion

        #region Commands

        [RelayCommand]
        public void LimparEntrys() => TxtNome = TxtSobreNome = TxtIdade = TxtEndereco = string.Empty;

        [RelayCommand]
        public async Task SalvarCliente()
        {
            StringBuilder entrysVazias = new StringBuilder();

            if (string.IsNullOrEmpty(TxtNome)) entrysVazias.Append("Nome" + "\n\n");
            if (string.IsNullOrEmpty(TxtSobreNome)) entrysVazias.Append("SobreNome" + "\n\n");
            if (string.IsNullOrEmpty(Convert.ToString(TxtIdade))) entrysVazias.Append("Idade" + "\n\n");
            if (string.IsNullOrEmpty(TxtEndereco)) entrysVazias.Append("Endereço" + "\n\n");

            if (entrysVazias.ToString() != string.Empty) //  NAO ESQUECER - RETIRADO PARA RESTES  != 
            {
                await InformarEntryVazia(entrysVazias);
                return;
            }

            var strResult = await App.Current.MainPage.DisplayActionSheet("Deseja salvar o cliente?", "Confirmar", "Cancelar");

            if (strResult == "Confirmar")
            {
                csCliente.Name = string.IsNullOrEmpty(TxtNome) ? string.Empty : TxtNome.Trim();
                csCliente.Lastname = string.IsNullOrEmpty(TxtSobreNome) ? string.Empty : TxtSobreNome.Trim();
                csCliente.Age = string.IsNullOrEmpty(TxtIdade) ? string.Empty : TxtIdade.Trim();
                csCliente.Address = string.IsNullOrEmpty(TxtEndereco) ? string.Empty : TxtEndereco.Trim();

                await _clienteService.AdicionaCliente(csCliente);
                await _clienteService.AtualizaViewCliente(csCliente);
                await Shell.Current.Navigation.PopAsync();
                HabilitarBtnSalvar = false;
            }
        }
            #endregion

        #region  Métodos
        public async Task InformarEntryVazia(StringBuilder entrys) => await Shell.Current.DisplayAlert("Favor Preencher: \n", "\n" + entrys, "Ok");

        #endregion
    }
}
