using AutoMapper;
using Domain.Entities;
using EventinoApi.Models.Input;
using EventinoApi.Models.Out;
using System.Linq;

namespace EventinoApi.Configuration
{
    public class MapperConfigurator
    {
        private readonly IMapperConfigurationExpression _expression;

        public IMapperConfigurationExpression AddConfiguretion() => _expression;

        public MapperConfigurator(IMapperConfigurationExpression expression)
        {
            MapperOutUserConfiguration(expression);
            MapperInputUserDtoConfiguration(expression);
            MapperOutEventConfiguration(expression);

            _expression = expression;
        }

        private static void MapperOutUserConfiguration(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<User, OutUser>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.PhotoFileName, opt => opt.MapFrom(src => src.PhotoUrl))
                .ForMember(dest => dest.Interests, opt => opt.MapFrom(
                    src => src.Interests.Select(
                        x => x.Name).ToArray()));
        }

        private static void MapperInputUserDtoConfiguration(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<InputUserDto, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.PhotoFileName))
                .ForMember(dest => dest.Interests, opt => opt.MapFrom(src => src.InterestIds.Select(x => new Interest
                    {
                        Id = x
                    }).ToArray()));
        }

        private static void MapperOutEventConfiguration(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<Event, OutEvent>()
                .ForMember(s => s.Attendees, opt => opt.MapFrom(src => src.Attendees.Select(s => s.Id).ToList()))
                .ForMember(s => s.Interests, opt => opt.MapFrom(src => src.Interests.Select(s => s.Name).ToList()));
        }
    }
}
