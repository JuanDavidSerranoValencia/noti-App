using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class BlockChain:BaseEntity
    {
        public string HashGenerado { get; set; }


        public int IdTipoNotisFk { get; set; }
        public TipoNoti TipoNoti{ get; set; }

        public int IdAuditoriaFk { get; set; }
        public Auditoria Auditoria { get; set; }
    }
}