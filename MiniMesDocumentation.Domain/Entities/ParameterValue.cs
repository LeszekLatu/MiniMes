using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMesDocumentation.Domain.Entities
{
    public class ParameterValueEntity
    {
        public int Id { get; set; }
        public int ProcessId { get; set; }
        public ProcessEntity Process { get; set; }
        public int ParameterId { get; set; }
        public ParameterEntity Parameter { get; set; }
        public string Value { get; set; }
    }
}
