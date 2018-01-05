using AutoMapper;
using Infrastructure.Comments.Mapping;

namespace Infrastructure.Infrastructure
{
    public static class InfrastructureMappingRegisterService
    {
        public static void Register(IMapperConfigurationExpression config)
        {
            CommentsMapping.Register(config);
        }
    }
}
