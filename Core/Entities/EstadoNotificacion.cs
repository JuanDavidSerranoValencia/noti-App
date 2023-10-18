using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class EstadoNotificacion:BaseEntity
    {
        public string NombreEstadoNotificacion { get; set; }

        public ICollection<ModuloNotificacion> ModulosNotificaciones { get; set; }
    }
}