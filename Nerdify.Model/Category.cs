using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nerdify.Model
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public string ItemTypeId { get; set; }

    }
}
