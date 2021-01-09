<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home-dash-board.aspx.cs" MasterPageFile="~/Site.Master" Inherits="Viags.WebApp.Pagess.home_dash_board" %>

<%@ Register Src="~/Home/ucHomeNewDesignDashBoard.ascx" TagPrefix="uc1" TagName="ucHomeNewDesignDashBoard" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder2" ID="content" runat="server">
    <uc1:ucHomeNewDesignDashBoard runat="server" ID="ucHomeNewDesignDashBoard" />
</asp:Content>

