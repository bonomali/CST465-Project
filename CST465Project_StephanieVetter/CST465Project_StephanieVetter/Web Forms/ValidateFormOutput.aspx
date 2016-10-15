<%@ Page Title="" Language="C#" MasterPageFile="~/Web Forms/Contact_Master.Master" AutoEventWireup="true" CodeBehind="ValidateFormOutput.aspx.cs" Inherits="CST465Project_StephanieVetter.Web_Forms.ValidateFormOutput" %>
<asp:Content ID="Content1" ContentPlaceHolderID="nav" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <asp:PlaceHolder ID="uxInvalidDataArea" Visible="false" runat="server">
        <p>This form did not receive the correct parameters</p>
    </asp:PlaceHolder>
    <asp:PlaceHolder ID="uxValidDataArea"  Visible="false" runat="server">
        <div>
            <p>Name: <asp:Literal id="uxName" runat="server" /></p>
        </div>
        <div>
            <p>Favorite Color: <asp:Literal ID="uxFavoriteColor" runat="server" /></p>
        </div>
        <div>
            <p>City:<asp:Literal ID="uxCity" runat="server" /></p>
        </div>
    </asp:PlaceHolder>
</asp:Content>

