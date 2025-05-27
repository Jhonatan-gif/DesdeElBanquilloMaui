using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using DesdeElBanquilloMaui.Models;
using DesdeElBanquilloMaui.Services;
using Microsoft.Maui.Controls;

namespace DesdeElBanquilloMaui.ViewModels
{
    public class TeamsViewModel : BaseViewModel
    {
        private readonly TeamService _service = new();

        public ObservableCollection<Team> Teams { get; } = new();

        private string _searchText = "";
        public string SearchText
        {
            get => _searchText;
            set
            {
                if (SetProperty(ref _searchText, value))
                    FilterTeams();
            }
        }

        private List<Team> _allTeams = new();

        public ICommand LoadCommand { get; }
        public ICommand DeleteCommand { get; }

        public TeamsViewModel()
        {
            LoadCommand = new Command(async () => await LoadTeams());
            DeleteCommand = new Command<Team>(async (team) => await DeleteTeam(team));
        }

        private async Task LoadTeams()
        {
            var teams = await _service.GetTeamsAsync();
            _allTeams = teams;
            Teams.Clear();
            foreach (var t in teams)
                Teams.Add(t);
        }

        private void FilterTeams()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                Teams.Clear();
                foreach (var t in _allTeams)
                    Teams.Add(t);
            }
            else
            {
                var filtered = _allTeams.Where(t =>
                    t.Name.Contains(SearchText, System.StringComparison.OrdinalIgnoreCase) ||
                    t.City.Contains(SearchText, System.StringComparison.OrdinalIgnoreCase)).ToList();

                Teams.Clear();
                foreach (var t in filtered)
                    Teams.Add(t);
            }
        }

        private async Task DeleteTeam(Team team)
        {
            if (team == null) return;

            bool success = await _service.DeleteTeamAsync(team.IdTeam);
            if (success)
            {
                Teams.Remove(team);
                _allTeams.Remove(team);
            }
            else
                await Application.Current.MainPage.DisplayAlert("Error", "No se pudo eliminar equipo", "OK");
        }
    }
}
