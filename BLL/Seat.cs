using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using DALFactory;
using IDAL;
using System.Collections;
using System.Data;

namespace BLL
{
    public class Seat
    {
        private ISeat sqlSeat = DataAccess.CreateSeat();
        /// <summary>
        /// 增加座位信息
        /// </summary>
        /// <param name="seatList"></param>
        public void AddSeatData(ArrayList seatList, string tabelName)
        {
            foreach (SeatInfo seatInfo in seatList)
            {
                sqlSeat.AddSeatInfo(seatInfo, tabelName);
            }
        }

        /// <summary>
        /// 查询座位信息
        /// </summary>
        /// <param name="paramsMap"></param>
        /// <returns></returns>
        public DataSet QuerySeatData(Dictionary<string, object> paramsMap, string tabelName)
        {
            return sqlSeat.QuerySeatInfo(paramsMap, tabelName);
        }

        /// <summary>
        /// 排位:数组切分+交替插入至新数组
        /// </summary>
        /// <param name="rosterList"></param>
        /// <returns></returns>
        public SeatInfo[] SetSeat(ArrayList rosterList)
        {
            int count = rosterList.Count;
            int mid = count / 2;
            //SeatInfo[] head, back;
            SeatInfo[] newArray = new SeatInfo[count];
            SeatInfo[] resArray = new SeatInfo[count];

            //head = new SeatInfo[mid + count % 2];
            //back = new SeatInfo[mid];

            for (int index = 0; index < newArray.Length; ++index)
            {
                SeatInfo seatInfo = new SeatInfo();
                seatInfo.RosterNo = (rosterList[index] as RosterInfo).Id;
                string examType = (rosterList[index] as RosterInfo).Type;
                if (examType == "A类")
                {
                    seatInfo.ExamNo = "01" + (index + 1).ToString("00000");
                }
                else if (examType == "B类")
                {
                    seatInfo.ExamNo = "02" + (index + 1).ToString("00000");
                }
                else if (examType == "C类")
                {
                    seatInfo.ExamNo = "03" + (index + 1).ToString("00000");
                }
                newArray[index] = seatInfo;
            }

            /*
             *交叉填空
             * 将原序列平分或前一半比后一半多一的两个序列
             * 再将前一半的每一个插入结果序列中的偶数位
             * 将后一半插入剩下的奇数空位
             */
            for (int index = 0; index < newArray.Length; ++index)
            {
                if (index < mid + count % 2)
                {
                    resArray[2 * index] = newArray[index];
                }
                else
                {
                    resArray[1 + 2 * (index - mid - count % 2)] = newArray[index];
                }
            }

            return resArray;

            //for (int index = 0; index < head.Length; ++index)
            //{
            //    SeatInfo seatInfo = new SeatInfo();
            //    seatInfo.RosterNo = (rosterList[index] as RosterInfo).Id;
            //    string examType = (rosterList[index] as RosterInfo).Type;
            //    if (examType == "A类")
            //    {
            //        seatInfo.ExamNo = "01" + (index + 1).ToString("00000");
            //    }
            //    else if (examType == "B类")
            //    {
            //        seatInfo.ExamNo = "02" + (index + 1).ToString("00000");
            //    }
            //    else if (examType == "C类")
            //    {
            //        seatInfo.ExamNo = "03" + (index + 1).ToString("00000");
            //    }

            //    head[index] = seatInfo;
            //}
            //for (int index = 0; index < back.Length; ++index)
            //{
            //    SeatInfo seatInfo = new SeatInfo();
            //    seatInfo.RosterNo = (rosterList[head.Length + index] as RosterInfo).Id;
            //    string examType = (rosterList[head.Length + index] as RosterInfo).Type;
            //    if (examType == "A类")
            //    {
            //        seatInfo.ExamNo = "01" + (head.Length + index + 1).ToString("00000");
            //    }
            //    else if (examType == "B类")
            //    {
            //        seatInfo.ExamNo = "02" + (head.Length + index + 1).ToString("00000");
            //    }
            //    else if (examType == "C类")
            //    {
            //        seatInfo.ExamNo = "03" + (head.Length + index + 1).ToString("00000");
            //    }
            //    back[index] = seatInfo;
            //}
            //for (int index = 0, headIndex = 0, backIndex = 0; headIndex < head.Length || backIndex < back.Length; ++index)
            //{
            //    if (index % 2 == 0)
            //    {
            //        newArray[index] = head[headIndex];
            //        ++headIndex;
            //    }
            //    else
            //    {
            //        newArray[index] = back[backIndex];
            //        ++backIndex;
            //    }
            //}
            //return newArray;

        }


