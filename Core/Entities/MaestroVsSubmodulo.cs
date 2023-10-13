using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

public class MaestroVsSubmodulo
{
    [Required]
    public int IdModuloMaestroFk { get; set; }
    public ModuloMaestro ModuloMaestro { get; set; }

    [Required]

    public int IdSubModuloFk { get; set; }
    public SubModulo SubModulo { get; set; }

    public ICollection<GenericoVsSubmodulo> GenericosVsModulos { get; set; }
}
