<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="error.aspx.cs" Inherits="Viags.WebApp.Pagess.error" %>

<%@ Register Src="~/Error/ucError.ascx" TagPrefix="uc1" TagName="ucError" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <uc1:ucError runat="server" ID="ucError" />
</asp:Content>