        /// <summary>
        /// 排位：在可选数组中随机抽取一个数据放入待返回数组，
        /// 重新设置可选数组，循环
        /// </summary>
        /// <param name="rosterList"></param>
        /// <returns></returns>
        public SeatInfo[] SetSeat2(ArrayList rosterList)
        {
            int count = rosterList.Count;
            //排位后的数据数组
            SeatInfo[] resArray = new SeatInfo[count];
            //原始数据数组
            SeatInfo[] oldArray = new SeatInfo[count];
            for (int index = 0; index < oldArray.Length; ++index)
            {
                SeatInfo seatInfo = new SeatInfo();
                seatInfo.CanChoose = true;
                seatInfo.IsChoosed = false;
                seatInfo.OldIndex = index;
                seatInfo.RosterNo = (rosterList[index] as RosterInfo).Id;
                string examType = (rosterList[index] as RosterInfo).Type;
                if (examType == "A类")
                {
                    seatInfo.ExamNo = "01" + (index + 1).ToString("00000");
                }
                else if (examType == "B类")
                {
                    seatInfo.ExamNo = "02" + (index + 1).ToString("00000");
                }
                else if (examType == "C类")
                {
                    seatInfo.ExamNo = "03" + (index + 1).ToString("00000");
                }
                oldArray[index] = seatInfo;
            }

            /*
             * 在元素对应的实体中增加两个属性，用于判断是否可以进入下次随机选取的可选序列
             * IsChoosed是元素是否已被选的状态，CanChoose是元素是否可选的状态
             * 每次随机选择一个元素后，其状态IsChoosed=true；CanChoose=false；其相邻的元素（一个或两个）对应的CanChoose=false；
             * 然后生成新的可选序列，生成原则是属性IsChoosed=false&&CanChoose=true的所有元素。在生成后，将原始序列中的各个元素的CanChoose恢复为true（包括第一次选中元素的相邻位）
             * 循环上述操作，直至排位完成
             */
            Random ra = new Random();
            //随机选择某个元素
            SeatInfo[] newArray = GetCanChooseArray(oldArray);
            for (int index = 0; index < resArray.Length; ++index)
            {
                int idx = ra.Next(newArray.Length);
                SeatInfo seatInfo = newArray[idx];
                resArray[index] = seatInfo;
                oldArray[seatInfo.OldIndex].IsChoosed = true;
                oldArray[seatInfo.OldIndex].CanChoose = false;
                if (seatInfo.OldIndex == 0)
                {
                    oldArray[seatInfo.OldIndex + 1].CanChoose = false;
                }
                else if (seatInfo.OldIndex == oldArray.Length - 1)
                {
                    oldArray[seatInfo.OldIndex - 1].CanChoose = false;
                }
                else if (seatInfo.OldIndex > 0 && seatInfo.OldIndex < oldArray.Length - 1)
                {
                    oldArray[seatInfo.OldIndex - 1].CanChoose = false;
                    oldArray[seatInfo.OldIndex + 1].CanChoose = false;
                }
                newArray = GetCanChooseArray(oldArray);
                ReturnCanChoose(oldArray);
            }



            return resArray;
        }

