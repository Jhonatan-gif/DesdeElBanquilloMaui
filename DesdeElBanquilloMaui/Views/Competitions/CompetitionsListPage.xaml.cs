using DesdeElBanquilloMaui.Models;
using DesdeElBanquilloMaui.ViewModels;

namespace DesdeElBanquilloMaui.Views.Competitions;

public partial class CompetitionsListPage : ContentPage
{
    private CompetitionsViewModel ViewModel => BindingContext as CompetitionsViewModel;

    public CompetitionsListPage()
    {
        InitializeComponent();
        this.Appearing += async (_, _) => await ViewModel.LoadCommand.ExecuteAsync(null);
    }

    private async void AddNew_Clicked(object sender, EventArgs e)
    {
        // Aquí navega a página crear competencia (por implementar)
        await Shell.Current.GoToAsync(nameof(CompetitionDetailPage));
    }

    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var competition = e.CurrentSelection.FirstOrDefault() as Competition;
        if (competition != null)
        {
            await Shell.Current.GoToAsync($"{nameof(CompetitionDetailPage)}?IdCompetition={competition.IdCompetition}");
        }
    }
}
