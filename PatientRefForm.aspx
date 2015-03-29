<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PatientRefForm.aspx.cs" Inherits="CADVWeb.PatientRefForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width: 60%" id="prefform">
        <div style="clear: both;">
            <h3>Patient Referral Information</h3>
        </div>
        <div style="clear: both; width: auto; float: right;">
            <asp:RequiredFieldValidator ControlToValidate="txtphoneareacode" runat="server" ID="rqphareacode"
                ErrorMessage="**Please enter Phone Area Code" ValidationGroup="prefvalidation" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ControlToValidate="txtphonenumber" runat="server" ID="rqphno"
                ErrorMessage="&nbsp;**Please enter Phone Number" ValidationGroup="prefvalidation" ForeColor="Red"></asp:RequiredFieldValidator>            
            <asp:RequiredFieldValidator ControlToValidate="txtrefpractice" runat="server" ID="rqrefprac"
                    ErrorMessage="&nbsp;**Please enter Referring Practice" ValidationGroup="prefvalidation" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ControlToValidate="txtpfname" runat="server" ID="rqfname"
                    ErrorMessage="&nbsp;**Please enter Patient's First name" ValidationGroup="prefvalidation" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ControlToValidate="txtplname" runat="server" ID="rqlname"
                    ErrorMessage="&nbsp;**Please enter Patient's Last name" ValidationGroup="prefvalidation" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ControlToValidate="txtphoneareacode" ForeColor="Red" runat="server" ID="regexarea" 
                ErrorMessage="&nbsp;**Phone Area code should contain 3 characters" ValidationGroup="prefvalidation" ValidationExpression="^[0-9]{3}$"></asp:RegularExpressionValidator>
        </div>
        <div style="clear: both;">
            <div style="float: left; text-align: right">Date Entered:</div>
            <div style="float: right; text-align: left"><%=DateTime.Today.ToShortDateString()%></div>
        </div>
        <%--<div style="clear: both;">
            <div style="float: left; text-align: right">Referring Practice:</div>
            <div style="float: right; text-align: left"><%=ConfigurationManager.AppSettings["refpractice"].ToString()%></div>
        </div>--%>
        <div style="clear: both;">
            <div style="float: left; text-align: right">Referring Practice:*</div>
            <div style="float: right; text-align: left">
                <%--<asp:DropDownList runat="server" ID="ddl_doctors" DataValueField="DoctorID"></asp:DropDownList>--%>                
                <asp:TextBox runat="server" ID="txtrefpractice"></asp:TextBox>
            </div>
        </div>
        <div style="clear: both;">
            <div style="float: left; text-align: right">Patient First Name:*</div>
            <div style="float: right; text-align: left">
                <asp:TextBox runat="server" ID="txtpfname"></asp:TextBox>
            </div>
        </div>
        <div style="clear: both;">
            <div style="float: left; text-align: right">Patient Last Name:*</div>
            <div style="float: right; text-align: left">                
                <asp:TextBox runat="server" ID="txtplname"></asp:TextBox>
            </div>
        </div>
        <div style="clear: both;">
            <div style="float: left; text-align: right">Patient Address 1:</div>
            <div style="float: right; text-align: left">
                <asp:TextBox runat="server" ID="txtpaddress1"></asp:TextBox>
            </div>
        </div>
        <div style="clear: both;">
            <div style="float: left; text-align: right">Patient Address 2:</div>
            <div style="float: right; text-align: left">
                <asp:TextBox runat="server" ID="txtpaddress2"></asp:TextBox>
            </div>
        </div>
        <div style="clear: both;">
            <div style="float: left; text-align: right">Patient City:</div>
            <div style="float: right; text-align: left">
                <asp:TextBox runat="server" ID="txtpcity"></asp:TextBox>
            </div>
        </div>
        <div style="clear: both;">
            <div style="float: left; text-align: right">Patient State:</div>
            <div style="float: right; text-align: left">
                <asp:DropDownList runat="server" ID="ddlpstate" DataTextField="statename" DataValueField="statecode"></asp:DropDownList>
            </div>
        </div>
        <div style="clear: both;">
            <div style="float: left; text-align: right">Patient Zip:</div>
            <div style="float: right; text-align: left">
                <asp:TextBox runat="server" ID="txtpzip"></asp:TextBox>
            </div>
        </div>
        <div style="clear: both;">
            <div style="float: left; text-align: right">Patient Phone Number:*</div>
            <div style="float: right; text-align: left">
                (<input runat="server" id="txtphoneareacode" maxlength="3" size="3" type="number"></input>)
                <asp:TextBox runat="server" ID="txtphonenumber" TextMode="Number"></asp:TextBox>
            </div>
        </div>
        <div style="clear: both;">
            <div style="float: left; text-align: right">Patient Email:</div>
            <div style="float: right; text-align: left">
                <asp:TextBox runat="server" ID="txtpemail" TextMode="Email"></asp:TextBox>
            </div>
        </div>
        <div style="clear: both;">
            <div style="float: left; text-align: right">Reason for Referral:</div>
            <div style="float: right; text-align: left">
                <%--<asp:ListBox runat="server" ID="listreferral" SelectionMode="Multiple" DataTextField="ReferralTypeName" DataValueField="ReferralTypeID"></asp:ListBox>--%>
                <asp:TextBox runat="server" ID="txtreferraltypes" TextMode="MultiLine"></asp:TextBox>
            </div>
        </div>
        <%--<div style="clear: both;">
            <div style="float: left; text-align: right">Comments/Diagnosis of Patient:</div>
            <div style="float: right; text-align: left">
                <asp:TextBox runat="server" ID="txtcomments" TextMode="MultiLine"></asp:TextBox>
            </div>
        </div>--%>
        <div style="clear: both; float: right">
            <asp:Button runat="server" ID="btnsave" ValidationGroup="prefvalidation" Text="Submit Information" OnCommand="btnsave_Command" />
        </div>
    </div>
</asp:Content>
