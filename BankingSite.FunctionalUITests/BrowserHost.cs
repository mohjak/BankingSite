using TestStack.Seleno.Configuration;

namespace BankingSite.FunctionalUITests
{
    public static class BrowserHost
    {
        public static readonly SelenoHost Instance = new SelenoHost();
        public static readonly string RootUrl;

        static BrowserHost()
        {
            Instance.Run("BankingSite", 4223, config => config.WithRouteConfig(RouteConfig.RegisterRoutes));

            RootUrl = Instance.Application.Browser.Url;
        }
    }
}
