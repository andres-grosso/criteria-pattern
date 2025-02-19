using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CriteriaPattern.Common;

namespace ConsoleTest
{
    public class CriteriaFactory
    {
        public static ICriteriaOOP GetCriteria(CriteriaTypeEnum criteriaType)
        {
            /*
            * If the criteria require contextual information, there are two alternatives:
            * 1. The specific criteria receive all the required contextual information through a specific constructor.
            * For example, if there were a criterion that needed to check whether people were associated 
            * with a sales department and had an income greater than $50,000 
            * (imagine the person has an attribute idSalesDepartment),
            * the SalesDepartmentCriteria should receive a list of sales departments through its constructor,
            * so it can internally check which ones meet the criteria.
            * 
            * Example:
            * var salesDepartments = Db.GetSalesDepartments();
            * ICriteria<Person> male = new SalesDepartmentCriteria(salesDepartments);
            * In the concrete implementation of MeetCriteria, it would use this contextual information 
            * to apply the criterion.
            * 
            * 2. Each criterion is responsible for obtaining the contextual information it needs.
            * 
            * Both approaches have advantages and disadvantages.
            * The first alternative minimizes access to the data repository and allows sharing 
            * contextual information (perhaps two criteria need the sales departments).
            * The second alternative results in clearer and more decoupled code since each criterion 
            * fetches its own contextual data. However, it increases database access and may redundantly 
            * fetch shared information.
            */
            // Independent criteria
            ICriteriaOOP male = new MaleCriteria();
            ICriteriaOOP female = new FemaleCriteria();
            ICriteriaOOP single = new SingleCriteria();
            ICriteriaOOP foreigner = new ForeignerCriteria();

            // Nesting criteria using logical operations
            /*
             * It is recommended to use a factory to decouple and centralize the creation of criteria.
             * This also allows dynamically creating criteria at runtime depending on the technology.
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
                    throw new ArgumentOutOfRangeException(nameof(criteriaType));
            }
        }
    }
}
