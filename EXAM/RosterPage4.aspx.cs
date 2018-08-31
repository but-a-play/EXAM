using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace EXAM
{
    public partial class RosterPage4 : System.Web.UI.Page
    {
        private Roster rosterService = new Roster();
        protected void Page_Load(object sender, EventArgs e)
        {
            gvRoster4.DataSource = rosterService.QueryRosterOrder(null, "seat4");
            gvRoster4.DataBind();
        }
    }
}