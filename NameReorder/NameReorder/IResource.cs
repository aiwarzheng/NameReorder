using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameReorder
{
    /// <summary>
    /// Read person data
    /// </summary>
    public interface IResource
    {
        IEnumerable<Person> GetPersons();
    }
}
