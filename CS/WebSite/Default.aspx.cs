using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.Web.ASPxSiteMapControl;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        UnboundSiteMapProvider tempProvider = CloneNodes(SiteMapDataSource1.Provider, Menu1.StaticDisplayLevels);
        ASPxSiteMapDataSource1.Provider = tempProvider;
    }
    protected UnboundSiteMapProvider CloneNodes(SiteMapProvider srcProvider, int levelCount) { // levelCount >= 1
        UnboundSiteMapProvider provider = new UnboundSiteMapProvider();
        AddRecursive(provider, provider.RootNode, srcProvider.RootNode, levelCount);
        return provider;
    }

    private void AddRecursive(UnboundSiteMapProvider provider, SiteMapNode parentNode, SiteMapNode srcNode, int levelCount) {
        SiteMapNode newNode = provider.CreateNode(srcNode.Url, srcNode.Title, srcNode.Description, srcNode.Roles);
        if(GetLevel(srcNode) < levelCount)
            parentNode = provider.RootNode;
        provider.AddSiteMapNode(newNode, parentNode);

        for(int i = 0; i < srcNode.ChildNodes.Count; i++)
            AddRecursive(provider, newNode, srcNode.ChildNodes[i], levelCount);
    }

    private int GetLevel(SiteMapNode node) {
        int ret = 0;
        while(node != node.Provider.RootNode) {
            node = node.ParentNode;
            ret++;
        }
        return ret;
    }

}
