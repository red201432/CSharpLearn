using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace Threading
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person()
        {
            this.Name = Name;
            this.Age = Age;
        }
    }
    class Message
    {
        Person person = new Person();
        public Person getPerson(string name,int age)
        {
            person.Name = name;
            person.Age = age;
            return person;
        }
        public void ShowPerson()
        {
            if (person != null)
            {
                 Person _person = (Person)person;
                string message = string.Format("\n{0}'s age is {1}!\nAsync threadId is:{2}",_person.Name, _person.Age, Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine(message);
            }
            for (int n = 0; n < 10; n++)
            {
                Thread.Sleep(300);
                Console.WriteLine("The number is:" + n.ToString());
            }

            }
        

        public void ShowMessage()
        {
            string message = string.Format("Asyn threadIs is :{0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine(message);

            for (int i = 0; i < 20; i++)
            {
                Thread.Sleep(300);
                Console.WriteLine("The number is:" + i.ToString());
            }
        }
    }
}
