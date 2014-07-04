using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Invest.Core;

namespace Invest.Web
{
    public static class MappingExtensions
    {

        public static CategoryModel ToModel(this Category entity)
        {
            return Mapper.DynamicMap<Category, CategoryModel>(entity);
        }

        public static Category ToEntity(this CategoryModel model)
        {
            return Mapper.DynamicMap<CategoryModel, Category>(model);
        }

        public static NewsModel ToModel(this News entity)
        {
            return Mapper.DynamicMap<News, NewsModel>(entity);
        }

        public static News ToEntity(this NewsModel model)
        {
            return Mapper.DynamicMap<NewsModel, News>(model);
        }

        public static SliderBarModel ToModel(this SliderBar entity)
        {
            return Mapper.DynamicMap<SliderBar, SliderBarModel>(entity);
        }

        public static SliderBar ToEntity(this SliderBarModel model)
        {
            return Mapper.DynamicMap<SliderBarModel, SliderBar>(model);
        }
    }
}