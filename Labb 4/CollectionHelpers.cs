using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab_4_OOP
{
    class EnterpriseByEmployeesComparer : IComparer<Enterprise>
    {
        public int Compare(Enterprise x, Enterprise y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            return x.GetEmployees().CompareTo(y.GetEmployees());
        }
    }

    class EnterpriseByRatingComparer : IComparer<Enterprise>
    {
        public int Compare(Enterprise x, Enterprise y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            return x.Rating.CompareTo(y.Rating);
        }
    }

    class EnterpriseCollection : IEnumerable<Enterprise>
    {
        private List<Enterprise> enterprises = new List<Enterprise>();

        public void Add(Enterprise enterprise)
        {
            enterprises.Add(enterprise);
        }

        public IEnumerator<Enterprise> GetEnumerator()
        {
            return enterprises.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}