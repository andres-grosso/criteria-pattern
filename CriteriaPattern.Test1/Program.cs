using System;
using System.Collections.Generic;
using CriteriaPattern.Common;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = Common.FillTestPeople();

            ICriteria<Person> criteria = null;

            /* ---------- FOREIGN SINGLE MALES ---------- */
            criteria = CriteriaFactory.GetCriteria(CriteriaTypeEnum.SingleForeignMales);

            Console.WriteLine("NOW, FOREIGN, MALE, AND SINGLE PEOPLE SHOULD APPEAR");

            foreach (var person in criteria.MeetCriteria(people))
                Console.WriteLine(person.Description);


            Console.ReadLine();
            Console.Clear();

            /* ---------- FOREIGN MALES ---------- */
            criteria = CriteriaFactory.GetCriteria(CriteriaTypeEnum.ForeignMales);

            Console.WriteLine("NOW, FOREIGN AND MALE PEOPLE SHOULD APPEAR");

            foreach (var person in criteria.MeetCriteria(people))
                Console.WriteLine(person.Description);


            Console.ReadLine();
            Console.Clear();

            /* ---------- MEN OR WOMEN ---------- */
            criteria = CriteriaFactory.GetCriteria(CriteriaTypeEnum.MaleOrFemale);

            Console.WriteLine("NOW, MEN OR WOMEN SHOULD APPEAR");

            foreach (var person in criteria.MeetCriteria(people))
                Console.WriteLine(person.Description);


            Console.ReadLine();
            Console.Clear();

            /* ---------- NOT WOMEN ---------- */
            criteria = CriteriaFactory.GetCriteria(CriteriaTypeEnum.NoFemales);

            Console.WriteLine("NOW, EVERYONE EXCEPT WOMEN SHOULD APPEAR");

            foreach (var person in criteria.MeetCriteria(people))
                Console.WriteLine(person.Description);


            Console.ReadLine();
            Console.Clear();

            /* ---------- EXAMPLE WITHOUT FACTORY ---------- */
            ICriteria<Person> male = new MaleCriteria();
            ICriteria<Person> female = new FemaleCriteria();
            ICriteria<Person> single = new SingleCriteria();
            ICriteria<Person> foreign = new ForeignerCriteria();

            Console.WriteLine("NOW, SINGLE AND MARRIED PEOPLE SHOULD APPEAR (THAT IS, NO ONE)");
            /* ---------- SINGLE AND MARRIED ---------- */
            criteria = single.And(single.Not());

            foreach (var person in criteria.MeetCriteria(people))
                Console.WriteLine(person.Description);

            Console.ReadLine();
            Console.Clear();
        }
    }
}
