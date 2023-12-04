using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Assignment26;

namespace Assignment26
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee()
            {
                Id = 1,
                FirstName = "Rahul",
                LastName = "Chandra",
                Salary = 60000.00

            };
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@"C:\simplilearn\Day-21\Assignment26\employee.bin", FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, emp);
            stream.Close();

            stream = new FileStream(@"C:\simplilearn\Day-21\Assignment26\employee.bin", FileMode.Open, FileAccess.Read);
            Employee empdata = (Employee)formatter.Deserialize(stream);
            Console.WriteLine("Binary Serialization");
            Console.WriteLine("ID: " + empdata.Id);
            Console.WriteLine("first Name: " + empdata.FirstName);
            Console.WriteLine("Last Name: " + empdata.LastName);
            Console.WriteLine("Salary: " + empdata.Salary);
            // Console.ReadKey();

             // Employee employee2 = new Employee { Id = 2, FirstName = "Rahul", LastName = "Gandhi", Salary = 55000.00 };
            XmlSerializer serializer = new XmlSerializer(typeof(Employee));
            using (TextWriter write = new StreamWriter("employee.xml"))
            {
                serializer.Serialize(write, emp);
            }
            using (TextReader reader = new StreamReader("employee.xml"))
            {
                Employee dsemployee = (Employee)serializer.Deserialize(reader);
                Console.WriteLine("\nXML");
                Console.WriteLine("ID: " + dsemployee.Id);
                Console.WriteLine("FirstName: " + dsemployee.FirstName);
                Console.WriteLine("LastName: " + dsemployee.LastName);
                Console.WriteLine("Salary: " + dsemployee.Salary);
                Console.ReadKey();
            }
        }
    }
}

  

