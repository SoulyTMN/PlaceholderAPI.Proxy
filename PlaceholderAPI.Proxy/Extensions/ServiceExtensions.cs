using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlaceholderAPI.Proxy.Configuration.Options;
using PlaceholderAPI.Proxy.Interfaces;
using System;

namespace PlaceholderAPI.Proxy.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureHttpClients(this IServiceCollection services, IConfigurationSection configurationSection)
        {
            var placeholderOptions = new PlaceholderAPIOptions();
            configurationSection.Bind(placeholderOptions);

            #region generated-clients
            //https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-2.1#generated-clients
            //https://github.com/reactiveui/refit
            #endregion
            services.AddHttpClient("placeholder.api", c =>
            {
                c.BaseAddress = new Uri(placeholderOptions.BaseUri ?? "https://jsonplaceholder.typicode.com/");
            })
            .AddTypedClient(c => Refit.RestService.For<IUsersClient>(c))
            .AddTypedClient(c => Refit.RestService.For<IAlbumsClient>(c));
        }
    }
}
