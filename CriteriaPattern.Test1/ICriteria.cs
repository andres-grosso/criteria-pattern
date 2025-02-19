using System.Collections.Generic;

namespace ConsoleTest
{
    public interface ICriteria<E>
    {
        List<E> MeetCriteria(List<E> entities);
    }

    internal class AndCriteria<E> : ICriteria<E>
    {
        private ICriteria<E> _criteria;
        private ICriteria<E> _otherCriteria;

        internal AndCriteria(ICriteria<E> criteria, ICriteria<E> otherCriteria)
        {
            _criteria = criteria;
            _otherCriteria = otherCriteria;
        }

        public List<E> MeetCriteria(List<E> entities)
        {
            var result = _criteria.MeetCriteria(entities);

            // Si ya devuelve uno, no ejecuta los 'ands' anidados
            if (result.Count == 1)
                return result;

            return _otherCriteria.MeetCriteria(result);
        }
    }

    internal class OrCriteria<E> : ICriteria<E>
    {
        private ICriteria<E> _criteria;
        private ICriteria<E> _otherCriteria;

        internal OrCriteria(ICriteria<E> criteria, ICriteria<E> otherCriteria)
        {
            _criteria = criteria;
            _otherCriteria = otherCriteria;
        }

        public List<E> MeetCriteria(List<E> entities)
        {
            List<E> firstCriteriaItems = _criteria.MeetCriteria(entities);
            List<E> otherCriteriaItems = _otherCriteria.MeetCriteria(entities);

            foreach (E otherCriteriaItem in otherCriteriaItems)
            {
                if(!firstCriteriaItems.Contains(otherCriteriaItem))
                    firstCriteriaItems.Add(otherCriteriaItem);
            }

            return firstCriteriaItems;
        }
    }

    internal class NotCriteria<E> : ICriteria<E>
    {
        private ICriteria<E> Wrapped;

        internal NotCriteria(ICriteria<E> x)
        {
            Wrapped = x;
        }

        public List<E> MeetCriteria(List<E> entities)
        {
            List<E> notCriteriaItems = Wrapped.MeetCriteria(entities);

            foreach (E notCriteriaItem in notCriteriaItems)
                entities.Remove(notCriteriaItem);
            
            return entities;
        }
    }

    public static class CriteriaExtensionMethods
    {
        public static ICriteria<E> And<E>(this ICriteria<E> criteria, ICriteria<E> otherCriteria)
        {
            return new AndCriteria<E>(criteria, otherCriteria);
        }

        public static ICriteria<E> Or<E>(this ICriteria<E> criteria, ICriteria<E> otherCriteria)
        {
            return new OrCriteria<E>(criteria, otherCriteria);
        }

        public static ICriteria<E> Not<E>(this ICriteria<E> criteria)
        {
            return new NotCriteria<E>(criteria);
        }
    }

}
