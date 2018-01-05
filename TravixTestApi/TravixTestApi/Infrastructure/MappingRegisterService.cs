using AutoMapper;
using Infrastructure.Infrastructure;

namespace TravixTestApi.Infrastructure
{
    public static class MappingRegisterService
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(config =>
            {
                InfrastructureMappingRegisterService.Register(config);
            });
        }
    }
}