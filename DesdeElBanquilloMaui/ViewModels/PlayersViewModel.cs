using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using DesdeElBanquilloMaui.Models;
using DesdeElBanquilloMaui.Services;
using Microsoft.Maui.Controls;

namespace DesdeElBanquilloMaui.ViewModels
{
    public class PlayersViewModel : BaseViewModel
    {
        private readonly PlayerService _service = new();

        public ObservableCollection<Player> Players { get; } = new();

        private string _searchText = "";
        public string SearchText
        {
            get => _searchText;
            set
            {
                if (SetProperty(ref _searchText, value))
                    FilterPlayers();
            }
        }

        private List<Player> _allPlayers = new();

        public ICommand LoadCommand { get; }
        public ICommand DeleteCommand { get; }

        public PlayersViewModel()
        {
            LoadCommand = new Command(async () => await LoadPlayers());
            DeleteCommand = new Command<Player>(async (player) => await DeletePlayer(player));
        }

        private async Task LoadPlayers()
        {
            var players = await _service.GetPlayersAsync();
            _allPlayers = players;
            Players.Clear();
            foreach (var p in players)
                Players.Add(p);
        }

        private void FilterPlayers()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                Players.Clear();
                foreach (var p in _allPlayers)
                    Players.Add(p);
            }
            else
            {
                var filtered = _allPlayers.Where(p =>
                    p.Name.Contains(SearchText, System.StringComparison.OrdinalIgnoreCase)).ToList();

                Players.Clear();
                foreach (var p in filtered)
                    Players.Add(p);
            }
        }

        private async Task DeletePlayer(Player player)
        {
            if (player == null) return;

            bool success = await _service.DeletePlayerAsync(player.IdPlayer);
            if (success)
            {
                Players.Remove(player);
                _allPlayers.Remove(player);
            }
            else
                await Application.Current.MainPage.DisplayAlert("Error", "No se pudo eliminar jugador", "OK");
        }
    }
}
