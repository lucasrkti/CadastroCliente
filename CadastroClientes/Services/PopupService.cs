using CommunityToolkit.Maui.Views;

namespace CadastroClientes.Services
{
    public class PopupService : IPopupService
    {
        public void ShowPopup(Popup popup)
        {
            Page page = Application.Current?.MainPage ?? throw new NullReferenceException();
            page.ShowPopup(popup);
        }
    }
}
