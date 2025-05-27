using System.Threading.Tasks;
using System.Windows.Input;
using DesdeElBanquilloMaui.Models;
using DesdeElBanquilloMaui.Services;
using Microsoft.Maui.Controls;

namespace DesdeElBanquilloMaui.ViewModels
{
    [QueryProperty(nameof(IdTeam), "IdTeam")]
    public class TeamDetailViewModel : BaseViewModel
    {
        private readonly TeamService _service = new();

        private int _idTeam;
        public int IdTeam
        {
            get => _idTeam;
            set
            {
                SetProperty(ref _idTeam, value);
                LoadTeam(value);
            }
        }

        private Team _team = new Team();
        public Team Team
        {
            get => _team;
            set => SetProperty(ref _team, value);
        }

        public ICommand SaveCommand { get; }
        public ICommand DeleteCommand { get; }

        public TeamDetailViewModel()
        {
            SaveCommand = new Command(async () => await SaveTeam());
            DeleteCommand = new Command(async () => await DeleteTeam());
        }

        private async void LoadTeam(int id)
        {
            var team = await _service.GetTeamByIdAsync(id);
            if (team != null)
            {
                Team = team;
            }
        }

        private async Task SaveTeam()
        {
            bool success = await _service.UpdateTeamAsync(Team.IdTeam, Team);
            if (success)
                await Application.Current.MainPage.DisplayAlert("Éxito", "Equipo actualizado", "OK");
            else
                await Application.Current.MainPage.DisplayAlert("Error", "No se pudo actualizar equipo", "OK");
        }

        private async Task DeleteTeam()
        {
            bool answer = await Application.Current.MainPage.DisplayAlert("Confirmar", "¿Eliminar equipo?", "Sí", "No");
            if (!answer) return;

            bool success = await _service.DeleteTeamAsync(Team.IdTeam);
            if (success)
            {
                await Application.Current.MainPage.DisplayAlert("Éxito", "Equipo eliminado", "OK");
                await Shell.Current.GoToAsync("..");
            }
            else
                await Application.Current.MainPage.DisplayAlert("Error", "No se pudo eliminar equipo", "OK");
        }
    }
}
