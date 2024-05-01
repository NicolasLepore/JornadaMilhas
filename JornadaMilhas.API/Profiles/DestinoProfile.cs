using AutoMapper;
using JornadaMilhas.API.Dtos.DestinoDtos;
using JornadaMilhas.Models;

namespace JornadaMilhas.API.Profiles
{
    public class DestinoProfile : Profile
    {
        public DestinoProfile()
        {
            CreateMap<CreateDestinoDto, Destino>();
            CreateMap<Destino, ReadDestinoDto>();
            CreateMap<UpdateDestinoDto, Destino>();
            CreateMap<Destino, UpdateDestinoDto>();
        }
    }
}
