//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CADVWeb.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class CADV_PatientReferral
    {
        public System.Guid ReferralID { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public string RefPractice { get; set; }
        public string PatientFname { get; set; }
        public string PatientLname { get; set; }
        public string Address_line1 { get; set; }
        public string Address_line2 { get; set; }
        public string Address_city { get; set; }
        public string Address_state { get; set; }
        public string Postalcode { get; set; }
        public int PhoneNumber { get; set; }
        public string Comments { get; set; }
        public string Createdby { get; set; }
        public string PatientEmail { get; set; }
    }
}
