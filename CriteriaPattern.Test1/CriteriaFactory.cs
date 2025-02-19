using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CriteriaPattern.Common;

namespace ConsoleTest
{
    public class CriteriaFactory
    {
        public static ICriteria<Person> GetCriteria(CriteriaTypeEnum criteriaType)
        {
            /*
            * If the criteria require contextual information, there are two alternatives:
            * 1. Pass all necessary context information to the specific constructor of the concrete criteria.
            * For example, if there were a criterion that needed to check whether people were associated with a sales department
            * and had an income greater than $50,000 (imagine that the person has a salesDepartmentId attribute),
            * then the SalesDepartmentCriteria should receive a list of sales departments in its constructor,
            * so it can internally determine which ones meet the criteria.
            * 
            * Example:
            * var salesDepartments = Db.GetSalesDepartments();
            * ICriteria<Person> male = new SalesDepartmentCriteria(salesDepartments);
            * and in the concrete implementation of MeetCriteria, it would use this context information to apply the criteria.
            * 
            * 2. Each criterion is responsible for obtaining the context information it needs.
            * 
            * Both approaches have their pros and cons.
            * The first alternative allows for fewer accesses to the data repository being used and even enables sharing
            * context information (perhaps two criteria need the sales departments).
            * The second alternative keeps the code clearer and more decoupled if each criterion retrieves its own
            * required context information, but it involves more database accesses and may lead to duplicate information retrieval.
            */

            // Independent criteria
            ICriteria<Person> male = new MaleCriteria();
            ICriteria<Person> female = new FemaleCriteria();
            ICriteria<Person> single = new SingleCriteria();
            ICriteria<Person> foreigner = new ForeignerCriteria();

            // Nesting criteria using logical operations
            /*
             * It is recommended to use a factory to decouple and centralize the creation of criteria.
             * This also allows, depending on the technology, criteria to be dynamically built at runtime.
             */

            switch (criteriaType)
            {
                case CriteriaTypeEnum.ForeignMales:
                    return male.And(foreigner);
                case CriteriaTypeEnum.SingleForeignMales:
                    return male.And(foreigner).And(single);
                case CriteriaTypeEnum.MaleOrFemale:
                    return male.Or(female);
                case CriteriaTypeEnum.NoFemales:
                    return female.Not();
                default:
                    throw new ArgumentOutOfRangeException("criteriaType");
            }
        }
    }
}
