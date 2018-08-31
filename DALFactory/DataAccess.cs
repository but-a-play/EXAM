using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using SQLServerDAL;
using System.Reflection;

namespace DALFactory
{
    public class DataAccess
    {
        /// <summary>
        /// 数据集名称
        /// </summary>
        private static readonly string AssemblyName = "SQLServerDAL";

        /// <summary>
        /// 创建Roster接口
        /// </summary>
        /// <returns></returns>
        public static IRoster CreateRoster()
        {
            string className = AssemblyName + ".Roster";
            return Assembly.Load(AssemblyName).CreateInstance(className) as IRoster;
        }

        /// <summary>
        /// 创建Seat接口
        /// </summary>
        /// <returns></returns>
        public static ISeat CreateSeat()
        {
            string className = AssemblyName + ".Seat";
            return Assembly.Load(AssemblyName).CreateInstance(className) as ISeat;
        }

        /// <summary>
        /// 创建Grades接口
        /// </summary>
        /// <returns></returns>
        public static IGrades CreateGrades()
        {
            string className = AssemblyName + ".Grades";
            return Assembly.Load(AssemblyName).CreateInstance(className) as IGrades;
        }
    }
}
