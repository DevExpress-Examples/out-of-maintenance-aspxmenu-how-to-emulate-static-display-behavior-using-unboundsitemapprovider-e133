Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.Web.ASPxSiteMapControl

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		Dim tempProvider As UnboundSiteMapProvider = CloneNodes(SiteMapDataSource1.Provider, Menu1.StaticDisplayLevels)
		ASPxSiteMapDataSource1.Provider = tempProvider
	End Sub
	Protected Function CloneNodes(ByVal srcProvider As SiteMapProvider, ByVal levelCount As Integer) As UnboundSiteMapProvider ' levelCount >= 1
		Dim provider As New UnboundSiteMapProvider()
		AddRecursive(provider, provider.RootNode, srcProvider.RootNode, levelCount)
		Return provider
	End Function

	Private Sub AddRecursive(ByVal provider As UnboundSiteMapProvider, ByVal parentNode As SiteMapNode, ByVal srcNode As SiteMapNode, ByVal levelCount As Integer)
		Dim newNode As SiteMapNode = provider.CreateNode(srcNode.Url, srcNode.Title, srcNode.Description, srcNode.Roles)
		If GetLevel(srcNode) < levelCount Then
			parentNode = provider.RootNode
		End If
		provider.AddSiteMapNode(newNode, parentNode)

		For i As Integer = 0 To srcNode.ChildNodes.Count - 1
			AddRecursive(provider, newNode, srcNode.ChildNodes(i), levelCount)
		Next i
	End Sub

	Private Function GetLevel(ByVal node As SiteMapNode) As Integer
		Dim ret As Integer = 0
		Do While node IsNot node.Provider.RootNode
			node = node.ParentNode
			ret += 1
		Loop
		Return ret
	End Function

End Class
