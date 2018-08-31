using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace EXAM
{
    public partial class RosterPage3 : System.Web.UI.Page
    {
        private Roster rosterService = new Roster();
        protected void Page_Load(object sender, EventArgs e)
        {
            gvRoster3.DataSource = rosterService.QueryRosterOrder(null, "seat3");
            gvRoster3.DataBind();
        }
    }
}