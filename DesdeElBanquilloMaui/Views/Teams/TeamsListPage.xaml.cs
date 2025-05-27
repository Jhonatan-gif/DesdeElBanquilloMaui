using DesdeElBanquilloMaui.Models;
using DesdeElBanquilloMaui.ViewModels;

namespace DesdeElBanquilloMaui.Views.Teams;

public partial class TeamsListPage : ContentPage
{
    private TeamsViewModel ViewModel => BindingContext as TeamsViewModel;

    public TeamsListPage()
    {
        InitializeComponent();
        this.Appearing += async (_, _) => await ViewModel.LoadCommand.ExecuteAsync(null);
    }

    private async void AddNew_Clicked(object sender, EventArgs e)
    {
        // Navegar a creación detalle equipo (no implementado en este ejemplo)
    }

    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var team = e.CurrentSelection.FirstOrDefault() as Team;
        if (team != null)
        {
            // Navegar a detalle equipo (no implementado en este ejemplo)
        }
    }
}
