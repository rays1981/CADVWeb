using System;
using System.Linq;
using CADVWeb.DataModel;
using System.Configuration;


namespace CADVWeb
{
    public partial class Login: System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ResetSession();
              
            }
        }
        private void ResetSession()
        {
            Session.Clear();
            Session["UserCached"] = null;
        }
        protected void BtnLoginButton_Click(object sender, EventArgs e)
        {
            using (var cadvDBContext = new CADVDbEntities())
            {
                var userData = cadvDBContext.CADV_UserMaster.FirstOrDefault(
                    u =>
                        u.Loginpass == txtPassword.Text &&
                        u.Loginname.Equals(txtUserName.Text, StringComparison.InvariantCultureIgnoreCase));
                if (userData != null)
                {
                    Session["UserCached"] = userData;
                    Response.Redirect(ConfigurationManager.AppSettings[userData.RoleID.ToString()].ToString());
                }
                else lbFailureText.Text = "User Name or password is incorrect";
            }            
        }

        protected void lnkNewUser_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            Response.Redirect("NewUser.aspx");
        }      
      
    }
}