using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using DesdeElBanquilloMaui.Services;
using Microsoft.Maui.Controls;

// Alias para evitar confusión con System.Text.RegularExpressions.Match
using MatchModel = DesdeElBanquilloMaui.Models.Match;

namespace DesdeElBanquilloMaui.ViewModels
{
    public class MatchesViewModel : BaseViewModel
    {
        private readonly MatchService _service = new();

        // Usa el alias MatchModel aquí
        public ObservableCollection<MatchModel> Matches { get; } = new();

        private string _searchText = "";
        public string SearchText
        {
            get => _searchText;
            set
            {
                if (SetProperty(ref _searchText, value))
                    FilterMatches();
            }
        }

        // También lista de MatchModel
        private List<MatchModel> _allMatches = new();

        public ICommand LoadCommand { get; }
        public ICommand DeleteCommand { get; }

        public MatchesViewModel()
        {
            LoadCommand = new Command(async () => await LoadMatches());
            DeleteCommand = new Command<MatchModel>(async (match) => await DeleteMatch(match));
        }

        private async Task LoadMatches()
        {
            var matches = await _service.GetMatchesAsync();

            // Corregido: asignar a _allMatches, no a "match"
            _allMatches = matches;

            Matches.Clear();
            foreach (var m in matches)
                Matches.Add(m);
        }

        private void FilterMatches()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                Matches.Clear();
                foreach (var m in _allMatches)
                    Matches.Add(m);
            }
            else
            {
                var filtered = _allMatches.Where(m =>
                    m.Referee.Contains(SearchText, System.StringComparison.OrdinalIgnoreCase)).ToList();

                Matches.Clear();
                foreach (var m in filtered)
                    Matches.Add(m);
            }
        }

        private async Task DeleteMatch(MatchModel match)
        {
            if (match == null) return;

            bool success = await _service.DeleteMatchAsync(match.IdMatch);
            if (success)
            {
                Matches.Remove(match);
                _allMatches.Remove(match);
            }
            else
                await Application.Current.MainPage.DisplayAlert("Error", "No se pudo eliminar partido", "OK");
        }
    }
}
