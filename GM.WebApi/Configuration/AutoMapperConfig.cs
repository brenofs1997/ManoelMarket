using GM.Manager.Mappings;

namespace GM.WebApi.Configuration
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(UserMappingProfile));
        }
    }
}
