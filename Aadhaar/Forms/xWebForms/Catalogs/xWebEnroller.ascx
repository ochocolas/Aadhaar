<%@ Control Language="C#" AutoEventWireup="true" CodeFile="xWebEnroller.ascx.cs" Inherits="Forms_xWebForms_Catalogs_xWebEnroller" %>
<%@ Register assembly="DevExpress.Web.v17.2, Version=17.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<dx:ASPxLabel ID="lblTitulo" runat="server" Font-Bold="True" Font-Size="XX-Large" Font-Strikeout="False" Font-Underline="False" Text="Enroller">
</dx:ASPxLabel>

<dx:ASPxGridView ID="ASPxGridViewEnroller" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSourceGender" KeyFieldName="Id">
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
        <dx:GridViewDataCheckColumn FieldName="IsEnabled" VisibleIndex="4">
        </dx:GridViewDataCheckColumn>
        <dx:GridViewDataTextColumn FieldName="Token" VisibleIndex="3" ReadOnly="True">
            <EditFormSettings Visible="True" />
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="2">
        </dx:GridViewDataTextColumn>
<dx:GridViewDataTextColumn FieldName="Id" VisibleIndex="1">
    <EditFormSettings Visible="False" />
</dx:GridViewDataTextColumn>
        <dx:GridViewDataDateColumn FieldName="CreatedDate" VisibleIndex="5">
            <EditFormSettings Visible="False" />
        </dx:GridViewDataDateColumn>
        <dx:GridViewDataTextColumn FieldName="CreatedBy" VisibleIndex="6">
            <EditFormSettings Visible="False" />
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataDateColumn FieldName="ModifyDate" VisibleIndex="7">
            <EditFormSettings Visible="False" />
        </dx:GridViewDataDateColumn>
        <dx:GridViewDataTextColumn FieldName="ModifyBy" VisibleIndex="8">
            <EditFormSettings Visible="False" />
        </dx:GridViewDataTextColumn>
    </Columns>
</dx:ASPxGridView>
<asp:ObjectDataSource ID="ObjectDataSourceGender" runat="server" DataObjectTypeName="AadhaarFramework.Code.Data.Entity.Process.Enroller" DeleteMethod="Delete" InsertMethod="Save" SelectMethod="GetAll" TypeName="AadhaarFramework.Code.Data.Providers.Process.EnrollerProvider" UpdateMethod="Save"></asp:ObjectDataSource>



