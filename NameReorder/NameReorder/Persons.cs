using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameReorder
{
    public class Persons: IOrderOp
    {
        public IEnumerable<Person> People { get; set; }

        public IEnumerable<Person> Order(IOrder orderBy)
        {
            if(orderBy == null)
            {
                new ArgumentNullException();
            }

            return orderBy.Order(People);
        }
    }
}
