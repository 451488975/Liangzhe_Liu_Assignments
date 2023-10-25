<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CommandBuilderDemo.aspx.cs" Inherits="AdoDemos2.CommandBuilderDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="font-family:Arial">
    <form id="form1" runat="server">
        <div>
            <table border="1">
                <tr>
                    <td>StudentID</td>
                    <td>
                        <asp:TextBox ID="txtStudentID" runat="server"></asp:TextBox>
                        <asp:Button ID="btnGetStudent" runat="server" Text="Load" OnClick="btnGetStudent_Click"/>
                    </td>
                </tr>

                <tr>
                    <td>Name</td>
                    <td>
                        <asp:TextBox ID="txtStudentName" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>Gender</td>
                    <td>
                        <asp:TextBox ID="txtGender" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>Total Marks</td>
                    <td>
                        <asp:TextBox ID="txtTotalMarks" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                        <asp:Button ID="btnInsert" runat="server" Text="Insert" OnClick="btnInsert_Click" />
                        <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                    </td>
                </tr>

            </table>
        </div>
    </form>
</body>
</html>
