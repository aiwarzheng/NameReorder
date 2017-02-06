using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameReorder
{
    public interface IOrderOp
    {
        IEnumerable<Person> Order(IOrder orderBy);
    }
}
