using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly NotiAppContext _context;
    private AuditoriaRepository _auditorias { get; set; }
    private BlockChainRepository _blockChains { get; set; }
    private EstadoNotificacionRepository _estadoNotificaciones { get; set; }
    private FormatoRepository _formatos { get; set; }
    private GenericoVsSubmoduloRepository _genericoVsSubmodulos { get; set; }
    private HiloRespuestaNotiRepository _hiloRespuestaNotis { get; set; }
    private MaestroVsSubmoduloRepository _maestroVsSubmodulos { get; set; }
    private ModuloMaestroRepository _moduloMaestros { get; set; }
    private PermisoGenericoRepository _permisoGenericos { get; set; }
    private RadicadoRepository _radicados { get; set; }
    private RolRepository _rols { get; set; }
    private RolMaestroRepository _rolMaestros { get; set; }
    private SubModuloRepository _subModulos { get; set; }
    private TipoNotiRepository _tipoNotis { get; set; }
    private TipoRequerimientoRepository _tipoRequerimientos { get; set; }

    public IAuditoriaRepository Auditorias
    {
        get
        {
            if (_auditorias == null)
            {
                _auditorias = new AuditoriaRepository(_context);
            }
            return _auditorias;

        }
    }

    public IBlockChainRepository BlockChains
    {
        get
        {
            if (_blockChains == null)
            {

                _blockChains = new BlockChainRepository(_context);

            }
            return _blockChains;

        }
    }

    public EstadoNotificacionRepository EstadoNotificaciones
    {
        get
        {
            if (_estadoNotificaciones == null)
            {
                _estadoNotificaciones = new EstadoNotificacionRepository(_context);
            }
            return _estadoNotificaciones;
        }
    }

    public FormatoRepository Formatos
    {
        get
        {
            if (_formatos == null)
            {
                _formatos = new FormatoRepository(_context);
            }
            return _formatos;
        }

    }

    public GenericoVsSubmoduloRepository GenericoVsSubmodulos
    {
        get
        {
            if (_genericoVsSubmodulos == null)
            {
                _genericoVsSubmodulos = new GenericoVsSubmoduloRepository(_context);
            }
            return _genericoVsSubmodulos;
        }

    }

    public HiloRespuestaNotiRepository HiloRespuestaNotis
    {
        get
        {
            if (_hiloRespuestaNotis == null)
            {
                _hiloRespuestaNotis = new HiloRespuestaNotiRepository(_context);
            }
            return _hiloRespuestaNotis;
        }

    }


    public MaestroVsSubmoduloRepository MaestroVsSubmodulos
    {
        get
        {
            if (_maestroVsSubmodulos == null)
            {
                _maestroVsSubmodulos = new MaestroVsSubmoduloRepository(_context);
            }
            return _maestroVsSubmodulos;
        }

    }

    public ModuloMaestroRepository ModuloMaestros
    {
        get
        {
            if (_moduloMaestros == null)
            {
                _moduloMaestros = new ModuloMaestroRepository(_context);
            }
            return _moduloMaestros;
        }

    }
    public PermisoGenericoRepository PermisoGenericos
    {
        get
        {
            if (_permisoGenericos == null)
            {
                _permisoGenericos = new PermisoGenericoRepository(_context);
            }
            return _permisoGenericos;
        }

    }

    public RadicadoRepository Radicados
    {
        get
        {
            if (_radicados == null)
            {
                _radicados = new RadicadoRepository(_context);
            }
            return _radicados;
        }

    }


    public RolRepository Rols
    {
        get
        {
            if (_rols == null)
            {
                _rols = new RolRepository(_context);
            }
            return _rols;
        }

    }

    public RolMaestroRepository RolMaestros
    {
        get
        {
            if (_rolMaestros == null)
            {
                _rolMaestros = new RolMaestroRepository(_context);
            }
            return _rolMaestros;
        }

    }


    public SubModuloRepository SubModulos
    {
        get
        {
            if (_subModulos == null)
            {
                _subModulos = new SubModuloRepository(_context);
            }
            return _subModulos;
        }

    }


    public TipoNotiRepository TipoNotis
    {
        get
        {
            if (_tipoNotis == null)
            {
                _tipoNotis = new TipoNotiRepository(_context);
            }
            return _tipoNotis;
        }

    }

    public TipoRequerimientoRepository TipoRequerimientos
    {
        get
        {
            if (_tipoRequerimientos == null)
            {
                _tipoRequerimientos = new TipoRequerimientoRepository(_context);
            }
            return _tipoRequerimientos;
        }

    }

    IEstadoNotificacionRepository IUnitOfWork.EstadoNotificaciones => throw new NotImplementedException();

    IFormatoRepository IUnitOfWork.Formatos => throw new NotImplementedException();

    IGenericoVsSubmoduloRepository IUnitOfWork.GenericoVsSubmodulos => throw new NotImplementedException();

    IHiloRespuestaNotiRepository IUnitOfWork.HiloRespuestaNotis => throw new NotImplementedException();

    IMaestroVsSubmoduloRepository IUnitOfWork.MaestroVsSubmodulos => throw new NotImplementedException();

    IModuloMaestroRepository IUnitOfWork.ModuloMaestros => throw new NotImplementedException();

    public IModuloNotificacionRepository ModuloNotificaciones => throw new NotImplementedException();

    IPermisoGenericoRepository IUnitOfWork.PermisoGenericos => throw new NotImplementedException();

    IRadicadoRepository IUnitOfWork.Radicados => throw new NotImplementedException();

    IRolMaestroRepository IUnitOfWork.RolMaestros => throw new NotImplementedException();

    public IRolRepository Roles => throw new NotImplementedException();

    ISubModuloRepository IUnitOfWork.SubModulos => throw new NotImplementedException();

    ITipoNotiRepository IUnitOfWork.TipoNotis => throw new NotImplementedException();

    ITipoRequerimientoRepository IUnitOfWork.TipoRequerimientos => throw new NotImplementedException();

    public UnitOfWork(NotiAppContext context)
    {
        _context = context;
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
