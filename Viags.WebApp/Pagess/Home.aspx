<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" MasterPageFile="~/Site.Master" Inherits="Viags.WebApp.Pagess.Home" %>
<%@ Register Src="~/Home/ucHomeNewDesign.ascx" TagPrefix="uc1" TagName="ucHomeNewDesign" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder2" ID="content" runat="server">
    <uc1:ucHomeNewDesign runat="server" ID="ucHomeNewDesign" />
</asp:Content>

