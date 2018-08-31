using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class GradeYear
    {
        private string deptName;

        public string DeptName
        {
            get { return deptName; }
            set { deptName = value; }
        }

        private int[] propleCount;
        public int[] PeopleCount
        {
            get { return propleCount; }
            set { propleCount = value; }
        }

    }
}
