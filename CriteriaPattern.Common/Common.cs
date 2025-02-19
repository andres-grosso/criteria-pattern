using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CriteriaPattern.Common
{
    public static class Common
    {
        public static List<Person> FillTestPeople()
        {
            var people = new List<Person>();

            // Foreign single males
            for (int i = 0; i < 5; i++)
            {
                var person = new Person();

                person.Gender = Gender.Male;
                person.MaritalStatus = MaritalStatus.Single;
                person.Origin = Origin.Foreigner;
                person.FirstName = string.Format("First Name {0}", i.ToString());
                person.LastName = string.Format("Last Name {0}", i.ToString());
                person.Description = string.Format("Foreign single males no. {0}", i.ToString());

                people.Add(person);
            }

            // Married Argentine women
            for (int i = 6; i < 11; i++)
            {
                var person = new Person();

                person.Gender = Gender.Female;
                person.MaritalStatus = MaritalStatus.Married;
                person.Origin = Origin.Argentine;
                person.FirstName = string.Format("First Name {0}", i.ToString());
                person.LastName = string.Format("Last Name {0}", i.ToString());
                person.Description = string.Format("Married Argentine women no. {0}", i.ToString());

                people.Add(person);
            }

            // Foreign married males
            for (int i = 11; i < 16; i++)
            {
                var person = new Person();

                person.Gender = Gender.Male;
                person.MaritalStatus = MaritalStatus.Married;
                person.Origin = Origin.Foreigner;
                person.FirstName = string.Format("First Name {0}", i.ToString());
                person.LastName = string.Format("Last Name {0}", i.ToString());
                person.Description = string.Format("Foreign married males no. {0}", i.ToString());

                people.Add(person);
            }

            return people;
        }
    }
}
