using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CriteriaPattern.Common;

namespace ConsoleTest
{
    public interface ICriteriaOOP
    {
        List<Person> MeetCriteria(List<Person> entities);

        ICriteriaOOP And(ICriteriaOOP other);

        ICriteriaOOP Or(ICriteriaOOP other);

        ICriteriaOOP Not();
    }

    public abstract class CompositeCriteriaOOP : ICriteriaOOP
    {
        public abstract List<Person> MeetCriteria(List<Person> entities);

        public ICriteriaOOP And(ICriteriaOOP other)
        {
            return new AndCriteriaOOP(this, other);
        }

        public ICriteriaOOP Or(ICriteriaOOP other)
        {
            return new OrCriteriaOOP(this, other);
        }

        public ICriteriaOOP Not()
        {
            return new NotCriteriaOOP(this);
        }
    }

    public class AndCriteriaOOP : CompositeCriteriaOOP
    {
        private ICriteriaOOP _criteria;
        private ICriteriaOOP _otherCriteria;

        public AndCriteriaOOP(ICriteriaOOP x, ICriteriaOOP y)
        {
            _criteria = x;
            _otherCriteria = y;
        }

        public override List<Person> MeetCriteria(List<Person> entities)
        {
            var result = _criteria.MeetCriteria(entities);

            // If it already returns one, it does not execute nested 'ands'
            if (result.Count == 1)
                return result;

            return _otherCriteria.MeetCriteria(result);
        }
    }

    public class OrCriteriaOOP : CompositeCriteriaOOP
    {
        private ICriteriaOOP _criteria;
        private ICriteriaOOP _otherCriteria;

        public OrCriteriaOOP(ICriteriaOOP x, ICriteriaOOP y)
        {
            _criteria = x;
            _otherCriteria = y;
        }

        public override List<Person> MeetCriteria(List<Person> entities)
        {
            List<Person> firstCriteriaItems = _criteria.MeetCriteria(entities);
            List<Person> otherCriteriaItems = _otherCriteria.MeetCriteria(entities);

            foreach (Person otherCriteriaItem in otherCriteriaItems)
            {
                if (!firstCriteriaItems.Contains(otherCriteriaItem))
                    firstCriteriaItems.Add(otherCriteriaItem);
            }

            return firstCriteriaItems;
        }
    }

    public class NotCriteriaOOP : CompositeCriteriaOOP
    {
        private ICriteriaOOP Wrapped;

        public NotCriteriaOOP(ICriteriaOOP x)
        {
            Wrapped = x;
        }

        public override List<Person> MeetCriteria(List<Person> entities)
        {
            List<Person> notCriteriaItems = Wrapped.MeetCriteria(entities);

            foreach (Person notCriteriaItem in notCriteriaItems)
                entities.Remove(notCriteriaItem);

            return entities;
        }
    }
}