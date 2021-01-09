<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="transit.aspx.cs" MasterPageFile="~/Site.Master" Inherits="Viags.WebApp.Pagess.transit" %>

<%@ Register Src="~/Transit/ucTransit.ascx" TagPrefix="uc1" TagName="ucTransit" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder2" ID="content" runat="server">
    <uc1:ucTransit runat="server" ID="ucTransit" />
</asp:Content>
