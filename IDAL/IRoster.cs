using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace IDAL
{
    public interface IRoster
    {
        /// <summary>
        /// 增加考生信息
        /// </summary>
        /// <param name="rosterInfo"></param>
        void AddRosterInfo(RosterInfo rosterInfo);

        /// <summary>
        /// 查询考生信息
        /// </summary>
        /// <param name="paramsMap"></param>
        /// <returns></returns>
        DataSet QueryRosterInfo(Dictionary<string, object> paramsMap, string tableName);

        /// <summary>
        /// 获取单位集合
        /// </summary>
        /// <returns></returns>
        List<string> GetDepartments();

        /// <summary>
        /// 获取某类型考试人集合
        /// </summary>
        /// <param name="examType"></param>
        /// <returns></returns>
        ArrayList GetRosterInfoByExamType(string examType);

        /// <summary>
        /// 获取考生信息，按照编号排序
        /// </summary>
        /// <param name="paramsMap"></param>
        /// <returns></returns>
        DataSet QueryRosterOrder(Dictionary<string, object> paramsMap, string tableName);
    }
}
