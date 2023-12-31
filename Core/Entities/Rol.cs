using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

public class Rol : BaseEntity
{
    public string NombreRol { get; set; }

    public ICollection<RolMaestro> RolesMaestros { get; set; }
    public ICollection<GenericoVsSubmodulo> GenericosVsSubmodulos { get; set; }
}
