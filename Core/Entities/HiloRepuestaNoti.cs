using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class HiloRepuestaNoti:BaseEntity
    {
        public string NombreTipoHilo{ get; set; }

        public ICollection<ModuloNotificacion> ModulosNotificaciones{ get; set; }
        public ICollection<BlockChain> BlocksChains { get; set; }
    }
}