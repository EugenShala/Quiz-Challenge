using AutoMapper;
using QuizChallenge.Core.DataTransferObject.AnswerDtos;
using QuizChallenge.Core.DataTransferObject.QuestionDtos;
using QuizChallenge.Core.DataTransferObject.QuizDtos;
using QuizChallenge.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizChallenge.Infrastructure.Mapper
{
    public class MappingConfig : Profile
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CreateQuizDto, Quiz>().ReverseMap();
                config.CreateMap<UpdateQuizDto, Quiz>().ReverseMap();
                config.CreateMap<ReadQuizDto, Quiz>().ReverseMap();
                config.CreateMap<QuizDetailsDto, Quiz>().ReverseMap();


                config.CreateMap<AnswerDetailsDto, Answer>().ReverseMap();


                config.CreateMap<CreateQuestionDto, Question>().ReverseMap();
                config.CreateMap<UpdateQuestionDto, Question>().ReverseMap();
                config.CreateMap<ReadQuestionDto, Question>().ReverseMap();
                config.CreateMap<QuestionDetailsDto, Question>().ReverseMap();

            });
            return mappingConfig;
        }
    }
}
