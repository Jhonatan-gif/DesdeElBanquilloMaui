using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using DesdeElBanquilloMaui.Models;
using DesdeElBanquilloMaui.Services;
using Microsoft.Maui.Controls;

namespace DesdeElBanquilloMaui.ViewModels
{
    public class CompetitionsViewModel : BaseViewModel
    {
        private readonly CompetitionService _service = new();

        public ObservableCollection<Competition> Competitions { get; } = new();

        private string _searchText = "";
        public string SearchText
        {
            get => _searchText;
            set
            {
                if (SetProperty(ref _searchText, value))
                    FilterCompetitions();
            }
        }

        private List<Competition> _allCompetitions = new();

        public ICommand LoadCommand { get; }
        public ICommand DeleteCommand { get; }

        public CompetitionsViewModel()
        {
            LoadCommand = new Command(async () => await LoadCompetitions());
            DeleteCommand = new Command<Competition>(async (comp) => await DeleteCompetition(comp));
        }

        private async Task LoadCompetitions()
        {
            var comps = await _service.GetCompetitionsAsync();
            _allCompetitions = comps;
            Competitions.Clear();
            foreach (var c in comps)
                Competitions.Add(c);
        }

        private void FilterCompetitions()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                Competitions.Clear();
                foreach (var c in _allCompetitions)
                    Competitions.Add(c);
            }
            else
            {
                var filtered = _allCompetitions.Where(c =>
                    c.Name.Contains(SearchText, System.StringComparison.OrdinalIgnoreCase) ||
                    c.Season.Contains(SearchText, System.StringComparison.OrdinalIgnoreCase)).ToList();

                Competitions.Clear();
                foreach (var c in filtered)
                    Competitions.Add(c);
            }
        }

        private async Task DeleteCompetition(Competition competition)
        {
            if (competition == null) return;

            bool success = await _service.DeleteCompetitionAsync(competition.IdCompetition);
            if (success)
            {
                Competitions.Remove(competition);
                _allCompetitions.Remove(competition);
            }
            else
                await Application.Current.MainPage.DisplayAlert("Error", "No se pudo eliminar competencia", "OK");
        }
    }
}
