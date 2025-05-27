using System.Threading.Tasks;
using System.Windows.Input;
using DesdeElBanquilloMaui.Models;
using DesdeElBanquilloMaui.Services;
using Microsoft.Maui.Controls;

namespace DesdeElBanquilloMaui.ViewModels
{
    public class AdministratorCreateViewModel : BaseViewModel
    {
        private readonly AdministratorService _service = new();

        public Administrator NewAdministrator { get; set; } = new Administrator();

        public ICommand CreateCommand { get; }

        public AdministratorCreateViewModel()
        {
            CreateCommand = new Command(async () => await CreateAdministrator());
        }

        private async Task CreateAdministrator()
        {
            if (string.IsNullOrWhiteSpace(NewAdministrator.Name) ||
                string.IsNullOrWhiteSpace(NewAdministrator.Email) ||
                string.IsNullOrWhiteSpace(NewAdministrator.Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Debe completar todos los campos requeridos", "OK");
                return;
            }

            bool success = await _service.CreateAdministratorAsync(NewAdministrator);
            if (success)
            {
                await Application.Current.MainPage.DisplayAlert("Éxito", "Administrador creado", "OK");
                await Shell.Current.GoToAsync("..");
            }
            else
                await Application.Current.MainPage.DisplayAlert("Error", "No se pudo crear administrador", "OK");
        }
    }
}
