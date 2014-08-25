using System.Web.Http;
using System.Web.Http.Routing;

namespace Drum
{
    public static class HttpConfigurationExtensions
    {
        private const string Key = "UriMakerContext";

        public static UriMakerContext MapHttpAttributeRoutesAndUseUriMaker(
            this HttpConfiguration configuration,
            IDirectRouteProvider directRouteProvider = null)
        {
            directRouteProvider = directRouteProvider ?? new DefaultDirectRouteProvider();
            var decorator = new DecoratorRouteProvider(directRouteProvider);
            configuration.MapHttpAttributeRoutes(decorator);
            var uriMakerContext = new UriMakerContext(decorator.RouteMap);

            configuration.Properties[Key] = uriMakerContext;

            return uriMakerContext;
        }

        public static UriMakerContext TryGetUriMakerFactory(this HttpConfiguration configuration)
        {
            object value;
            if (!configuration.Properties.TryGetValue(Key, out value))
            {
                return null;
            }
            return value as UriMakerContext;
        }
    }
}