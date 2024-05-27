using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMesDocumentation.Domain.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public int MachineId { get; set; } 
        public MachineEntity Machine { get; set; } 
        public int ProductId { get; set; } 
        public ProductEntity Product { get; set; } 
        public int Quantity { get; set; } 
        public ICollection<ProcessEntity> Processes { get; set; }
    }
}
