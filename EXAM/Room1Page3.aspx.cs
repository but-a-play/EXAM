﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace EXAM
{
    public partial class Room1Page3 : System.Web.UI.Page
    {
        private Roster rosterService = new Roster();
        protected void Page_Load(object sender, EventArgs e)
        {
            Dictionary<string, object> paramsMap1 = new Dictionary<string, object>();
            paramsMap1.Add("room", "教室甲");
            gvRoom1Seat3.DataSource = rosterService.QueryRosterData(paramsMap1, "seat3");
            gvRoom1Seat3.DataBind();
        }
    }
}