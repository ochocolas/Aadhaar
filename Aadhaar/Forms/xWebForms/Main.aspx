<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Forms_xWebForms_Main" %>

<%@ Register assembly="DevExpress.Web.ASPxPivotGrid.v17.2, Version=17.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPivotGrid" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.v17.2, Version=17.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.ASPxTreeList.v17.2, Version=17.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <dx:ASPxImage ID="ASPxImage1" runat="server" Height="94px" ImageUrl="~/img/220px-Aadhaar_Logo2.svg.png" ShowLoadingImage="true" Width="183px"
            Visible ="true">
        </dx:ASPxImage>
        <dx:ASPxSplitter ID="ASPxSplitterMain" runat="server" Height="700px" ShowCollapseBackwardButton="True"
                Name="MenuArea"
                ClientInstanceName="splitter">
                <Panes>
                    <dx:SplitterPane Size="20%" ScrollBars="Auto">

                        <ContentCollection>
                            <dx:SplitterContentControl runat="server">


                                <dx:ASPxRoundPanel ID="ASPxRoundPanelMenu" runat="server" HeaderText="Menu" Height="100%" Width="100%">
                                    <PanelCollection>
                                        <dx:PanelContent runat="server">
                                            <dx:ASPxTreeList ID="ASPxTreeList" runat="server" AutoGenerateColumns="False" ClientInstanceName="treeMenu" DataSourceID="ASPxSiteMapDataSourceMenu" OnCustomFilterNode="ASPxTreeList_CustomFilterNode" Width="100%">
                                                <Columns>
                                                    <dx:TreeListTextColumn AutoFilterCondition="Default" FieldName="Description" ReadOnly="True" ShowInCustomizationForm="True" ShowInFilterControl="Default" VisibleIndex="0" Visible="False">
                                                    </dx:TreeListTextColumn>
                                                    <dx:TreeListTextColumn AutoFilterCondition="Default" FieldName="Title" ReadOnly="True" ShowInCustomizationForm="True" ShowInFilterControl="Default" VisibleIndex="1">
                                                    </dx:TreeListTextColumn>
                                                    <dx:TreeListTextColumn AutoFilterCondition="Default" FieldName="Url" ReadOnly="True" ShowInCustomizationForm="True" ShowInFilterControl="Default" VisibleIndex="2" Visible="False">
                                                    </dx:TreeListTextColumn>
                                                </Columns>
                                                <Settings ShowColumnHeaders="False" />
                                                <SettingsBehavior AllowAutoFilter="True" AllowDragDrop="False" AllowFocusedNode="True" ExpandNodesOnFiltering="True" />
                                                <SettingsCustomizationWindow PopupHorizontalAlign="RightSides" PopupVerticalAlign="BottomSides" />
                                                <SettingsPopupEditForm VerticalOffset="-1">
                                                </SettingsPopupEditForm>
                                                <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                                                <SettingsPopup>
                                                    <EditForm VerticalOffset="-1">
                                                    </EditForm>
                                                </SettingsPopup>
                                                <ClientSideEvents ContextMenu="function(s, e) {
	}" NodeClick="function(s, e) {	
CallbackpanelMain.PerformCallback(e.nodeKey );
}" />
                                                <Border BorderStyle="None" />
                                            </dx:ASPxTreeList>
                                            <dx:ASPxSiteMapDataSource ID="ASPxSiteMapDataSourceMenu" runat="server" SiteMapFileName="~/web.sitemap" />
                                        </dx:PanelContent>
                                    </PanelCollection>
                                    <Border BorderStyle="None" />
                                </dx:ASPxRoundPanel>

                            </dx:SplitterContentControl>
                        </ContentCollection>
                    </dx:SplitterPane>
                    <dx:SplitterPane ScrollBars="Auto">

                        <ContentCollection>
                            <dx:SplitterContentControl runat="server">
                                <dx:ASPxRoundPanel ID="ASPxRoundPanelMain" runat="server" View="GroupBox" Width="100%" Height="100%" LoadContentViaCallback="true" HeaderText="">
                                    <PanelCollection>
                                        <dx:PanelContent runat="server">

                                            <dx:ASPxCallbackPanel ID="ASPxCallbackPanelMain" runat="server" Height="100%" Width="100%"
                                                ClientInstanceName="CallbackpanelMain" OnCallback="ASPxCallbackPanelMain_Callback">
                                                <PanelCollection>
                                                    <dx:PanelContent runat="server">
                                                    </dx:PanelContent>
                                                </PanelCollection>
                                                <Border BorderStyle="None" />
                                            </dx:ASPxCallbackPanel>
                                        </dx:PanelContent>
                                    </PanelCollection>
                                    <Border BorderStyle="None" />
                                </dx:ASPxRoundPanel>
                            </dx:SplitterContentControl>
                        </ContentCollection>
                    </dx:SplitterPane>
                </Panes>
                <Border BorderStyle="None" />
            </dx:ASPxSplitter>
    </form>
</body>
</html>
