namespace SmartCSLBlog.Services
{
    public class NetworkService
    {
        public static bool HasInternetConnection()
        {
            var current = Connectivity.NetworkAccess;
            return current == NetworkAccess.Internet;
        }

        public static bool HasConstrainedConnection()
        {
            var current = Connectivity.NetworkAccess;
            return current == NetworkAccess.ConstrainedInternet;
        }

        public static bool HasAnyConnection()
        {
            var current = Connectivity.NetworkAccess;
            return current == NetworkAccess.Internet ||
                   current == NetworkAccess.ConstrainedInternet;
        }
    }
}
    