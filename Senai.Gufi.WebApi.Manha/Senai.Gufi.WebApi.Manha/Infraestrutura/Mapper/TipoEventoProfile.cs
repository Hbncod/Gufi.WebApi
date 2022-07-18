using AutoMapper;
using Senai.Gufi.WebApi.Manha.Domains;
using Senai.Gufi.WebApi.Manha.Models;

namespace Senai.Gufi.WebApi.Manha.Infraestrutura.Mapper
{
    public class TipoEventoProfile : Profile
    {
        public TipoEventoProfile()
        {
            CreateMap<TipoEvento, TipoEventoModel>()
                .ForMember(dst => dst.Titulo, map => map.MapFrom(x => x.TituloTipoEvento)).ReverseMap();
        }
    }
}
