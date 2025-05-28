using DesdeElBanquilloMaui.Models;
using DesdeElBanquilloMaui.ViewModels;

namespace DesdeElBanquilloMaui.Views.Players;

public partial class PlayersListPage : ContentPage
{
    private PlayersViewModel ViewModel => BindingContext as PlayersViewModel;

    public PlayersListPage()
    {
        InitializeComponent();
        this.Appearing += async (_, _) =>  ViewModel.LoadCommand.Execute(null);
    }

    private async void AddNew_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(PlayerDetailPage) + "?isNew=true");
    }

    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var player = e.CurrentSelection.FirstOrDefault() as Player;
        if (player != null)
        {
            await Shell.Current.GoToAsync($"{nameof(PlayerDetailPage)}?IdPlayer={player.IdPlayer}");

            ((CollectionView)sender).SelectedItem = null;
        }
    }
}
