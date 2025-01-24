using Understanding_the_Mvc.Iservices;
using Understanding_the_Mvc.Services;

namespace Understanding_the_Mvc.Extensions;
 public static class LifetimeServicesCollectionExtensions
 {
    public static IServiceCollection AddServices(this 
IServiceCollection services)
    {
        
        services.AddTransient<IPostService, PostService>();
        return services;
    }
 }