using AutoMapper;
using Domain.Entities;
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

            _expression = expression;
        }

        private void MapperOutUserConfiguration(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<User, OutUser>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.PhotoFileName, opt => opt.MapFrom(src => src.PhotoUrl))
                .ForMember(dest => dest.Interests, opt => opt.MapFrom(
                    src => src.Interests.Select(
                        x => new OutInterest
                        { 
                            Id = x.Id, 
                            Name = x.Name 
                        }).ToArray()));
        }
    }
}