        /// <summary>
        /// 恢复可选状态 CanChoose = true
        /// </summary>
        /// <param name="seats"></param>
        public void ReturnCanChoose(SeatInfo[] seats)
        {
            for (int index = 0; index < seats.Length; ++index)
            {
                seats[index].CanChoose = true;
            }
        }

        /// <summary>
        /// 获取可选数组
        /// </summary>
        /// <param name="oldArray"></param>
        /// <returns></returns>
        public SeatInfo[] GetCanChooseArray(SeatInfo[] oldArray)
        {
            ArrayList newList = new ArrayList();
            //生成新的可选数组
            for (int index = 0; index < oldArray.Length; ++index)
            {
                if (oldArray[index].IsChoosed)
                {
                    continue;
                }
                else
                {
                    if (oldArray[index].CanChoose)
                    {
                        newList.Add(oldArray[index]);
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            object[] objs = newList.ToArray();
            SeatInfo[] seats = new SeatInfo[objs.Length];
            for (int index = 0; index < objs.Length; ++index)
            {
                seats[index] = objs[index] as SeatInfo;
            }
            return seats;
        }



        public SeatInfo[] SetSeat3(ArrayList rosterList)
        {
            int count = rosterList.Count;
            //排位后的数据数组
            SeatInfo[] resArray = new SeatInfo[count];

            //原始数据数组
            SeatInfo[] oldArray = new SeatInfo[count];
            SeatInfo[] newArray;
            for (int index = 0; index < oldArray.Length; ++index)
            {
                SeatInfo seatInfo = new SeatInfo();

                seatInfo.RosterNo = (rosterList[index] as RosterInfo).Id;
                string examType = (rosterList[index] as RosterInfo).Type;
                if (examType == "A类")
                {
                    seatInfo.ExamNo = "01" + (index + 1).ToString("00000");
                }
                else if (examType == "B类")
                {
                    seatInfo.ExamNo = "02" + (index + 1).ToString("00000");
                }
                else if (examType == "C类")
                {
                    seatInfo.ExamNo = "03" + (index + 1).ToString("00000");
                }
                oldArray[index] = seatInfo;
            }

            newArray = oldArray;

            Random ra = new Random();
            ArrayList head = new ArrayList();
            ArrayList mid = new ArrayList();
            ArrayList back = new ArrayList();

            while(newArray.Length != 0)
            {
                int nullCount = 0;
                int midIndex = ra.Next(newArray.Length);
                int headIndex = midIndex - 1;
                int backIndex = midIndex + 1;
                mid.Add(newArray[midIndex]);
                newArray[midIndex] = null;
                ++nullCount;
                if (headIndex >= 0 && headIndex < newArray.Length - 1)
                {
                    head.Add(newArray[headIndex]);
                    newArray[headIndex] = null;
                    ++nullCount;
                }
                if (backIndex >= 1 && backIndex <= newArray.Length - 1)
                {
                    back.Add(newArray[backIndex]);
                    newArray[backIndex] = null;
                    ++nullCount;
                }
                newArray = GetNewSeat(newArray, nullCount);
            }
            for(int index = 0; index < head.Count; ++index)
            {
                resArray[index] = head[index] as SeatInfo;
            }
            for(int index = 0; index < mid.Count; ++index)
            {
                resArray[head.Count + index] = mid[index] as SeatInfo;
            }
            for(int index = 0; index < back.Count; ++index)
            {
                resArray[head.Count + mid.Count + index] = back[index] as SeatInfo;
            }
            return resArray;
        }

        public SeatInfo[] GetNewSeat(SeatInfo[] oldArray, int nullCount)
        {
            SeatInfo[] newArray = new SeatInfo[oldArray.Length - nullCount];
            if(newArray.Length > 0)
            {
                for (int index = 0, newIndex = 0; index < oldArray.Length && newIndex < newArray.Length; ++index, ++newIndex)
                {
                    if (oldArray[index] == null)
                    {
                        index = index + nullCount;
                    }
                    newArray[newIndex] = oldArray[index];
                }
            }
            

            return newArray;
        }
    }
}
