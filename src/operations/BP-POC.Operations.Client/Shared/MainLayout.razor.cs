namespace BP_POC.Operations.Client.Shared;

public partial class MainLayout
{
    bool _drawerOpen = false;
    void DrawerToggle()
    {
        _drawerOpen = !_drawerOpen;
    }
}