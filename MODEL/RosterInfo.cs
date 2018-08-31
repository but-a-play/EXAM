using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class RosterInfo
    {
        private int id;
        /// <summary>
        /// 主键id
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;
        /// <summary>
        /// 考生姓名
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value.Trim(); }
        }

        private bool sex;
        /// <summary>
        /// 考生性别
        /// </summary>
        public bool Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        private string identityNo;
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdentityNo
        {
            get { return identityNo; }
            set { identityNo = value.Trim(); }
        }

        private string type;
        /// <summary>
        /// 考试类型
        /// </summary>
        public string Type
        {
            get { return type; }
            set { type = value.Trim(); }
        }

        private string department;
        /// <summary>
        /// 考生工作单位
        /// </summary>
        public string Department
        {
            get { return department; }
            set { department = value.Trim(); }
        }

    }
}
