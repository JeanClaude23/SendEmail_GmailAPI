<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendEmailPage.aspx.cs" Inherits="GmailProject.SendEmailPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Sending Email</h1>
            <table>
                <tr>
                    <td>To:</td>
                    <td>
                        <asp:TextBox ID="TextBox1" cols="30" rows="4" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Subject:</td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Message:</td>
                    <td>
                        <textarea id="TextArea1" cols="30" rows="4" runat="server"></textarea>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="sendmail" runat="server" Text="Send" OnClick="sendmail_Click" style="color: blue" />
                    </td>
                </tr>
            </table>
            </div>

    </form>
</body>
</html>
