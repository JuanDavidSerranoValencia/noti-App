using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNotiApi.Dtos
{
    public class SubModuloDto
    {

        public int Id { get; set; }
        public string NombreSubmodulo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}