using MatchModel = DesdeElBanquilloMaui.Models.Match;
using System.Threading.Tasks;
using System.Windows.Input;
using DesdeElBanquilloMaui.Services;
using Microsoft.Maui.Controls;

namespace DesdeElBanquilloMaui.ViewModels
{
    [QueryProperty(nameof(IdMatch), "IdMatch")]
    public class MatchDetailViewModel : BaseViewModel
    {
        private readonly MatchService _service = new();

        private int _idMatch;
        public int IdMatch
        {
            get => _idMatch;
            set
            {
                SetProperty(ref _idMatch, value);
                LoadMatch(value);
            }
        }

        private MatchModel _match = new MatchModel();
        public MatchModel Match
        {
            get => _match;
            set => SetProperty(ref _match, value);
        }

        public ICommand SaveCommand { get; }
        public ICommand DeleteCommand { get; }

        public MatchDetailViewModel()
        {
            SaveCommand = new Command(async () => await SaveMatch());
            DeleteCommand = new Command(async () => await DeleteMatch());
        }

        private async void LoadMatch(int id)
        {
            var match = await _service.GetMatchByIdAsync(id);
            if (match != null)
            {
                Match = match;
            }
        }

        private async Task SaveMatch()
        {
            bool success = await _service.UpdateMatchAsync(Match.IdMatch, Match);
            if (success)
                await Application.Current.MainPage.DisplayAlert("Éxito", "Partido actualizado", "OK");
            else
                await Application.Current.MainPage.DisplayAlert("Error", "No se pudo actualizar partido", "OK");
        }

        private async Task DeleteMatch()
        {
            bool answer = await Application.Current.MainPage.DisplayAlert("Confirmar", "¿Eliminar partido?", "Sí", "No");
            if (!answer) return;

            bool success = await _service.DeleteMatchAsync(Match.IdMatch);
            if (success)
            {
                await Application.Current.MainPage.DisplayAlert("Éxito", "Partido eliminado", "OK");
                await Shell.Current.GoToAsync("..");
            }
            else
                await Application.Current.MainPage.DisplayAlert("Error", "No se pudo eliminar partido", "OK");
        }
    }
}
