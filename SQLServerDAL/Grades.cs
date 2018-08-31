using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using MODEL;
using System.Data.SqlClient;
using DBUtil;
using System.Data;
using Newtonsoft.Json;

namespace SQLServerDAL
{
    public class Grades : IGrades
    {
        /// <summary>
        /// 增加成绩信息
        /// </summary>
        /// <param name="gradesInfo"></param>
        public void AddGradesInfo(GradesInfo gradesInfo)
        {
            string connStr = SqlHelper.GetConnString();
            string sqlText = "INSERT INTO Grades (RosterNo, Grade, Year) VALUES (@RosterNo, @Grade, @Year)";
            SqlParameter[] sqlParas = new SqlParameter[]
            {
                new SqlParameter("@RosterNo", gradesInfo.RosterNo),
                new SqlParameter("@Grade", gradesInfo.Grade),
                new SqlParameter("@Year", gradesInfo.Year)
            };

            SqlHelper.ExecuteNonQuery(connStr, CommandType.Text, sqlText, sqlParas);
        }

        /// <summary>
        /// 获取年份
        /// </summary>
        /// <returns></returns>
        public List<int> GetYears()
        {
            string connStr = SqlHelper.GetConnString();
            string sqlText = "SELECT DISTINCT Year FROM Grades ORDER BY Year";
            DataSet ds = SqlHelper.ExecuteDataset(connStr, CommandType.Text, sqlText);
            List<int> yearList = new List<int>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                yearList.Add(Convert.ToInt32(dr[0]));
            }
            return yearList;
        }

        /// <summary>
        /// 某个年度每家单位分数段排行
        /// </summary>
        /// <returns></returns>
        public string GetDataByYearJson(string year)
        {
            string connStr = SqlHelper.GetConnString();
            string sqlText = "SELECT Department, COUNT(CASE WHEN Grade BETWEEN 90 AND 100 THEN 1 END) AS [90-100分],COUNT(CASE WHEN Grade BETWEEN 70 AND 89 THEN 1 END) AS [70-89分],COUNT(CASE WHEN Grade BETWEEN 60 AND 69 THEN 1 END) AS [60-69分],COUNT(CASE WHEN Grade < 60 THEN 1 END ) AS [0-59分] FROM Grades INNER JOIN Roster ON Grades.RosterNo = Roster.Id WHERE Year = @Year GROUP BY Department";
            SqlParameter[] sqlParas = new SqlParameter[]
           {
                new SqlParameter("@Year", year)
           };
            DataSet ds = SqlHelper.ExecuteDataset(connStr, CommandType.Text, sqlText, sqlParas);
            DataTable dt = ds.Tables[0];
            string dataJson = "";
            GradeYear[] peopleCount = new GradeYear[dt.Rows.Count];
            for (int index = 0; index < dt.Rows.Count; ++index)
            {
                GradeYear count = new GradeYear();
                count.DeptName = Convert.ToString(dt.Rows[index]["Department"]).Trim();
                int grade90to100 = Convert.ToInt32(dt.Rows[index]["90-100分"]);
                int grade70to89 = Convert.ToInt32(dt.Rows[index]["70-89分"]);
                int grade60to69 = Convert.ToInt32(dt.Rows[index]["60-69分"]);
                int grade0to59 = Convert.ToInt32(dt.Rows[index]["0-59分"]);
                count.PeopleCount = new int[]{ grade90to100, grade70to89, grade60to69, grade0to59};
                peopleCount[index] = count;
            }
            dataJson = JsonConvert.SerializeObject(peopleCount);
            return dataJson;
        }

        /// <summary>
        /// 查询某家单位逐年平均分变化情况
        /// </summary>
        /// <returns></returns>
        public string GetDataByDepartmentJson(string deptName)
        {
            string connStr = SqlHelper.GetConnString();
            string sqlText = "SELECT YEAR, AVG(Grade) AS [平均分] FROM Grades INNER JOIN Roster ON Grades.RosterNo = Roster.Id WHERE Department = @Department GROUP BY Year";
            SqlParameter[] sqlParas = new SqlParameter[]
           {
                new SqlParameter("@Department", deptName)
           };
            DataSet ds = SqlHelper.ExecuteDataset(connStr, CommandType.Text, sqlText, sqlParas);
            DataTable dt = ds.Tables[0];
            string dataJson = "";
            int[] grades = new int[dt.Rows.Count];
            for (int index = 0; index < dt.Rows.Count; ++index)
            {
                int gradeInThisYear = Convert.ToInt32(dt.Rows[index]["平均分"]);
                grades[index] = gradeInThisYear;
            }
            GradeDept gradeDept = new GradeDept();
            gradeDept.Grades = grades;
            dataJson = JsonConvert.SerializeObject(gradeDept);
            return dataJson;
        }
    }
}
