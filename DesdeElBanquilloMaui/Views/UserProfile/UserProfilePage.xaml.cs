namespace DesdeElBanquilloMaui.Views.UserProfile;

public partial class UserProfilePage : ContentPage
{
    public UserProfilePage()
    {
        InitializeComponent();
        this.Appearing += async (_, _) =>
        {
            if (BindingContext is ViewModels.UserProfileViewModel vm)
                 vm.LoadUserCommand.Execute(null);
        };
    }
}
