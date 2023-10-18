using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNotiApi.Dtos
{
    public class HiloRespuestaNotiDto
    {
        public int Id { get; set; }
        public string NombreTipoHilo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}