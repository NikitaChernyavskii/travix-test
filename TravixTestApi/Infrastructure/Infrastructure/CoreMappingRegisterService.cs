using AutoMapper;
using Core.Comments.Mapping;
using Core.Posts.Mapping;

namespace Core.Infrastructure
{
    public static class CoreMappingRegisterService
    {
        public static void Register(IMapperConfigurationExpression config)
        {
            CommentsMapping.Register(config);
            PostMapping.Register(config);
        }
    }
}
