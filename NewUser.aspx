<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewUser.aspx.cs" Inherits="CADVWeb.NewUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width: 60%" id="nuserform">
        <div style="clear: both;">
            <h3>New User</h3>
        </div>
        <div style="clear: both; float: right">
            <asp:Label runat="server" ID="lblmsg" ForeColor="Red"></asp:Label>
        </div>
        <div style="clear: both;">
            <div style="float: left; text-align: right">First Name:*</div>
            <div style="float: right; text-align: left">
                <%--<asp:DropDownList runat="server" ID="ddl_doctors" DataValueField="DoctorID"></asp:DropDownList>--%>
                <asp:TextBox runat="server" ID="txtfname"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="txtfname" runat="server" ID="rqfname"
                ErrorMessage="*" ValidationGroup="nuvalidation" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="clear: both;">
            <div style="float: left; text-align: right">Last Name:*</div>
            <div style="float: right; text-align: left">
                <asp:TextBox runat="server" ID="txtlname"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="txtlname" runat="server" ID="rqlname"
                ErrorMessage="*" ValidationGroup="nuvalidation" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="clear: both;">
            <div style="float: left; text-align: right">Login Name:*</div>
            <div style="float: right; text-align: left">
                <asp:TextBox runat="server" ID="txtloginname"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="txtloginname" runat="server" ID="rqlogname"
                ErrorMessage="*" ValidationGroup="nuvalidation" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="clear: both;">
            <div style="float: left; text-align: right">Password:*</div>
            <div style="float: right; text-align: left">
                <asp:TextBox runat="server" ID="txtpass" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="txtpass" runat="server" ID="rqpass"
                ErrorMessage="*" ValidationGroup="nuvalidation" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div> 
        <div style="clear: both;">
            <div style="float: left; text-align: right">Confirm Password:*</div>
            <div style="float: right; text-align: left">
                <asp:TextBox runat="server" ID="txtconfpass" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="txtconfpass" runat="server" ID="rqcpass"
                ErrorMessage="*" ValidationGroup="nuvalidation" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="clear: both; float: right; padding-right:10px;">
            <asp:Button runat="server" ID="btnsave" ValidationGroup="nuvalidation" Text="Register" OnClick="btnsave_Click" />
        </div>       
    </div>
</asp:Content>
