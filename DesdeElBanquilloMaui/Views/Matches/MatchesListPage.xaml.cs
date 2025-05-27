using DesdeElBanquilloMaui.Models;
using DesdeElBanquilloMaui.ViewModels;

namespace DesdeElBanquilloMaui.Views.Matches;

public partial class MatchesListPage : ContentPage
{
    private MatchesViewModel ViewModel => BindingContext as MatchesViewModel;

    public MatchesListPage()
    {
        InitializeComponent();
        this.Appearing += async (_, _) => await ViewModel.LoadCommand.ExecuteAsync(null);
    }

    private async void AddNew_Clicked(object sender, EventArgs e)
    {
        // Navegar a creación partido (no implementado en este ejemplo)
    }

    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var match = e.CurrentSelection.FirstOrDefault() as Match;
        if (match != null)
        {
            // Navegar a detalle partido (no implementado en este ejemplo)
        }
    }
}
