using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using DALFactory;
using System.Collections;
using MODEL;
using System.Data;

namespace BLL
{
    public class Roster
    {
        private IRoster sqlRoster = DataAccess.CreateRoster();

        /// <summary>
        /// 增加考生名单信息
        /// </summary>
        /// <param name="rosterList"></param>
        public void AddRosterData(ArrayList rosterList)
        {
            foreach (RosterInfo rosterInfo in rosterList)
            {
                sqlRoster.AddRosterInfo(rosterInfo);
            }
        }

        /// <summary>
        /// 获取单位集合
        /// </summary>
        /// <returns></returns>
        public List<string> GetDepartments()
        {
            return sqlRoster.GetDepartments();
        }

        /// <summary>
        /// 查询考生名单信息
        /// </summary>
        /// <param name="paramsMap"></param>
        /// <returns></returns>
        public DataSet QueryRosterData(Dictionary<string, object> paramsMap, string tableName)
        {
            return sqlRoster.QueryRosterInfo(paramsMap, tableName);
        }

        public ArrayList GetRosterInfoByExamType(string examType)
        {
            if (examType != "A类" && examType != "B类" && examType != "C类")
            {
                return null;
            }
            else
            {
                return sqlRoster.GetRosterInfoByExamType(examType);
            }
                
        }

        /// <summary>
        /// 获取考生信息，按照编号排序
        /// </summary>
        /// <param name="paramsMap"></param>
        /// <returns></returns>
        public DataSet QueryRosterOrder(Dictionary<string, object> paramsMap, string tableName)
        {
            return sqlRoster.QueryRosterOrder(paramsMap, tableName);
        }
    }
}
