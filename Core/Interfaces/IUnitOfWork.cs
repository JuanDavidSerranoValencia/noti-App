using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork
    {
        IAuditoriaRepository Auditorias { get; }
        IBlockChainRepository BlockChains { get; }
        IEstadoNotificacionRepository EstadoNotificaciones { get; }
        IFormatoRepository Formatos { get; }
        IGenericoVsSubmoduloRepository GenericoVsSubmodulos { get; }
        IHiloRespuestaNotiRepository HiloRespuestaNotis { get; }
        IMaestroVsSubmoduloRepository MaestroVsSubmodulos { get; }
        IModuloMaestroRepository ModuloMaestros { get; }
        IModuloNotificacionRepository ModuloNotificaciones { get; }
        IPermisoGenericoRepository PermisoGenericos { get; }
        IRadicadoRepository Radicados { get; }
        IRolMaestroRepository RolMaestros { get; }
        IRolRepository Roles { get; }
        ISubModuloRepository SubModulos { get; }
        ITipoNotiRepository TipoNotis { get; }
        ITipoRequerimientoRepository TipoRequerimientos { get; }

        Task<int> SaveAsync();
    }
}