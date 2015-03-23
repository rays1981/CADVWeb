using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CADVWeb.DataModel;
using System.Data.Entity.Validation;

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

                cadvDBContext.CADV_PatientReferral.Add(objPatRef);
                cadvDBContext.SaveChanges();
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
    }
}