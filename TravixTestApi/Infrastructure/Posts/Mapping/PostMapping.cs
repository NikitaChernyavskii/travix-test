using AutoMapper;
using DAL.Entities;
using Infrastructure.Posts.Models;

namespace Infrastructure.Posts.Mapping
{
    public static class PostMapping
    {
        public static void Register(IMapperConfigurationExpression config)
        {
            config.CreateMap<Post, PostView>();
            config.CreateMap<PostModel, Post>();
        }

        public static PostView ToView(this Post entity)
        {
            return Mapper.Map<PostView>(entity);
        }

        public static Post ToEntity(this PostModel model)
        {
            return Mapper.Map<Post>(model);
        }
    }
}
