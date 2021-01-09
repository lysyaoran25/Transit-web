<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAjaxFormTest.ascx.cs" Inherits="Viags.WebApp.Survey.TestManage.ucAjaxFormTest" %>
<script type="text/javascript" src="/Survey/assets/TestManage/form.js"></script>

<div class="row" style="margin-left: 0; margin-right: 0" id="survey-do-test">
</div>
<!-- Page content -->

<!-- Script -->
<script type="text/javascript">
    window.onload = function () {
        Load_Survey_Do_Test(<%=ItemID%>,<%=ManagerID%>,<%=UserID%>,'<%=Type%>');
    }

</script>
<!-- Script -->
