using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameReorder
{
    public class FileResource : IResource
    {
        private string m_strFile = "";

        public FileResource(string file)
        {
            m_strFile = file;
        }

        public IEnumerable<Person> GetPersons()
        {
            if (!File.Exists(m_strFile))
            {
                throw new FileNotFoundException();
            }

            List<Person> persons = new List<Person>();

            using (StreamReader reader = new StreamReader(m_strFile))
            {
                try
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] strs = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        if (strs.Length != 2)
                        {
                            throw new Exception("Invalid text format");
                        }

                        Person p = new Person();
                        p.FirstName = strs[0].Trim();
                        p.LastName = strs[1].Trim();

                        persons.Add(p);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return persons;
        }
    }
}
