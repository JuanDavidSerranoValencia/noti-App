using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class TipoRequerimiento
    {
        public string NombreTipoRequerimiento { get; set; }

        public ICollection<ModuloNotificacion> ModulosNotificaciones { get; set; }
    }
}