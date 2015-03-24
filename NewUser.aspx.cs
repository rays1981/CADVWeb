using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CADVWeb.DataModel;
using System.Configuration;

namespace CADVWeb
{
    public partial class NewUser : System.Web.UI.Page
    {
        readonly CADVDbEntities cadvDBContext = new CADVDbEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                lblmsg.Text = string.Empty;
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (txtpass.Text != txtconfpass.Text)
            {
                lblmsg.Text = "Both passwords must match";
            }
            else
                if (!Page.IsValid)
                {
                    return;
                }

                else
                {
                    var objNewUser = new CADV_UserMaster();
                    objNewUser.UserID = Guid.NewGuid();
                    objNewUser.Firstname = txtfname.Text;
                    objNewUser.Lastname = txtlname.Text;
                    objNewUser.Loginname = txtloginname.Text;
                    objNewUser.Loginpass = txtpass.Text;
                    objNewUser.RoleID = Convert.ToInt32(ConfigurationManager.AppSettings["uroletype"].ToString());
                    objNewUser.Createdon = DateTime.Today;

                    cadvDBContext.CADV_UserMaster.Add(objNewUser);
                    cadvDBContext.SaveChanges();
                    Response.Redirect("Success.aspx?mc=msgsucc");
                }

        }
    }
}