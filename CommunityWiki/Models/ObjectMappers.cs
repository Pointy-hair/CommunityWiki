﻿using AutoMapper;
using CommunityWiki.Entities.Articles;
using CommunityWiki.Models.Articles;
using CommunityWiki.Models.ArticleTypes;

namespace CommunityWiki.Models
{
    public static class ObjectMappers
    {
        internal static IMapper Mapper { get; }

        static ObjectMappers()
        {
            Mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ArticleTypeMapProfile>();
                cfg.AddProfile<ArticleMapProfile>();
            }).CreateMapper();
        }
    }

    public class ArticleTypeMapProfile : Profile
    {
        public ArticleTypeMapProfile()
        {
            CreateMap<ArticleType, ArticleTypeModel>();
            CreateMap<ArticleType, EditArticleTypeViewModel>();
        }
    }

    public class ArticleMapProfile : Profile
    {
        public ArticleMapProfile()
        {
            CreateMap<Article, ArticleModel>();
            CreateMap<Article, EditArticleViewModel>();
            CreateMap<Article, ArticleViewModel>();
        }
    }

    public static class ModelExtensions
    {
        public static ArticleTypeModel ToModel(this ArticleType type) => Mapper.Map<ArticleTypeModel>(type);
        public static EditArticleTypeViewModel ToEditModel(this ArticleType type) => Mapper.Map<EditArticleTypeViewModel>(type);
        public static ArticleViewModel ToViewModel(this Article article) => Mapper.Map<ArticleViewModel>(article);
    }
}
