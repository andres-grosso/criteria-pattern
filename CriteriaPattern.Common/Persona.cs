using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CriteriaPattern.Common
{
    public class Person
    {
        public int Age { get; set; }

        public string FirstName { get; set; }

        public string Description { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public Origin Origin { get; set; }

        public MaritalStatus MaritalStatus { get; set; }

        public Profession Profession { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }

    public enum Origin
    {
        Argentine,
        Foreigner
    }

    public enum MaritalStatus
    {
        Single,
        Married
    }

    public enum Profession
    {
        Engineer,
        Doctor,
        Lawyer,
        Psychologist
    }
}
