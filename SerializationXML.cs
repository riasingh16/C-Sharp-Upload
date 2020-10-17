using System;
using System.IO;
using System.Xml.Serialization;

namespace XML
{
    public class Student
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public long Number { get; set; }

        public override string ToString()
        {
            return string.Format($"The name: {Name} from {Address} is available at {Number}");
        }
    }
    class SerializationXML
    {
        static void Main(string[] args)
        {
            xml();
        }

        private static void xml()
        {
            Console.WriteLine("Pick your option: Read or Write (R/W)");
            string choice = Console.ReadLine();
            if (choice.ToLower() == "r")
                deserialize();
            else
                serialize();
        }

        private static void deserialize()
        {
            try
            {
                XmlSerializer sl = new XmlSerializer(typeof(Student));
                FileStream fs = new FileStream("Data.xml", FileMode.Open, FileAccess.Read);
                Student s = (Student)sl.Deserialize(fs);
                Console.WriteLine(s);
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void serialize()
        {
            Student s = new Student();
            Console.WriteLine("Enter the name");
            s.Name = Console.ReadLine();
            Console.WriteLine("Enter the Adress");
            s.Address = Console.ReadLine();
            Console.WriteLine("Enter the Number");
            s.Number = long.Parse(Console.ReadLine());
            FileStream fs = new FileStream("Data.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer sl = new XmlSerializer(typeof(Student));
            sl.Serialize(fs, s);
            fs.Close();
        }
    }
}

