using DesdeElBanquilloMaui.Models;
using DesdeElBanquilloMaui.ViewModels;

namespace DesdeElBanquilloMaui.Views.Matches;

public partial class MatchesListPage : ContentPage
{
    private MatchesViewModel ViewModel => BindingContext as MatchesViewModel;

    public MatchesListPage()
    {
        InitializeComponent();
        this.Appearing += async (_, _) =>  ViewModel.LoadCommand.Execute(null);
    }

    private async void AddNew_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(MatchDetailPage) + "?isNew=true");
    }

    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var match = e.CurrentSelection.FirstOrDefault() as Match;
        if (match != null)
        {
            await Shell.Current.GoToAsync($"{nameof(MatchDetailPage)}?IdMatch={match.IdMatch}");

            ((CollectionView)sender).SelectedItem = null;
        }
    }
}
