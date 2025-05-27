using System.Threading.Tasks;
using System.Windows.Input;
using DesdeElBanquilloMaui.Models;
using DesdeElBanquilloMaui.Services;
using Microsoft.Maui.Controls;

namespace DesdeElBanquilloMaui.ViewModels
{
    public class TeamCreateViewModel : BaseViewModel
    {
        private readonly TeamService _service = new();

        public Team NewTeam { get; set; } = new Team();

        public ICommand CreateCommand { get; }

        public TeamCreateViewModel()
        {
            CreateCommand = new Command(async () => await CreateTeam());
        }

        private async Task CreateTeam()
        {
            if (string.IsNullOrWhiteSpace(NewTeam.Name))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "El nombre es requerido", "OK");
                return;
            }

            bool success = await _service.CreateTeamAsync(NewTeam);
            if (success)
            {
                await Application.Current.MainPage.DisplayAlert("Éxito", "Equipo creado", "OK");
                await Shell.Current.GoToAsync("..");
            }
            else
                await Application.Current.MainPage.DisplayAlert("Error", "No se pudo crear equipo", "OK");
        }
    }
}
