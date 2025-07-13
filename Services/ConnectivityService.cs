using SmartCSLBlog.Services;

public class ConnectivityService : IConnectivityService
{
    public bool HasInternetConnection()
        => NetworkService.HasInternetConnection();
}