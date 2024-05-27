using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMesDocumentation.Domain.Entities
{
    public class ProcessEntity
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public int OrderId { get; set; }
        public OrderEntity Order { get; set; }
        public string Status { get; set; }
        public DateTime DateTime { get; set; }
        public ICollection<ParameterValueEntity> ParameterValues { get; set; }
    }
}
