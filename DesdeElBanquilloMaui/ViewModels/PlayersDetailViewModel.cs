using System.Threading.Tasks;
using System.Windows.Input;
using DesdeElBanquilloMaui.Models;
using DesdeElBanquilloMaui.Services;
using Microsoft.Maui.Controls;

namespace DesdeElBanquilloMaui.ViewModels
{
    [QueryProperty(nameof(IdPlayer), "IdPlayer")]
    public class PlayerDetailViewModel : BaseViewModel
    {
        private readonly PlayerService _service = new();

        private int _idPlayer;
        public int IdPlayer
        {
            get => _idPlayer;
            set
            {
                SetProperty(ref _idPlayer, value);
                LoadPlayer(value);
            }
        }

        private Player _player = new Player();
        public Player Player
        {
            get => _player;
            set => SetProperty(ref _player, value);
        }

        public ICommand SaveCommand { get; }
        public ICommand DeleteCommand { get; }

        public PlayerDetailViewModel()
        {
            SaveCommand = new Command(async () => await SavePlayer());
            DeleteCommand = new Command(async () => await DeletePlayer());
        }

        private async void LoadPlayer(int id)
        {
            var player = await _service.GetPlayerByIdAsync(id);
            if (player != null)
            {
                Player = player;
            }
        }

        private async Task SavePlayer()
        {
            bool success = await _service.UpdatePlayerAsync(Player.IdPlayer, Player);
            if (success)
                await Application.Current.MainPage.DisplayAlert("Éxito", "Jugador actualizado", "OK");
            else
                await Application.Current.MainPage.DisplayAlert("Error", "No se pudo actualizar jugador", "OK");
        }

        private async Task DeletePlayer()
        {
            bool answer = await Application.Current.MainPage.DisplayAlert("Confirmar", "¿Eliminar jugador?", "Sí", "No");
            if (!answer) return;

            bool success = await _service.DeletePlayerAsync(Player.IdPlayer);
            if (success)
            {
                await Application.Current.MainPage.DisplayAlert("Éxito", "Jugador eliminado", "OK");
                await Shell.Current.GoToAsync("..");
            }
            else
                await Application.Current.MainPage.DisplayAlert("Error", "No se pudo eliminar jugador", "OK");
        }
    }
}
