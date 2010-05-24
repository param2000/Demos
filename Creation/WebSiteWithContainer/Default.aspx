<%@ Import Namespace="System.Linq"%>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebSiteWithContainer._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

		<ul>
		<%= string.Join(Environment.NewLine,Values.Select(x => "<li>" + x + "</li>").ToArray()) %>    
    </ul>
    
    </div>
    </form>
</body>
</html>
