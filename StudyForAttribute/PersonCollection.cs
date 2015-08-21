using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudyForAttribute
{
   public class PersonCollection:IEnumerable
    {
        public ArrayList Persons = new ArrayList();
        //为调用者进行转换
        public Person GetPerson(int pos)
        {
            return (Person)Persons[pos];
        }

        //只插入Person对象

        public void AddPerson(Person p)
        {
            Persons.Add(p);
        }

        public void ClearPerson()
        {
            Persons.Clear();
        }

       public IEnumerator GetEnumerator()
        {
            return Persons.GetEnumerator();
        }
    }
}
