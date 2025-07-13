
namespace SmartCSLBlog.Services
{
    

    public class ConexaoService
    {
        public static bool TemConexaoInternet()
        {
            var current = Connectivity.NetworkAccess;
            return current == NetworkAccess.Internet;
        }

        public static bool TemConexaoLimitada()
        {
            var current = Connectivity.NetworkAccess;
            return current == NetworkAccess.ConstrainedInternet;
        }

        public static bool TemAlgumaConexao()
        {
            var current = Connectivity.NetworkAccess;
            return current == NetworkAccess.Internet ||
                   current == NetworkAccess.ConstrainedInternet;
        }
    }
}
