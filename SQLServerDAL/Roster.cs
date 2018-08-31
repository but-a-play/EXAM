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
using System.Collections;

namespace SQLServerDAL
{
    public class Roster : IRoster
    {
        public void AddRosterInfo(RosterInfo rosterInfo)
        {
            string connStr = SqlHelper.GetConnString();
            string sqlText = "INSERT INTO Roster (name, sex, identityNo, type, department) VALUES (@Name, @Sex, @IdentityNo, @Type, @Department)";
            SqlParameter[] sqlParas = new SqlParameter[]
            {
                new SqlParameter("@Name", rosterInfo.Name),
                new SqlParameter("@Sex", rosterInfo.Sex),
                new SqlParameter("@IdentityNo", rosterInfo.IdentityNo),
                new SqlParameter("@Type", rosterInfo.Type),
                new SqlParameter("@Department", rosterInfo.Department)
            };

            SqlHelper.ExecuteNonQuery(connStr, CommandType.Text, sqlText, sqlParas);
        }

        public DataSet QueryRosterInfo(Dictionary<string, object> paramsMap, string tableName)
        {
            string connStr = SqlHelper.GetConnString();
            string sqlText = "SELECT "+ tableName + ".id, Roster.name, Roster.sex, " + tableName + ".room, " + tableName + ".seatNo, " + tableName + ".examNo, Roster.identityNo, Roster.examType, Roster.department FROM Roster INNER JOIN " + tableName + " ON Roster.id = " + tableName + ".rosterNo";
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

        public DataSet QueryRosterOrder(Dictionary<string, object> paramsMap, string tableName)
        {
            string connStr = SqlHelper.GetConnString();
            string sqlText = "SELECT Roster.id, Roster.name, Roster.sex, " + tableName + ".room, " + tableName + ".seatNo, " + tableName + ".examNo, Roster.identityNo, Roster.examType, Roster.department FROM Roster INNER JOIN " + tableName + " ON Roster.id = " + tableName + ".rosterNo ORDER BY Roster.id";
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

        public ArrayList GetRosterInfoByExamType(string examType)
        {
            string connStr = SqlHelper.GetConnString();
            string sqlText = "SELECT * FROM Roster WHERE examType = @ExamType";
            SqlParameter[] sqlParas = new SqlParameter[1];
            sqlParas[0] = new SqlParameter("@ExamType", examType);
            ArrayList idRowList = SqlHelper.ExecuteArrayList(connStr, CommandType.Text, sqlText, sqlParas);
            ArrayList idList = new ArrayList();
            foreach (DataRow r in idRowList)
            {
                RosterInfo rosterInfo = new RosterInfo();
                rosterInfo.Id = (int)r["id"];
                rosterInfo.IdentityNo = r["identityNo"].ToString();
                rosterInfo.Name = r["name"].ToString();
                rosterInfo.Type = r["examType"].ToString();
                rosterInfo.Department = r["department"].ToString();
                rosterInfo.Sex = bool.Parse(r["sex"].ToString());
                idList.Add(rosterInfo);
            }
            return idList;
        }


        public List<string> GetDepartments()
        {
            string connStr = SqlHelper.GetConnString();
            string sqlText = "SELECT DISTINCT Department FROM Roster";
            DataSet ds = SqlHelper.ExecuteDataset(connStr, CommandType.Text, sqlText);
            List<string> departmentList = new List<string>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                departmentList.Add(Convert.ToString(dr[0]));
            }
            return departmentList;
        }
    }

}
