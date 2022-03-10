<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="Assignment.Employee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js" type="text/javascript"></script>  
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 101px;
        }
        .auto-style3 {
            width: 356px;
        }
        .auto-style4 {
            width: 105px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1" style="background-color: lightgreen;border-top:5px solid green;border-bottom:5px solid green;margin-bottom:10px">
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">Id</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtid" runat="server" style="border-radius:8px"></asp:TextBox>
&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtid" ErrorMessage="Id is Required" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style4">Address</td>
                    <td>
                        <asp:TextBox ID="txtaddress" runat="server" style="border-radius:8px"></asp:TextBox>
                    &nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtaddress" ErrorMessage="Address is Required" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">Name</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtname" runat="server" style="border-radius:8px"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtname" ErrorMessage="Name is Required" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style4">
                        Role</td>
                    <td>
                        <asp:TextBox ID="txtrole" runat="server" style="border-radius:8px"></asp:TextBox>
                    &nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtrole" ErrorMessage="Role is Required" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">DOB</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtdob" runat="server" placeholder="From" type="date" style="border-radius:8px"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtdob" ErrorMessage="DOB is Required" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style4">
                        Salary</td>
                    <td>
                        <asp:TextBox ID="txtsalary" runat="server" style="border-radius:8px"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtsalary" ErrorMessage="Salary is Required" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">Skills</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtskills" runat="server" style="border-radius:8px"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtskills" ErrorMessage="Skills is Required" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style4">
                        &nbsp;</td>
                    <td>
                    &nbsp; 
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Create" style="background-color:black;color:white" />
                    </td>
                    <td class="auto-style4">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">
                        &nbsp;</td>
                    <td class="auto-style4">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </div>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateDeleteButton="True" OnRowDeleting="GridView1_RowDeleting" OnRowCommand="GridView1_RowCommand">
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandName="send" Text="Send"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
    </form>
</body>
</html>
