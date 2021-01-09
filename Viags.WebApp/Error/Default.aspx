<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Viags.WebApp.Error.Default" MasterPageFile="~/MasterPage/Base.Master" %>

<%@ Register TagName="ucError" TagPrefix="uc1" Src="~/Error/ucError.ascx" %>
<asp:Content ContentPlaceHolderID="head" ID="header" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="content" runat="server">
       <uc1:ucError ID="ucError" runat="server" />
</asp:Content>