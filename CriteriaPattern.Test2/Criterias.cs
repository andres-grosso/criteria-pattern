using System;
using System.Collections.Generic;
using System.Linq;
using CriteriaPattern.Common;

namespace ConsoleTest
{
    public class MaleCriteria : CompositeCriteriaOOP
    {
        public override List<Person> MeetCriteria(List<Person> entities)
        {
            var males = from m in entities
                        where m.Gender == Gender.Male
                        select m;

            return males.ToList();
        }
    }

    public class FemaleCriteria : CompositeCriteriaOOP
    {
        public override List<Person> MeetCriteria(List<Person> entities)
        {
            var females = from f in entities
                          where f.Gender == Gender.Female
                          select f;

            return females.ToList();
        }
    }

    public class ForeignerCriteria : CompositeCriteriaOOP
    {
        public override List<Person> MeetCriteria(List<Person> entities)
        {
            var people = from p in entities
                         where p.Origin == Origin.Foreigner
                         select p;

            return people.ToList();
        }
    }

    public class SingleCriteria : CompositeCriteriaOOP
    {
        public override List<Person> MeetCriteria(List<Person> entities)
        {
            var people = from p in entities
                         where p.MaritalStatus == MaritalStatus.Single
                         select p;

            return people.ToList();
        }
    }
}
