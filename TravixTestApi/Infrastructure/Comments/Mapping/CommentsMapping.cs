using AutoMapper;
using DAL.Entities;
using Infrastructure.Comments.Models;

namespace Infrastructure.Comments.Mapping
{
    public static class CommentsMapping
    {
        public static void Register(IMapperConfigurationExpression config)
        {
            config.CreateMap<Comment, CommentView>();
            config.CreateMap<CommentModel, Comment>();
        }

        public static CommentView ToView(this Comment entity)
        {
            return Mapper.Map<CommentView>(entity);
        }

        public static Comment ToEntity(this CommentModel model)
        {
            return Mapper.Map<Comment>(model);
        }
    }
}
