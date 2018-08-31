using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class GradesInfo
    {
        private string rosterNo;
        /// <summary>
        /// 人员编号   
        /// </summary>
        public string RosterNo
        {
            get { return rosterNo; }
            set { rosterNo = value; }
        }

        private string grade;
        /// <summary>
        /// 成绩
        /// </summary>
        public string Grade
        {
            get { return grade; }
            set { grade = value; }
        }

        private string year;
        /// <summary>
        /// 年份
        /// </summary>
        public string Year
        {
            get { return year; }
            set { year = value; }
        }

    }
}
