using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace NameReorder.UnitTests
{
    public class Utils
    {
        public static bool IsEqual(List<Person> lstResult, List<Person> ps)
        {
            int sizeOfPerson = ps.Count;

            bool b = true;
            for (int i = 0; i < sizeOfPerson; i++)
            {
                Person p = ps[i];
                Person px = lstResult[i];

                if (!p.Equals(px))
                {
                    b = false;
                }
            }

            return b;
        }
    }

    [TestFixture]
    public class DataResourceTests
    {
        [Test]
        public void File_Not_Exists_Throws_FileNotFoundException_TestMethod()
        {
            string file = "test.txt";
            IResource resource = new FileResource(file);
            Assert.Throws(typeof(FileNotFoundException), () => resource.GetPersons());
        }

        [Test]
        public void Data_Format_Invalid_Throws_Exception_WithInvalidMessage_TestMethod()
        {
            var dir = Path.GetDirectoryName(new Uri(typeof(DataResourceTests).Assembly.CodeBase).LocalPath);
            string file = string.Format("{0}{1}{2}", dir, Path.DirectorySeparatorChar, "person.txt");
            IResource resource = new FileResource(file);
            Assert.Throws(typeof(Exception), () => resource.GetPersons(), "Invalid text format", null);
        }

        [Test]
        public void Data_Read_TestMethod()
        {
            List<Person> lstResult = new List<Person>()
            {
                new Person() { FirstName="BAKER", LastName="THEODORE" },
                new Person() { FirstName="SMITH", LastName="ANDREW" },
                new Person() { FirstName="KENT", LastName="MADISON" },
                new Person() { FirstName="SMITH", LastName="FREDRICK" }
            };
            
            var dir = Path.GetDirectoryName(new Uri(typeof(DataResourceTests).Assembly.CodeBase).LocalPath);
            string file = string.Format("{0}{1}{2}", dir, Path.DirectorySeparatorChar, "data.txt");
            IResource resource = new FileResource(file);
            IEnumerable<Person> persons = resource.GetPersons();

            List<Person> ps = new List<Person>(persons);

            Assert.IsTrue(Utils.IsEqual(lstResult, ps));
        }
    }

    [TestFixture]
    public class OrderTests
    {
        [Test]
        public void Person_OrderBy_Null_Parameters_Throws_ArgumentNullException_TestMethod()
        {
            IOrder orderBy = new PersonAscendingOrder();
            Assert.Throws(typeof(ArgumentNullException), () => orderBy.Order(null));
        }

        [Test]
        public void Person_OrderBy_TestMethod()
        {
            List<Person> lstPersons = new List<Person>()
            {
                new Person() { FirstName="BAKER", LastName="THEODORE" },
                new Person() { FirstName="SMITH", LastName="ANDREW" },
                new Person() { FirstName="KENT", LastName="MADISON" },
                new Person() { FirstName="SMITH", LastName="FREDRICK" }
            };

            List<Person> lstResult = new List<Person>()
            {
                new Person() { FirstName="BAKER", LastName="THEODORE" },
                new Person() { FirstName="KENT", LastName="MADISON" },
                new Person() { FirstName="SMITH", LastName="ANDREW" },
                new Person() { FirstName="SMITH", LastName="FREDRICK" }
            };

            IOrder orderBy = new PersonAscendingOrder();
            IEnumerable<Person> persons = orderBy.Order(lstPersons);
            List<Person> ps = new List<Person>(persons);

            Assert.IsTrue(Utils.IsEqual(lstResult, ps));
        }
    }

    [TestFixture]
    public class OutputTests
    {
        [Test]
        public void Person_Output_Throws_ArgumentNullException_TestMethod()
        {
            string file = "result.txt";
            ISaver saver = new FileSaver(file);
            Assert.Throws(typeof(ArgumentNullException), () => saver.Save(null));
        }

        [Test]
        public void Person_Output_TestMethod()
        {
            List<Person> lstResult = new List<Person>()
            {
                new Person() { FirstName="BAKER", LastName="THEODORE" },
                new Person() { FirstName="KENT", LastName="MADISON" },
                new Person() { FirstName="SMITH", LastName="ANDREW" },
                new Person() { FirstName="SMITH", LastName="FREDRICK" }
            };

            string file = "result.txt";
            ISaver saver = new FileSaver(file);
            saver.Save(lstResult);

            IResource resource = new FileResource(file);
            IEnumerable<Person> persons = resource.GetPersons();

            List<Person> ps = new List<Person>(persons);

            Assert.IsTrue(Utils.IsEqual(lstResult, ps));
        }
    }
}
