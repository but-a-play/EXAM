using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using IDAL;
using DALFactory;
using System.Collections;

namespace BLL
{
    public class Grades
    {
        private IGrades sqlGrades = DataAccess.CreateGrades();

        public void AddGradesData(ArrayList gradesList)
        {
            foreach (GradesInfo gradesInfo in gradesList)
            {
                sqlGrades.AddGradesInfo(gradesInfo);
            }
        }

        public List<int> GetYears()
        {
            return sqlGrades.GetYears();
        }

        public string GetDataByYearJson(string year)
        {
            return sqlGrades.GetDataByYearJson(year);
        }

        public string GetDataByDeptJson(string deptName)
        {
            return sqlGrades.GetDataByDepartmentJson(deptName);
        }
    }
}
