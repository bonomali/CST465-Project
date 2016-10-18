<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="CST465Project_StephanieVetter.Web_Forms.Contact" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lab/Assign 3</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblNameTextBox" AssociatedControlID="uxName" Text="Name" runat="server" />
        <asp:TextBox ID="uxName" Text="" runat="server" /> 
        <asp:Label ID="lblDropDownList" AssociatedControlID="uxPriority" Text="Priority" runat="server" />
        <asp:DropDownList ID="uxPriority" runat="server">
            <asp:ListItem>High</asp:ListItem>
            <asp:ListItem>Medium</asp:ListItem>
            <asp:ListItem>Low</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="lblSubjectTextBox" AssociatedControlID="uxSubject" Text="Subject" runat="server" />
        <asp:TextBox ID="uxSubject" Text="" runat="server" />
        <asp:Label ID="lblDescriptionTextBox" AssociatedControlID="uxDescription" Text="Description" runat="server" />
        <asp:TextBox ID="uxDescription" Text="" runat="server" />
        <asp:Button ID="uxSubmit" OnClick="uxSubmit_Click" Text="Submit" runat="server" />
        <asp:Literal ID="uxFormOutput" Text="" runat="server" />
        <asp:Literal ID="uxEventOutput" Text="" runat="server"/>
    </div>
    </form>
</body>
</html>
