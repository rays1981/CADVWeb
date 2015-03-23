<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CADVWeb.Login" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cadvajax" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CADV Web Access</title>
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link rel="stylesheet" href="Content/Site.css" type="text/css" />
</head>
<body class="loginBody">
    <form id="Form1" runat="server" defaultbutton="BtnLoginButton">
        <cadvajax:ToolkitScriptManager ID="ScriptManagerMain" runat="server"></cadvajax:ToolkitScriptManager>
        <asp:UpdateProgress ID="UpdateProgressLogin" runat="server" DisplayAfter="10" DynamicLayout="True" AssociatedUpdatePanelID="UpdatePanelLogin">
            <ProgressTemplate>
                <div class="Loading">
                    <img alt="" src="Images/loading.gif" />
                </div>

            </ProgressTemplate>

        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanelLogin" runat="server">
            <ContentTemplate>
                <div class="Container">
                    <cadvajax:ModalPopupExtender BackgroundCssClass="ModalPopupBG" ID="ForgotPassword_ModalPopupExtender"
                        runat="server" TargetControlID="lnkForgotPassword" PopupControlID="Panel1"
                        OkControlID="btnpopupcancel" CancelControlID="btnpopupcancel">
                    </cadvajax:ModalPopupExtender>
                    <div class="popup_Buttons" style="display: none">

                        <input id="btnpopupcancel" value="Cancel" type="button" />
                    </div>
                    <div id="Panel1" style="display: none;" class="DivForgotPasswordPanel">
                        <iframe id="frameeditexpanse" frameborder="0" src="Forgotpassword.aspx" height="250" width="350"
                            scrolling="no"></iframe>
                    </div>
                </div>

                <div class="loginContainer">

                    <img src="Images/loginLOGO.png" />
                    <div style="width: 100%" class="system-message">
                        <asp:Label ID="lbFailureText" runat="server" Text=""></asp:Label>
                    </div>
                    <asp:TextBox ID="txtUserName" runat="server" placeholder="Enter Username"></asp:TextBox>
                    <asp:TextBox ID="txtPassword" runat="server" placeholder="Enter Password" TextMode="Password"></asp:TextBox>                                        
                    <asp:Button ID="BtnLoginButton" runat="server" Text="Login with us..." CssClass="signin" OnClick="BtnLoginButton_Click" UseSubmitBehavior="true" />
                    <p>
                        Forgot Password?
                        <asp:LinkButton ID="lnkForgotPassword" Text="Click Here..." runat="server"></asp:LinkButton>
                    </p>
                </div>
                <div class="loginfooterouter">
                    <footer>
                        <p>&copy; <%: DateTime.Now.Year %> - CADV. All Rights Reserved.<a href="http://www.thethinkerz.com" target="_blank">Powered by</a></p>
                    </footer>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="lnkForgotPassword" EventName="Click" />
                <asp:PostBackTrigger ControlID="BtnLoginButton" />
            </Triggers>
        </asp:UpdatePanel>
    </form>
</body>
</html>
