using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;

namespace IDAL
{
    public interface IGrades
    {
        /// <summary>
        /// 增加成绩信息
        /// </summary>
        /// <param name="gradesInfo"></param>
        void AddGradesInfo(GradesInfo gradesInfo);
        
        /// <summary>
        /// 获取年份
        /// </summary>
        List<int> GetYears();

        /// <summary>
        /// 某个年度每家单位分数段排行
        /// </summary>
        /// <returns></returns>
        string GetDataByYearJson(string year);

        /// <summary>
        /// 查询某家单位逐年平均分变化情况
        /// </summary>
        /// <returns></returns>
        string GetDataByDepartmentJson(string deptName);
    }
}
