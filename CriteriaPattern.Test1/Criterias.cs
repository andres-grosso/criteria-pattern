using System;
using System.Collections.Generic;
using System.Linq;
using CriteriaPattern.Common;

namespace ConsoleTest
{
    public class MaleCriteria : ICriteria<Person>
    {
        public List<Person> MeetCriteria(List<Person> entities)
        {
            var males = from m in entities
                        where m.Gender == Gender.Male
                        select m;

            return males.ToList();
        }
    }

    public class FemaleCriteria : ICriteria<Person>
    {
        public List<Person> MeetCriteria(List<Person> entities)
        {
            var females = from f in entities
                          where f.Gender == Gender.Female
                          select f;

            return females.ToList();
        }
    }

    public class ForeignerCriteria : ICriteria<Person>
    {
        public List<Person> MeetCriteria(List<Person> entities)
        {
            var persons = from p in entities
                          where p.Origin == Origin.Foreigner
                          select p;

            return persons.ToList();
        }
    }

    public class SingleCriteria : ICriteria<Person>
    {
        public List<Person> MeetCriteria(List<Person> entities)
        {
            var persons = from p in entities
                          where p.MaritalStatus == MaritalStatus.Single
                          select p;

            return persons.ToList();
        }
    }
}
