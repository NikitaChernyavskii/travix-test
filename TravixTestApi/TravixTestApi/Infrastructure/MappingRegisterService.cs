using AutoMapper;
using Core.Infrastructure;

namespace TravixTestApi.Infrastructure
{
    public static class MappingRegisterService
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(config =>
            {
                CoreMappingRegisterService.Register(config);
            });
        }
    }
}