namespace DesdeElBanquilloMaui;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(Views.Administrators.AdministratorDetailPage), typeof(Views.Administrators.AdministratorDetailPage));
        Routing.RegisterRoute(nameof(Views.Administrators.AdministratorCreatePage), typeof(Views.Administrators.AdministratorCreatePage));

        Routing.RegisterRoute(nameof(Views.Competitions.CompetitionDetailPage), typeof(Views.Competitions.CompetitionDetailPage));

        Routing.RegisterRoute(nameof(Views.Teams.TeamDetailPage), typeof(Views.Teams.TeamDetailPage));

        Routing.RegisterRoute(nameof(Views.Players.PlayerDetailPage), typeof(Views.Players.PlayerDetailPage));

        Routing.RegisterRoute(nameof(Views.Matches.MatchDetailPage), typeof(Views.Matches.MatchDetailPage));
    }
}
