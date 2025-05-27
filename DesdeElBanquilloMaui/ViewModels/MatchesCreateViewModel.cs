using MatchModel = DesdeElBanquilloMaui.Models.Match;
using System.Threading.Tasks;
using System.Windows.Input;
using DesdeElBanquilloMaui.Services;
using Microsoft.Maui.Controls;

namespace DesdeElBanquilloMaui.ViewModels
{
    public class MatchCreateViewModel : BaseViewModel
    {
        private readonly MatchService _service = new();

        public MatchModel NewMatch { get; set; } = new MatchModel();

        public ICommand CreateCommand { get; }

        public MatchCreateViewModel()
        {
            CreateCommand = new Command(async () => await CreateMatch());
        }

        private async Task CreateMatch()
        {
            if (NewMatch.MatchDate == default)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Fecha del partido es requerida", "OK");
                return;
            }

            bool success = await _service.CreateMatchAsync(NewMatch);
            if (success)
            {
                await Application.Current.MainPage.DisplayAlert("Éxito", "Partido creado", "OK");
                await Shell.Current.GoToAsync("..");
            }
            else
                await Application.Current.MainPage.DisplayAlert("Error", "No se pudo crear partido", "OK");
        }
    }
}
