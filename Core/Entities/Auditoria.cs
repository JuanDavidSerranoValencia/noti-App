using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Auditoria
    {
        public string NombreUsuarioAuditoria { get; set; }
        public int DescAccion { get; set; }

        public ICollection<BlockChain> BlocksChains { get; set; }
    }
}