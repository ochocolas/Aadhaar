<%@ Control Language="C#" AutoEventWireup="true" CodeFile="xWebState.ascx.cs" Inherits="Forms_xWebForms_Catalogs_xWebState" %>
<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<dx:ASPxLabel ID="lblTitulo" runat="server" Font-Bold="True" Font-Size="XX-Large" Font-Strikeout="False" Font-Underline="False" Text="State"></dx:ASPxLabel>


<dx:ASPxGridView ID="ASPxGridViewState" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSourceState" KeyFieldName="Id" OnCustomErrorText="ASPxGridViewState_CustomErrorText">
    <Settings ShowFilterRow="True" />
    <SettingsSearchPanel Visible="True" />
    <SettingsEditing Mode="PopupEditForm">
    </SettingsEditing>
    <SettingsBehavior ConfirmDelete="True"></SettingsBehavior>
    <SettingsPopup>
        <EditForm HorizontalAlign="WindowCenter" Modal="True" VerticalAlign="WindowCenter">
        </EditForm>
    </SettingsPopup>
    <SettingsCommandButton>
        <NewButton ButtonType="Image" RenderMode="Image">
            <Image ToolTip="Nuevo" IconID="actions_new_16x16">
            </Image>
        </NewButton>
        <UpdateButton ButtonType="Image" RenderMode="Image">
            <Image ToolTip="Guardar" IconID="save_save_16x16">
            </Image>
        </UpdateButton>
        <CancelButton ButtonType="Image" RenderMode="Image">
            <Image ToolTip="Cancelar" IconID="actions_cancel_16x16">
            </Image>
        </CancelButton>
        <EditButton ButtonType="Image" RenderMode="Image">
            <Image ToolTip="Editar" IconID="edit_edit_16x16">
            </Image>
        </EditButton>
        <DeleteButton ButtonType="Image" RenderMode="Image">
            <Image ToolTip="Eliminar" IconID="actions_remove_16x16">
            </Image>
        </DeleteButton>
    </SettingsCommandButton>
    <SettingsPopup>
        <EditForm AllowResize="True" HorizontalAlign="WindowCenter" Modal="True" ShowHeader="False" VerticalAlign="WindowCenter">
        </EditForm>
    </SettingsPopup>
    <Columns>
        <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
        </dx:GridViewCommandColumn>
<dx:GridViewDataTextColumn FieldName="Capital" VisibleIndex="3"></dx:GridViewDataTextColumn>
<dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="2">
</dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="Id" VisibleIndex="1">
            <EditFormSettings Visible="False" />
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataDateColumn FieldName="CreatedDate" VisibleIndex="9">
            <EditFormSettings Visible="False" />
        </dx:GridViewDataDateColumn>
        <dx:GridViewDataTextColumn FieldName="CreatedBy" VisibleIndex="10">
            <EditFormSettings Visible="False" />
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataDateColumn FieldName="ModifyDate" VisibleIndex="11">
            <EditFormSettings Visible="False" />
        </dx:GridViewDataDateColumn>
        <dx:GridViewDataTextColumn FieldName="ModifyBy" VisibleIndex="12">
            <EditFormSettings Visible="False" />
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataComboBoxColumn Caption="Official Language" FieldName="IdOfficialLanguage" VisibleIndex="6">
            <PropertiesComboBox DataSourceID="ObjectDataSourceOfficialLanguage" TextField="Name" ValueField="Id">
            </PropertiesComboBox>
        </dx:GridViewDataComboBoxColumn>
        <dx:GridViewDataComboBoxColumn Caption="Country Zone" FieldName="IdCountryZone" VisibleIndex="8">
            <PropertiesComboBox DataSourceID="ObjectDataSourceCountryZone" TextField="Name" ValueField="Id">
            </PropertiesComboBox>
        </dx:GridViewDataComboBoxColumn>
        <dx:GridViewDataSpinEditColumn FieldName="Area" VisibleIndex="4">
            <PropertiesSpinEdit DisplayFormatString="g">
                <SpinButtons ShowIncrementButtons="False">
                </SpinButtons>
            </PropertiesSpinEdit>
        </dx:GridViewDataSpinEditColumn>
        <dx:GridViewDataSpinEditColumn FieldName="Population" VisibleIndex="5">
            <PropertiesSpinEdit DisplayFormatString="g">
                <SpinButtons ShowIncrementButtons="False">
                </SpinButtons>
            </PropertiesSpinEdit>
        </dx:GridViewDataSpinEditColumn>
    </Columns>
</dx:ASPxGridView>
<asp:ObjectDataSource ID="ObjectDataSourceState" runat="server" DataObjectTypeName="AadhaarFramework.Code.Data.Entity.People.State" DeleteMethod="Delete" InsertMethod="Save" SelectMethod="GetAll" TypeName="AadhaarFramework.Code.Data.Providers.People.StateProvider" UpdateMethod="Save"></asp:ObjectDataSource>




<asp:ObjectDataSource ID="ObjectDataSourceOfficialLanguage" runat="server" SelectMethod="GetAll" TypeName="AadhaarFramework.Code.Data.Providers.People.LanguageProvider"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="ObjectDataSourceCountryZone" runat="server" SelectMethod="GetAll" TypeName="AadhaarFramework.Code.Data.Providers.People.CountryZoneProvider"></asp:ObjectDataSource>



