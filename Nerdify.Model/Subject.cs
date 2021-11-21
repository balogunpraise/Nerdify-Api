using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nerdify.Model
{
    public class Subject : BaseEntity
    {
        public string Name { get; set; }
        public Category Category { get; set; }
        public string CategoryId { get; set; }
    }
}
