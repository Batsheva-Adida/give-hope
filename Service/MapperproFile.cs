using AutoMapper;
using Commont.Dto;
using Commont.Entity;
using Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class MapperproFile:Profile
    {
        public MapperproFile()
        {
            CreateMap<CategoriesDto,Categories>().ReverseMap();
            CreateMap<CustomersDto,Customers>().ReverseMap();
            CreateMap<MedicinesDto,Medicines>().ReverseMap();
            CreateMap<QuestionDto,Question>().ReverseMap();
            CreateMap<CommentsDto,Comments>().ReverseMap();
        }
    }
}
