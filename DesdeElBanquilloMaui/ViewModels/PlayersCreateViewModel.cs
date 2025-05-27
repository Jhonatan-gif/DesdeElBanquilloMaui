using System.Threading.Tasks;
using System.Windows.Input;
using DesdeElBanquilloMaui.Models;
using DesdeElBanquilloMaui.Services;
using Microsoft.Maui.Controls;

namespace DesdeElBanquilloMaui.ViewModels
{
    public class PlayerCreateViewModel : BaseViewModel
    {
        private readonly PlayerService _service = new();

        public Player NewPlayer { get; set; } = new Player();

        public ICommand CreateCommand { get; }

        public PlayerCreateViewModel()
        {
            CreateCommand = new Command(async () => await CreatePlayer());
        }

        private async Task CreatePlayer()
        {
            if (string.IsNullOrWhiteSpace(NewPlayer.Name))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "El nombre es requerido", "OK");
                return;
            }

            bool success = await _service.CreatePlayerAsync(NewPlayer);
            if (success)
            {
                await Application.Current.MainPage.DisplayAlert("Éxito", "Jugador creado", "OK");
                await Shell.Current.GoToAsync("..");
            }
            else
                await Application.Current.MainPage.DisplayAlert("Error", "No se pudo crear jugador", "OK");
        }
    }
}
