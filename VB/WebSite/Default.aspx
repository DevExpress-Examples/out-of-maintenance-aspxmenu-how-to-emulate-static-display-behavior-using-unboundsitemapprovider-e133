<%@ Page Language="vb" AutoEventWireup="true" CodeFile="default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v13.1" Namespace="DevExpress.Web.ASPxSiteMapControl"
	TagPrefix="dxsm" %>
<%@ Register Assembly="DevExpress.Web.v13.1" Namespace="DevExpress.Web.ASPxUploadControl"
	TagPrefix="dxuc" %>
<%@ Register Assembly="DevExpress.Web.v13.1" Namespace="DevExpress.Web.ASPxMenu" TagPrefix="dxm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
	<title>Untitled Page</title>
</head>
<body>
	<form id="form1" runat="server">
	<div>

	<asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
	Standard Menu:<br />
	<asp:Menu ID="Menu1" runat="server" DataSourceID="SiteMapDataSource1" Orientation="Horizontal"
		StaticDisplayLevels="2">
	</asp:Menu>
	<br /><br />

	<dxsm:ASPxSiteMapDataSource ID="ASPxSiteMapDataSource1" runat="server" />
	ASPxMenu Menu:<br />
	<dxm:aspxmenu id="ASPxMenu1" runat="server" datasourceid="ASPxSiteMapDataSource1" ShowPopOutImages="True"></dxm:aspxmenu>
	<br /><br />

	SiteMap:<br />
	<dxsm:ASPxSiteMapControl ID="ASPxSiteMapControl1" runat="server" DataSourceID="SiteMapDataSource1">
	</dxsm:ASPxSiteMapControl>

		</div>
	</form>
</body>
</html>
