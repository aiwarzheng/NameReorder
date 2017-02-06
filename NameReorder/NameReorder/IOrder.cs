using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameReorder
{
    /// <summary>
    /// Order person
    /// </summary>
    public interface IOrder
    {
        IEnumerable<Person> Order(IEnumerable<Person> persons);
    }
}
