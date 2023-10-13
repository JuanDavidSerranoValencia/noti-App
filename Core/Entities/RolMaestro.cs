using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

public class RolMaestro : BaseEntity
{

    [Required]
    public int IdRol { get; set; }
    public Rol Rol { get; set; }


    [Required]
    public int IdModuloMaestro { get; set; }
    public ModuloMaestro ModuloMaestro { get; set; }
}
