using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMesDocumentation.Domain.Entities
{
    public class ParameterEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public ICollection<ParameterValueEntity> ParameterValues { get; set; }
    }
}
