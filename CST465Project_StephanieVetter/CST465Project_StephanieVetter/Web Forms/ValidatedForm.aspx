<%@ Page Title="" Language="C#" MasterPageFile="~/Web Forms/Contact_Master.Master" AutoEventWireup="true" CodeBehind="ValidatedForm.aspx.cs" Inherits="CST465Project_StephanieVetter.Web_Forms.ValidateForm" %>
<%@ Register TagPrefix="CST" TagName="uxRequiredTextBox" Src="~/Web Forms/Contact_Master.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Lab/Assign 3</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nav" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <asp:Panel ID="reqTextBoxPanel" runat="server">
        <CST:uxRequiredTextBox ID="uxName" runat="server" />
        <CST:uxRequiredTextBox ID="uxFavColor" runat="server" />
        <CST:uxRequiredTextBox ID="uxCity" runat="server" /> 
        <asp:Button ID="uxSubmit" OnClick="uxSubmit_Click" Text="Submit" runat="server" />
    </asp:Panel>
</asp:Content>