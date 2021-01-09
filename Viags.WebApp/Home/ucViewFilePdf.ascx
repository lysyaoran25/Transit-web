<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucViewFilePdf.ascx.cs" Inherits="Viags.WebApp.Home.ucViewFilePdf" %>
<object width="100%" height="100%" type="application/pdf" data="<%=UrlFile %>?#zoom=85&scrollbar=0&toolbar=0&navpanes=0&plugin=true"
    id="pdf_content">
    <p>
        the PDF cannot be displayed.</p>
</object>