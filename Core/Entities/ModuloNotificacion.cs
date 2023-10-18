using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ModuloNotificacion:BaseEntity
    {
        public string AsuntoNotificacion { get; set; }
        public string TextoNotificacion { get; set; }
    

        public int IdRadicadoFk { get; set; }
        public Radicado Radicado { get; set; }


        public int IdFormatoFk { get; set; }
        public Formato Formato { get; set; }


        public int IdHiloNotiFk { get; set; }
        public HiloRespuestaNoti HiloRespuestaNoti { get; set; }
    

        public int IdTipoRequerimientoFk { get; set; }
        public TipoRequerimiento TipoRequerimiento { get; set; }   
    

        public int IdTipoNotisFk { get; set; }
        public TipoNoti TipoNoti { get; set; }


        public int IdEstadoNotiFk { get; set; }
        public EstadoNotificacion EstadoNotificacion { get; set; }

    }


}