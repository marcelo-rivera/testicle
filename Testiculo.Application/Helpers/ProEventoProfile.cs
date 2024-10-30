using AutoMapper;
using Testiculo.Application.Dtos;
using Testiculo.Domain;

namespace testiculo.Helpers
{
    public class ProEventoProfile : Profile
    {
        public ProEventoProfile()
        {
            CreateMap<Evento, EventoDto>().ReverseMap();    
            CreateMap<Lote, LoteDto>().ReverseMap(); 
            CreateMap<RedeSocial, RedeSocialDto>().ReverseMap(); 
            CreateMap<Palestrante, PalestranteDto>().ReverseMap(); 
        }
    }
}