using DesdeElBanquilloMaui.Models;
using DesdeElBanquilloMaui.ViewModels;

namespace DesdeElBanquilloMaui.Views.Players;

public partial class PlayersListPage : ContentPage
{
    private PlayersViewModel ViewModel => BindingContext as PlayersViewModel;

    public PlayersListPage()
    {
        InitializeComponent();
        this.Appearing += async (_, _) => await ViewModel.LoadCommand.ExecuteAsync(null);
    }

    private async void AddNew_Clicked(object sender, EventArgs e)
    {
        // Navegar a creación jugador (no implementado en este ejemplo)
    }

    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var player = e.CurrentSelection.FirstOrDefault() as Player;
        if (player != null)
        {
            // Navegar a detalle jugador (no implementado en este ejemplo)
        }
    }
}
