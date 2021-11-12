using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace MongoDBWebAPI.Routing
{
    public class EmailRouteContraint : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route,
        string routeKey, RouteValueDictionary values,
        RouteDirection routeDirection)
        {
            return true;
        }
    }
}
