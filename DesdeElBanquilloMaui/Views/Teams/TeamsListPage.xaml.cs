using DesdeElBanquilloMaui.Models;
using DesdeElBanquilloMaui.ViewModels;

namespace DesdeElBanquilloMaui.Views.Teams;

public partial class TeamsListPage : ContentPage
{
    private TeamsViewModel ViewModel => BindingContext as TeamsViewModel;

    public TeamsListPage()
    {
        InitializeComponent();
        this.Appearing += async (_, _) =>  ViewModel.LoadCommand.Execute(null);
    }

    private async void AddNew_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(TeamDetailPage) + "?isNew=true");
    }

    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var team = e.CurrentSelection.FirstOrDefault() as Team;
        if (team != null)
        {
            await Shell.Current.GoToAsync($"{nameof(TeamDetailPage)}?IdTeam={team.IdTeam}");

            ((CollectionView)sender).SelectedItem = null;
        }
    }
}
