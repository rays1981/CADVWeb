using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CADVWeb
{
    public partial class Success : System.Web.UI.Page
    {
        public string msgCode;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["mc"] != null)
            {
                msgCode = Request.QueryString["mc"].ToString();
                lblMsg.Text = ConfigurationManager.AppSettings[msgCode].ToString();
            }
        }
    }
}