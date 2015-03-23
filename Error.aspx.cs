using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CADVWeb
{
    public partial class Error : System.Web.UI.Page
    {
        public string errCode;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ec"] != null)
            {
                errCode = Request.QueryString["ec"].ToString();

                switch (errCode)
                {
                    case "404":
                        lblErr.Text = "The resource you are looking for is not available";
                        break;

                    default:
                        lblErr.Text = "An error occurred while processing your request";
                        break;
                }

            }
            else
            {
                lblErr.Text = "An error occurred while processing your request";
            }
        }
    }
}