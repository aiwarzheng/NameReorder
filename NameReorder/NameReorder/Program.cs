using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameReorder
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please input file parameter");
                Console.WriteLine("press any key to exit...");
                Console.ReadKey();
                return;
            }

            string file = args[0];

            Console.WriteLine(string.Format("processing file:{0}", file));
            try
            {
                IResource resource = new FileResource(file);
                IEnumerable<Person> persons = resource.GetPersons();
                Persons ps = new Persons()
                {
                    People = persons
                };
                IOrder orderBy = new PersonAscendingOrder();
                IEnumerable<Person> result = ps.Order(orderBy);

                string dir = PathUtil.GetDir(file);
                string fileName = PathUtil.GetFileName(file);
                string ext = PathUtil.GetFileExtension(file);

                string outputFile = string.Format("{0}{1}-sorted{2}", dir, fileName, ext);
                ISaver pSaver = new FileSaver(outputFile);
                pSaver.Save(result);

                Console.WriteLine(string.Format("output path:{0}", outputFile));
                Console.WriteLine("Done");
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("ERROR:{0}", ex.Message));
            }

            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
    }
}
