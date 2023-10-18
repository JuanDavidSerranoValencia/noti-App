using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNotiApi.Dtos;
using AutoMapper;
using Core.Entities;

namespace ApiNotiApi.Profiles
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles(){

            CreateMap<Auditoria,AuditoriaDto>().ReverseMap();
            CreateMap<BlockChain,BlockChainDto>().ReverseMap();
            CreateMap<EstadoNotificacion,EstadoNotificacionDto>().ReverseMap();
            CreateMap<GenericoVsSubmodulo,GenericoVsSubmoduloDto>().ReverseMap();
            CreateMap<HiloRepuestaNoti,HiloRespuestaNotiDto>().ReverseMap();
            CreateMap<MaestroVsSubmodulo,MaestroVsSubmoduloDto>().ReverseMap();
            CreateMap<ModuloMaestro,ModuloMaestroDto>().ReverseMap();
            CreateMap<ModuloNotificacion,ModuloNotificacionDto>().ReverseMap();
            CreateMap<PermisoGenerico,PermisoGenericoDto>().ReverseMap();
            CreateMap<Radicado,RadicadoDto>().ReverseMap();
            CreateMap<Rol,RolDto>().ReverseMap();
            CreateMap<RolMaestro,RolMaestroDto>().ReverseMap();
            CreateMap<SubModulo,SubModuloDto>().ReverseMap();
            CreateMap<TipoNoti,TipoNotiDto>().ReverseMap();
           CreateMap<TipoRequerimiento,TipoRequerimientoDto>().ReverseMap();
        }        
    }
}