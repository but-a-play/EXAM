using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace EXAM
{
    public partial class Room2Page2 : System.Web.UI.Page
    {
        private Roster rosterService = new Roster();
        protected void Page_Load(object sender, EventArgs e)
        {
            Dictionary<string, object> paramsMap2 = new Dictionary<string, object>();
            paramsMap2.Add("room", "教室乙");
            gvRoom2Seat2.DataSource = rosterService.QueryRosterData(paramsMap2, "seat2");
            gvRoom2Seat2.DataBind();
        }
    }
}