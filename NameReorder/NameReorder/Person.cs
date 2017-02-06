using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameReorder
{
    public class Person: IPersonFormat
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FormatToString()
        {
            return string.Format("{0}, {1}", FirstName, LastName);
        }

        public override bool Equals(object obj)
        {
            if (obj is Person)
            {
                Person p = obj as Person;
                return p.FirstName == this.FirstName &&
                    p.LastName == this.LastName;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return FormatToString().GetHashCode();
        }
    }
}
