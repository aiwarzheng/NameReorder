using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameReorder
{
    public class FileSaver : ISaver
    {
        private string m_strFile = "";
        public FileSaver(string file)
        {
            m_strFile = file;
        }

        public void Save(IEnumerable<Person> persons)
        {
            if (persons == null)
            {
                throw new ArgumentNullException();
            }

            using (StreamWriter writer = new StreamWriter(m_strFile, false)) 
            {
                foreach (Person p in persons)
                {
                    writer.WriteLine(p.FormatToString());
                }
            }
        }
    }
}
