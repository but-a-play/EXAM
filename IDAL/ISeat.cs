using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using System.Data;

namespace IDAL
{
    public interface ISeat
    {
        /// <summary>
        /// 增加考生座位信息
        /// </summary>
        /// <param name="seatInfo"></param>
        void AddSeatInfo(SeatInfo seatInfo, string tableName);

        /// <summary>
        /// 查询考生座位信息
        /// </summary>
        /// <param name="paramsMap"></param>
        /// <returns></returns>
        DataSet QuerySeatInfo(Dictionary<string, object> paramsMap, string tableName);

    }
}
