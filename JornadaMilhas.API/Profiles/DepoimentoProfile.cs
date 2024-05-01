using AutoMapper;
using JornadaMilhas.API.Dtos.DepoimentoDtos;
using JornadaMilhas.Models;

namespace JornadaMilhas.API.Profiles
{
    public class DepoimentoProfile : Profile
    {
        public DepoimentoProfile()
        {
            CreateMap<CreateDepoimentoDto, Depoimento>();
            CreateMap<Depoimento, ReadDepoimentoDto>();
            CreateMap<UpdateDepoimentoDto, Depoimento>();
            CreateMap<Depoimento, UpdateDepoimentoDto>();
        }
    }
}
