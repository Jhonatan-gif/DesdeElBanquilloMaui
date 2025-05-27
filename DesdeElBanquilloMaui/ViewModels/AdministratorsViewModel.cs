using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using DesdeElBanquilloMaui.Models;
using DesdeElBanquilloMaui.Services;
using Microsoft.Maui.Controls;

namespace DesdeElBanquilloMaui.ViewModels
{
    public class AdministratorsViewModel : BaseViewModel
    {
        private readonly AdministratorService _service = new();

        public ObservableCollection<Administrator> Administrators { get; } = new();

        private string _searchText = "";
        public string SearchText
        {
            get => _searchText;
            set
            {
                if (SetProperty(ref _searchText, value))
                    FilterAdministrators();
            }
        }

        private List<Administrator> _allAdmins = new();

        public ICommand LoadCommand { get; }
        public ICommand DeleteCommand { get; }

        public AdministratorsViewModel()
        {
            LoadCommand = new Command(async () => await LoadAdministrators());
            DeleteCommand = new Command<Administrator>(async (admin) => await DeleteAdministrator(admin));
        }

        private async Task LoadAdministrators()
        {
            var admins = await _service.GetAdministratorsAsync();
            _allAdmins = admins;
            Administrators.Clear();
            foreach (var a in admins)
                Administrators.Add(a);
        }

        private void FilterAdministrators()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                Administrators.Clear();
                foreach (var a in _allAdmins)
                    Administrators.Add(a);
            }
            else
            {
                var filtered = _allAdmins.Where(a =>
                    a.Name.Contains(SearchText, System.StringComparison.OrdinalIgnoreCase) ||
                    a.Email.Contains(SearchText, System.StringComparison.OrdinalIgnoreCase)).ToList();

                Administrators.Clear();
                foreach (var a in filtered)
                    Administrators.Add(a);
            }
        }

        private async Task DeleteAdministrator(Administrator admin)
        {
            if (admin == null) return;

            bool success = await _service.DeleteAdministratorAsync(admin.IdAdministrator);
            if (success)
            {
                Administrators.Remove(admin);
                _allAdmins.Remove(admin);
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "No se pudo eliminar administrador", "OK");
            }
        }
    }
}
