using AutoMapper;
using QuizChallenge.Core.DataTransferObject.QuizDtos;
using QuizChallenge.Core.Entities;
using QuizChallenge.Core.Entities.QuizDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizChallenge.Infrastructure.Mapper
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CreateQuizDto, Quiz>().ReverseMap();
                config.CreateMap<UpdateQuizDto, Quiz>().ReverseMap();
                config.CreateMap<ReadQuizDto, Quiz>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
