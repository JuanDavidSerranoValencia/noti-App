using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

public class GenericoVsSubmodulo : BaseEntity
{

    [Required]
    public int IdRolFk { get; set; }
    public Rol Rol { get; set; }

    [Required]
    public int IdPermisoGenerioFk { get; set; }
    public PermisoGenerico PermisoGenerico { get; set; }

    [Required]
    public int IdMaestroSubmoduloFk { get; set; }
    public MaestroVsSubmodulo MaestroVsSubmodulo { get; set; }
}
