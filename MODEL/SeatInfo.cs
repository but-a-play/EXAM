using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class SeatInfo
    {
        private int id;
        /// <summary>
        /// 座位表主键id
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string room;
        /// <summary>
        /// 教室号
        /// </summary>
        public string Room
        {
            get { return room; }
            set { room = value; }
        }

        private int seatNo;
        /// <summary>
        /// 座位号
        /// </summary>
        public int SeatNo
        {
            get { return seatNo; }
            set { seatNo = value; }
        }

        private string examNo;
        /// <summary>
        /// 准考号
        /// </summary>
        public string ExamNo
        {
            get { return examNo; }
            set { examNo = value; }
        }

        private int rosterNo;
        /// <summary>
        /// 考生名单表主键
        /// </summary>
        public int RosterNo
        {
            get { return rosterNo; }
            set { rosterNo = value; }
        }

        private bool canChoose;

        public bool CanChoose
        {
            get { return canChoose; }
            set { canChoose = value; }
        }

        private bool isChoosed;

        public bool IsChoosed
        {
            get { return isChoosed; }
            set { isChoosed = value; }
        }

        private int oldIndex;

        public int OldIndex
        {
            get { return oldIndex; }
            set { oldIndex = value; }
        }

    }
}
