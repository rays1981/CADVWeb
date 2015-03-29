using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CADVWeb.DataModel;
using System.Data.Entity.Validation;
using System.Configuration;
using System.Net.Mail;
using System.Net;

namespace CADVWeb
{
    public partial class PatientRefForm : System.Web.UI.Page
    {
        readonly CADVDbEntities cadvDBContext = new CADVDbEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadOptionsets();
            }
        }

        private void LoadOptionsets()
        {
            //LoadDoctors();
            LoadStates();
            //LoadReferralTypes();
        }

        //private void LoadReferralTypes()
        //{
        //    var refTypes = from rtype in cadvDBContext.CADV_ReferralTypes
        //                   orderby rtype.ReferralTypeName
        //                   select rtype;
        //    if (refTypes.Any())
        //    {
        //        foreach (var reftype in refTypes)
        //        {
        //            listreferral.Items.Add(new ListItem(reftype.ReferralTypeName, reftype.ReferralTypeID.ToString()));
        //        }
        //    }
        //}

        private void LoadStates()
        {
            var states = from state in cadvDBContext.CADV_States
                         orderby state.statename
                         select state;

            if (states.Any())
            {
                foreach (var state in states)
                {
                    ddlpstate.Items.Add(new ListItem(state.statename, state.statecode.ToString()));
                }
            }
        }

        //private void LoadDoctors()
        //{
        //    var doctors = from doctor in cadvDBContext.CADV_Doctors
        //                  orderby doctor.Firstname
        //                  select new
        //                  {
        //                      doctor.Initials,
        //                      doctor.Firstname,
        //                      doctor.Middlename,
        //                      doctor.Lastname,
        //                      doctor.DoctorID
        //                  };

        //    if (doctors.Any())
        //    {
        //        foreach (var dr in doctors)
        //        {
        //            ddl_doctors.Items.Add(new ListItem(dr.Initials + " " + dr.Firstname + " " + (!String.IsNullOrEmpty(dr.Middlename) ? dr.Middlename + " " : string.Empty) + dr.Lastname, dr.DoctorID.ToString()));
        //        }
        //    }
        //}

        protected void btnsave_Command(object sender, CommandEventArgs e)
        {
            string expmsg;
            try
            {
                if (!Page.IsValid)
                {
                    return;
                }

                var objPatRef = new CADV_PatientReferral();
                objPatRef.ReferralID = Guid.NewGuid();
                objPatRef.PatientFname = txtpfname.Text;
                objPatRef.PatientLname = txtplname.Text;
                objPatRef.RefPractice = txtrefpractice.Text;
                objPatRef.EntryDate = DateTime.Today;
                objPatRef.Address_line1 = txtpaddress1.Text;
                objPatRef.Address_line2 = txtpaddress2.Text;
                objPatRef.Address_city = txtpcity.Text;
                objPatRef.Address_state = ddlpstate.SelectedValue;
                objPatRef.PhoneNumber = Convert.ToInt32(txtphoneareacode.Value + txtphonenumber.Text);
                objPatRef.Comments = txtreferraltypes.Text;
                objPatRef.Createdby = ((CADV_UserMaster)(Session["UserCached"])).Loginname;
                objPatRef.Postalcode = txtpzip.Text;
                objPatRef.PatientEmail = txtpemail.Text;

                cadvDBContext.CADV_PatientReferral.Add(objPatRef);
                cadvDBContext.SaveChanges();

                if (!String.IsNullOrEmpty(txtpemail.Text))
                    NotifyPatient(txtpfname.Text, txtpemail.Text, "Dr. " + ((CADV_UserMaster)(Session["UserCached"])).Firstname + " " + ((CADV_UserMaster)(Session["UserCached"])).Lastname);

                Response.Redirect("Success.aspx?mc=msgsucc");
            }
            catch (DbEntityValidationException exp)
            {
                foreach (var eve in exp.EntityValidationErrors)
                {
                    expmsg = "Entity of type \"" + eve.Entry.Entity.GetType().Name + "\" in state \"" + eve.Entry.State + "\" has the following validation errors:";
                    foreach (var ve in eve.ValidationErrors)
                    {
                        expmsg += "- Property: \"" + ve.PropertyName + "\", Error: \"" + ve.ErrorMessage + "\"";
                    }
                }
                throw;
            }
        }

        private void NotifyPatient(string toName, string emailTo, string referredBy)
        {
            string smtpAddress = ConfigurationManager.AppSettings["smtpaddress"].ToString();
            int smtpPort = Convert.ToInt32(ConfigurationManager.AppSettings["smtpport"].ToString());
            string emailFrom = ConfigurationManager.AppSettings["senderappemail"].ToString();
            bool enableSSL = Convert.ToBoolean(Convert.ToInt32(ConfigurationManager.AppSettings["ssl"]));
            string defaultSubject = ConfigurationManager.AppSettings["patnotificationsubject"].ToString();
            string pass = ConfigurationManager.AppSettings["pin"].ToString();

            string emailContent = "Dear " + toName + ", <br/>Your case has been referred to another Doctor by " + referredBy + ".</br>With Sincere Regards</br>CADV";

            var client = new SmtpClient(smtpAddress, smtpPort)
            {
                Credentials = new NetworkCredential(emailFrom, pass),
                EnableSsl = enableSSL,               
            };
            MailMessage mailMsg = new MailMessage(emailFrom, emailTo, defaultSubject, emailContent);
            mailMsg.IsBodyHtml = true;
            client.Send(mailMsg); /* The SMTP server requires a secure connection or the client was not authenticated. The server response was: 5.5.1 Authentication Required. */
        }
    }
}