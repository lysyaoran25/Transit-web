<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="list-taixe.aspx.cs" MasterPageFile="~/Site.Master" Inherits="Viags.WebApp.Pagess.list_taixe" %>

<%@ Register Src="~/Transit/DanhSachTaiXe/ucListTaiXe.ascx" TagPrefix="uc1" TagName="ucListTaiXe" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder2" ID="content" runat="server">
    <uc1:ucListTaiXe runat="server" ID="ucListTaiXe" />
</asp:Content>
