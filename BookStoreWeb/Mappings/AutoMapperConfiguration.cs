using AutoMapper;
using BookStoreModel.Models;
using BookStoreWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreWeb.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<Post, PostViewModel>();
            Mapper.CreateMap<PostCategory, PostCategoryViewModel>();
            Mapper.CreateMap<Tag, TagViewModel>();
        }
    }
}