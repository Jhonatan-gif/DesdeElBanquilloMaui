using System.Threading.Tasks;
using System.Windows.Input;
using DesdeElBanquilloMaui.Models;
using DesdeElBanquilloMaui.Services;
using Microsoft.Maui.Controls;

namespace DesdeElBanquilloMaui.ViewModels
{
    public class CompetitionCreateViewModel : BaseViewModel
    {
        private readonly CompetitionService _service = new();

        public Competition NewCompetition { get; set; } = new Competition();

        public ICommand CreateCommand { get; }

        public CompetitionCreateViewModel()
        {
            CreateCommand = new Command(async () => await CreateCompetition());
        }

        private async Task CreateCompetition()
        {
            if (string.IsNullOrWhiteSpace(NewCompetition.Name))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "El nombre es requerido", "OK");
                return;
            }

            bool success = await _service.CreateCompetitionAsync(NewCompetition);
            if (success)
            {
                await Application.Current.MainPage.DisplayAlert("Éxito", "Competencia creada", "OK");
                await Shell.Current.GoToAsync("..");
            }
            else
                await Application.Current.MainPage.DisplayAlert("Error", "No se pudo crear competencia", "OK");
        }
    }
}
