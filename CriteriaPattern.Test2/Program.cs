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

            ICriteriaOOP criteria = null;

            /* ---------- FOREIGN SINGLE MEN ---------- */
            criteria = CriteriaFactory.GetCriteria(CriteriaTypeEnum.SingleForeignMales);

            Console.WriteLine("NOW FOREIGN, MALE, AND SINGLE PEOPLE SHOULD APPEAR");

            foreach (var person in criteria.MeetCriteria(people))
                Console.WriteLine(person.Description);

            Console.ReadLine();
            Console.Clear();

            /* ---------- FOREIGN MEN ---------- */
            criteria = CriteriaFactory.GetCriteria(CriteriaTypeEnum.ForeignMales);

            Console.WriteLine("NOW FOREIGN AND MALE PEOPLE SHOULD APPEAR");

            foreach (var person in criteria.MeetCriteria(people))
                Console.WriteLine(person.Description);

            Console.ReadLine();
            Console.Clear();

            /* ---------- MEN OR WOMEN ---------- */
            criteria = CriteriaFactory.GetCriteria(CriteriaTypeEnum.MaleOrFemale);

            Console.WriteLine("NOW MEN OR WOMEN SHOULD APPEAR");

            foreach (var person in criteria.MeetCriteria(people))
                Console.WriteLine(person.Description);

            Console.ReadLine();
            Console.Clear();

            /* ---------- NOT WOMEN ---------- */
            criteria = CriteriaFactory.GetCriteria(CriteriaTypeEnum.NoFemales);

            Console.WriteLine("NOW NON-WOMEN SHOULD APPEAR");

            foreach (var person in criteria.MeetCriteria(people))
                Console.WriteLine(person.Description);

            Console.ReadLine();
            Console.Clear();

            /* ---------- EXAMPLE WITHOUT FACTORY ---------- */
            ICriteriaOOP male = new MaleCriteria();
            ICriteriaOOP female = new FemaleCriteria();
            ICriteriaOOP single = new SingleCriteria();
            ICriteriaOOP foreign = new ForeignerCriteria();

            Console.WriteLine("NOW SINGLE AND MARRIED PEOPLE SHOULD APPEAR (WHICH MEANS NO ONE)");
            /* ---------- SINGLE AND MARRIED ---------- */
            criteria = single.And(single.Not());

            foreach (var person in criteria.MeetCriteria(people))
                Console.WriteLine(person.Description);

            Console.ReadLine();
            Console.Clear();
        }
    }
}