using System.Threading.Tasks;
using System.Windows.Input;
using DesdeElBanquilloMaui.Models;
using DesdeElBanquilloMaui.Services;
using Microsoft.Maui.Controls;

namespace DesdeElBanquilloMaui.ViewModels
{
    [QueryProperty(nameof(IdAdministrator), "IdAdministrator")]
    public class AdministratorDetailViewModel : BaseViewModel
    {
        private readonly AdministratorService _service = new();

        private int _idAdministrator;
        public int IdAdministrator
        {
            get => _idAdministrator;
            set
            {
                SetProperty(ref _idAdministrator, value);
                LoadAdministrator(value);
            }
        }

        private Administrator _administrator = new Administrator();
        public Administrator Administrator
        {
            get => _administrator;
            set => SetProperty(ref _administrator, value);
        }

        public ICommand SaveCommand { get; }
        public ICommand DeleteCommand { get; }

        public AdministratorDetailViewModel()
        {
            SaveCommand = new Command(async () => await SaveAdministrator());
            DeleteCommand = new Command(async () => await DeleteAdministrator());
        }

        private async void LoadAdministrator(int id)
        {
            var admin = await _service.GetAdministratorByIdAsync(id);
            if (admin != null)
            {
                Administrator = admin;
            }
        }

        private async Task SaveAdministrator()
        {
            bool success = await _service.UpdateAdministratorAsync(Administrator.IdAdministrator, Administrator);
            if (success)
                await Application.Current.MainPage.DisplayAlert("Éxito", "Administrador actualizado", "OK");
            else
                await Application.Current.MainPage.DisplayAlert("Error", "No se pudo actualizar", "OK");
        }

        private async Task DeleteAdministrator()
        {
            bool answer = await Application.Current.MainPage.DisplayAlert("Confirmar", "¿Eliminar administrador?", "Sí", "No");
            if (!answer) return;

            bool success = await _service.DeleteAdministratorAsync(Administrator.IdAdministrator);
            if (success)
            {
                await Application.Current.MainPage.DisplayAlert("Éxito", "Administrador eliminado", "OK");
                await Shell.Current.GoToAsync("..");
            }
            else
                await Application.Current.MainPage.DisplayAlert("Error", "No se pudo eliminar", "OK");
        }
    }
}
