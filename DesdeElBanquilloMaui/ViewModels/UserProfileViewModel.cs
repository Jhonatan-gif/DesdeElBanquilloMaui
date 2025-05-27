using System.Threading.Tasks;
using System.Windows.Input;
using DesdeElBanquilloMaui.Models;
using DesdeElBanquilloMaui.Services;
using Microsoft.Maui.Controls;

namespace DesdeElBanquilloMaui.ViewModels
{
    public class UserProfileViewModel : BaseViewModel
    {
        private readonly UserService _service = new();

        private User _user = new();
        public User User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }

        public ICommand LoadUserCommand { get; }
        public ICommand SaveUserCommand { get; }

        public UserProfileViewModel()
        {
            LoadUserCommand = new Command(async () => await LoadUser());
            SaveUserCommand = new Command(async () => await SaveUser());
        }

        public async Task LoadUser()
        {
            // Asume que tienes id de usuario almacenado, aquí id=1 por ejemplo
            User = await _service.GetUserByIdAsync(1) ?? new User();
        }

        public async Task SaveUser()
        {
            bool success = await _service.UpdateUserAsync(User.IdUser, User);
            if (success)
                await Application.Current.MainPage.DisplayAlert("Éxito", "Perfil actualizado", "OK");
            else
                await Application.Current.MainPage.DisplayAlert("Error", "No se pudo actualizar perfil", "OK");
        }
    }
}
