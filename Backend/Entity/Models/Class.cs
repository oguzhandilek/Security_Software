using Entity.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Class: BaseEntity
    {
        public string ClassName { get; set; }
        public string ClassCode { get; set; }
        
        public Class() { }
    }
}
