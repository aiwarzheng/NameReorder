using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameReorder
{
    public class PersonAscendingOrder : IOrder
    {
        public IEnumerable<Person> Order(IEnumerable<Person> persons)
        {
            if (persons == null)
            {
                throw new ArgumentNullException();
            }

            return persons.OrderBy(p => p.FirstName).ThenBy(p => p.LastName);
        }
    }
}
