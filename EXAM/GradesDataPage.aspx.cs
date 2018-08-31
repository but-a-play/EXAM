using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace EXAM
{
    


    public partial class GradesDataPage : System.Web.UI.Page
    {
        
        public string DataJson1 { get; set; }
        public string DataJson2 { get; set; }

        private Grades gradesService = null;
        private Roster rosterService = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            gradesService = new Grades();
            rosterService = new Roster();
            if (!IsPostBack)
            {
                DDLBind();
            }
           
        }

        private void DDLBind()
        {
            ddlYears.DataSource = gradesService.GetYears();
            ddlYears.DataBind();
            ddlYears.Items.Insert(0, new ListItem("--请选择年份--",""));

            ddlDepartments.DataSource = rosterService.GetDepartments();
            ddlDepartments.DataBind();
            ddlDepartments.Items.Insert(0, new ListItem("--请选择单位--",""));
        }

        protected void ddlYears_SelectedIndexChanged(object sender, EventArgs e)
        {
            string year = ddlYears.SelectedValue;
            if (!string.IsNullOrEmpty(year))
            {
                DataJson1 = gradesService.GetDataByYearJson(year);
            }
        }

        protected void ddlDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            string deptName = ddlDepartments.SelectedValue;
            if (!string.IsNullOrEmpty(deptName))
            {
                DataJson2 = gradesService.GetDataByDeptJson(deptName);
            }
        }

    }
}