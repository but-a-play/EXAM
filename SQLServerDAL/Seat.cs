using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using MODEL;
using DBUtil;
using System.Data.SqlClient;

namespace SQLServerDAL
{
    public class Seat : ISeat
    {
        public void AddSeatInfo(SeatInfo seatInfo, string tableName)
        {
            string connStr = SqlHelper.GetConnString();
            string sqlText = "INSERT INTO "+tableName+" (room, seatNo, examNo, rosterNo) VALUES (@Room, @SeatNo, @ExamNo, @RosterNo)";
            SqlParameter[] sqlParas = new SqlParameter[]
            {
                new SqlParameter("@Room", seatInfo.Room),
                new SqlParameter("@SeatNo", seatInfo.SeatNo),
                new SqlParameter("@ExamNo", seatInfo.ExamNo),
                new SqlParameter("@RosterNo", seatInfo.RosterNo)
            };

            SqlHelper.ExecuteNonQuery(connStr, CommandType.Text, sqlText, sqlParas);
        }

        public DataSet QuerySeatInfo(Dictionary<string, object> paramsMap, string tabelName)
        {
            string connStr = SqlHelper.GetConnString();
            string sqlText = "SELECT "+tabelName+".id, "+ tabelName + ".room, "+ tabelName + ".seatNo, "+ tabelName + ".examNo, Roster.name, Roster.identityNo, Roster.type, Roster.department FROM Roster INNER JOIN "+ tabelName + " ON Roster.id = "+ tabelName +".rosterNo";
            SqlParameter[] sqlParas = null;
            if (paramsMap != null && paramsMap.Count != 0)
            {
                sqlText += " WHERE ";
                int index = 0;
                sqlParas = new SqlParameter[paramsMap.Count];
                foreach (KeyValuePair<string, object> kvPair in paramsMap)
                {
                    string[] keys = kvPair.Key.Split('.');
                    string key = keys[keys.Length - 1];
                    sqlText += (kvPair.Key + " = @" + key);

                    if (index != paramsMap.Count - 1)
                    {
                        sqlText += " and ";
                    }
                    sqlParas[index] = new SqlParameter("@" + key, kvPair.Value);
                    index++;
                }
            }

            return SqlHelper.ExecuteDataset(connStr, CommandType.Text, sqlText, sqlParas);
        }
    }
}
