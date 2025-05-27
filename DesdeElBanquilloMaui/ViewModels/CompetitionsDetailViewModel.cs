using System.Threading.Tasks;
using System.Windows.Input;
using DesdeElBanquilloMaui.Models;
using DesdeElBanquilloMaui.Services;
using Microsoft.Maui.Controls;

namespace DesdeElBanquilloMaui.ViewModels
{
    [QueryProperty(nameof(IdCompetition), "IdCompetition")]
    public class CompetitionDetailViewModel : BaseViewModel
    {
        private readonly CompetitionService _service = new();

        private int _idCompetition;
        public int IdCompetition
        {
            get => _idCompetition;
            set
            {
                SetProperty(ref _idCompetition, value);
                LoadCompetition(value);
            }
        }

        private Competition _competition = new Competition();
        public Competition Competition
        {
            get => _competition;
            set => SetProperty(ref _competition, value);
        }

        public ICommand SaveCommand { get; }
        public ICommand DeleteCommand { get; }

        public CompetitionDetailViewModel()
        {
            SaveCommand = new Command(async () => await SaveCompetition());
            DeleteCommand = new Command(async () => await DeleteCompetition());
        }

        private async void LoadCompetition(int id)
        {
            var comp = await _service.GetCompetitionByIdAsync(id);
            if (comp != null)
            {
                Competition = comp;
            }
        }

        private async Task SaveCompetition()
        {
            bool success = await _service.UpdateCompetitionAsync(Competition.IdCompetition, Competition);
            if (success)
                await Application.Current.MainPage.DisplayAlert("Éxito", "Competencia actualizada", "OK");
            else
                await Application.Current.MainPage.DisplayAlert("Error", "No se pudo actualizar competencia", "OK");
        }

        private async Task DeleteCompetition()
        {
            bool answer = await Application.Current.MainPage.DisplayAlert("Confirmar", "¿Eliminar competencia?", "Sí", "No");
            if (!answer) return;

            bool success = await _service.DeleteCompetitionAsync(Competition.IdCompetition);
            if (success)
            {
                await Application.Current.MainPage.DisplayAlert("Éxito", "Competencia eliminada", "OK");
                await Shell.Current.GoToAsync("..");
            }
            else
                await Application.Current.MainPage.DisplayAlert("Error", "No se pudo eliminar competencia", "OK");
        }
    }
}
