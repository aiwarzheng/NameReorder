using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameReorder
{
    /// <summary>
    /// Serialize Person
    /// </summary>
    public interface ISaver
    {
        void Save(IEnumerable<Person> persons);
    }
}
