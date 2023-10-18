using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

public class RolMaestro : BaseEntity
{
    

    [Required]
    public int IdRolFk { get; set; }
    public Rol Rol { get; set; }


    [Required]
    public int IdModuloMaestroFk { get; set; }
    public ModuloMaestro ModuloMaestro { get; set; }
}
