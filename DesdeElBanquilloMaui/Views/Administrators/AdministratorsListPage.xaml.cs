using DesdeElBanquilloMaui.Models;
using DesdeElBanquilloMaui.ViewModels;
using DesdeElBanquilloMaui.Views.Administrators;

namespace DesdeElBanquilloMaui.views.Administrators;

public partial class AdministratorsListPage : ContentPage
{
    private AdministratorsViewModel ViewModel => BindingContext as AdministratorsViewModel;

    public AdministratorsListPage()
    {
        InitializeComponent();
        Appearing += async (_, _) =>  ViewModel.LoadCommand.Execute(null);
    }

    private async void AddNew_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AdministratorCreatePage));
    }

    private async void EditSwipe_Invoked(object sender, EventArgs e)
    {
        var swipeItem = sender as SwipeItem;
        if (swipeItem?.BindingContext is Administrator admin)
        {
            await Shell.Current.GoToAsync($"{nameof(AdministratorDetailPage)}?IdAdministrator={admin.IdAdministrator}");
        }
    }

    private async void DeleteSwipe_Invoked(object sender, EventArgs e)
    {
        var swipeItem = sender as SwipeItem;
        if (swipeItem?.BindingContext is Administrator admin)
        {
            bool answer = await DisplayAlert("Confirmar", $"Eliminar administrador {admin.Name}?", "Sí", "No");
            if (answer)
            {
               ViewModel.DeleteCommand.Execute(admin);
            }
        }
    }
}
