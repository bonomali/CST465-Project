<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ValidatedTextBox.ascx.cs" Inherits="CST465Project_StephanieVetter.Web_Forms.ValidatedTextBox" %>
    <asp:Label ID="lblRequiredTextBox" AssociatedControlID="uxRequiredTextBox" runat="server" />
    <asp:TextBox ID="uxRequiredTextBox" Text="" runat="server" />
    <asp:RequiredFieldValidator ID="requiredTextBox" ControlToValidate="uxRequiredTextBox" Text="*" Display="Dynamic" ErrorMessage="Required Field" runat="server" />