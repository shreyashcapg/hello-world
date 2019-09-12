using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BinarySerializationExample
{
    [Serializable]
    class Person
    {
        public string PersonName { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
        public bool IsRegistered { get; set; }
        public Person(string PersonName, int Age, char Gender, bool IsRegistered)
        {
            this.PersonName = PersonName;
            this.Age = Age;
            this.Gender = Gender;
            this.IsRegistered = IsRegistered;
        }
    }
    class Program
    {
        static void Main()
        {
            //Serialization
            Person person1 = new Person("Scott",20,'M',true);
            string filePath = @"c:\capg\person";
            FileStream fileStream1 = new FileStream(filePath,FileMode.Create,FileAccess.Write);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fileStream1,person1);
            fileStream1.Close();
            Console.WriteLine("Serialization Completed");
            Console.ReadKey();

            //Deserialization(Same class must be used)
            Person person2;
            FileStream fileStream2 = new FileStream(filePath,FileMode.Open,FileAccess.Read);
            person2 = (Person)binaryFormatter.Deserialize(fileStream2);
            Console.WriteLine("Person Name: "+person2.PersonName);
            Console.WriteLine("Age: "+person2.Age);
            Console.WriteLine("Gender: " + person2.Gender);
            Console.WriteLine("Is Registered: ", person2.IsRegistered);
            Console.ReadKey();
        }
    }
}
