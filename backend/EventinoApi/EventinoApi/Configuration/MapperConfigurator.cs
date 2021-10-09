using AutoMapper;
using Domain.Entities;
using EventinoApi.Models.Out;

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
            expression.CreateMap<User, OutUser>();
        }
    }
}
