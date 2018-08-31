using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MODEL;
using System.Collections;
using BLL;

namespace EXAM
{
    public partial class DataInsert : System.Web.UI.Page
    {
        private Roster rosterService = new Roster();
        private Grades gradesService = new Grades();

        /// <summary>
        /// 随机姓名，性别，身份证号码的随机生成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            for(int year = 2010; year <= 2018; ++year)
            {
                AddGrades(year);
            }
        }

        private void AddRoster()
        {
            string[] firstName = { "赵", "钱", "孙", "李", "周", "吴", "郑", "王", "冯", "陈" };
            string[] lastName = { "尹", "沛", "雯", "梅", "寒", "凝", "典", "秋", "蝶", "慧" };
            ArrayList rosterList = new ArrayList();
            Random ra = new Random();
            for (int x = 0; x < 10; ++x)
            {
                for (int y = 0; y < 10; ++y)
                {
                    RosterInfo roster = new RosterInfo();
                    roster.Name = "" + firstName.GetValue(x) + lastName.GetValue(y);
                    if (y % 2 == 0)
                    {
                        roster.Sex = true;
                    }
                    else
                    {
                        roster.Sex = false;
                    }
                    roster.IdentityNo = "" + ra.Next(1, 10);
                    for (int z = 1; z < 18; ++z)
                    {
                        roster.IdentityNo += ra.Next(10);
                    }
                    rosterList.Add(roster);
                }
            }
            rosterService.AddRosterData(rosterList);
        }

        private void AddGrades(int year)
        {
            ArrayList gradesList = new ArrayList();
            Random ra = new Random();
            for (int index = 0; index < 100; ++index)
            {
                GradesInfo grades = new GradesInfo();
                grades.RosterNo = Convert.ToString(index + 1);
                grades.Year = Convert.ToString(year);
                grades.Grade = Convert.ToString(ra.Next(101));
                gradesList.Add(grades);
            }
            gradesService.AddGradesData(gradesList);

        }
    }
}