using AutoMapper;
using Infrastructure.Comments.Mapping;
using Infrastructure.Posts.Mapping;

namespace Infrastructure.Infrastructure
{
    public static class InfrastructureMappingRegisterService
    {
        public static void Register(IMapperConfigurationExpression config)
        {
            CommentsMapping.Register(config);
            PostMapping.Register(config);
        }
    }
}
