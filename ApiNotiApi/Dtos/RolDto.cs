using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNotiApi.Dtos
{
    public class RolDto
    {
         public int Id { get; set; }
        public string NombreRol { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}