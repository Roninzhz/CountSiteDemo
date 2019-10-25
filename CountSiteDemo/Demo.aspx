<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Demo.aspx.cs" Inherits="CountSiteDemo.Demo" %>

<%@ Register src="onlineNumber.ascx" tagname="onlineNumber" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>网站计数器初步实现</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:onlineNumber ID="onlineNumber1" runat="server" />
        </div>
    </form>
</body>
</html>
