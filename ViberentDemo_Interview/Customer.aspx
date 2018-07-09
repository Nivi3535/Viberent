<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="ViberentDemo_Interview.Customer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HiddenField ID="HiddenFieldId" runat="server" />
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lCustomerName" runat="server" Text="Customer Name"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtCustomerName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="lCustomerFN" runat="server" Text="Customer FirstName"></asp:Label>
                        
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtCustomerFN" runat="server"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="lCustomerLN" runat="server" Text="CustomerLastName"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtCustomerLN" runat="server"></asp:TextBox>

                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="lCustomerPhone" runat="server" Text="Customer Contact Number"></asp:Label>
                        
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtCustomerPhone" runat="server"></asp:TextBox>

                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="lCustomerAddress" runat="server" Text="Customer Address"></asp:Label>
                        
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtCustomerAddress" runat="server" TextMode="MultiLine"></asp:TextBox>

                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="lCustomerEmailId" runat="server" Text="Customer Email-ID"></asp:Label>
                        
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtCustomerEmailId" runat="server"></asp:TextBox>

                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="lCustomerPassword" runat="server" Text="Customer Password"></asp:Label>
                        
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtCustomerPassword" runat="server" CausesValidation="True"   ></asp:TextBox>
                       
                        <asp:RegularExpressionValidator ID="Regex4" runat="server" ControlToValidate="txtCustomerPassword"
    ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}"
ErrorMessage="Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character" ForeColor="Red" />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />   

                    </td>   
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="loperation" runat="server" Text="Operation"></asp:Label>
                    </td>
                    <td>
                        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                        <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lSuccessM" runat="server" Text="Success Message" ></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lSuccessMsg" runat="server" Text="" ForeColor="RoyalBlue"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="IvalidationM" runat="server" Text="Validation Message"></asp:Label>

                    </td>
                    <td>
                        <asp:Label ID="lValidationSummary" runat="server" Text="" ForeColor="Tomato"></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <asp:GridView ID="GridCustomerDetails" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="CustomerId" HeaderText="ID" />
                    <asp:BoundField DataField="CustomerName" HeaderText="Name" />
                    <asp:BoundField DataField="CustomerFirstName" HeaderText="FirstName" />
                    <asp:BoundField DataField="CustomerLastName" HeaderText="LastName" />
                    <asp:BoundField DataField="CustomerPhoneNumber" HeaderText="Contact Number" />
                    <asp:BoundField DataField="CustomerAddress" HeaderText="Address" />
                    <asp:BoundField DataField="CustomerEmailId" HeaderText="Email Id" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Link_OnClick" CommandArgument='<%# Eval("CustomerId") %>'>Click Here To Update or View</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            
        </div>
        
    </form>
</body>
</html>
