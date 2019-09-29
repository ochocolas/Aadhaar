<%@ Control Language="C#" AutoEventWireup="true" CodeFile="xWebPerson.ascx.cs" Inherits="Forms_xWebForms_Catalogs_xWebPerson" %>
<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<p>
    `<script src="../../../js/person-js-provider.js"></script><dx:ASPxLabel ID="lblTitulo" runat="server" Font-Bold="True" Font-Size="XX-Large" Font-Strikeout="False" Font-Underline="False" Text="Person">
    </dx:ASPxLabel>

    <div style="margin-left: 40px">
        <dx:ASPxFormLayout ID="ASPxFormLayoutPerson" runat="server" DataSourceID="ObjectDataSourcePerson"
        OnInit="ASPxFormLayoutPerson_Init">
            <Items>
                <dx:LayoutItem Caption="Search UID">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxButtonEdit ID="txtUIDSearch" runat="server" ClientInstanceName="txtUID" AutoPostBack="True" OnButtonClick="txtUIDSearch_ButtonClick">
                                <Buttons>
                                    <dx:EditButton>
                                        <Image IconID="find_find_16x16">
                                        </Image>
                                    </dx:EditButton>
                                </Buttons>
                                <ValidationSettings ErrorText="UID is mandatory" ValidationGroup="search">
                                    <RequiredField ErrorText="UID is mandatory" IsRequired="True" />
                                </ValidationSettings>
                            </dx:ASPxButtonEdit>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:TabbedLayoutGroup>
                    <Items>
                        <dx:LayoutGroup Caption="General data" ColCount="3">
                            <Items>
                                <dx:LayoutItem FieldName="Id">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxLabel ID="lblUID" runat="server" ClientInstanceName="lblUID">
                                            </dx:ASPxLabel>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem FieldName="IsDesceased">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxCheckBox ID="chckIsDesceased" runat="server" CheckState="Unchecked">
                                            </dx:ASPxCheckBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem FieldName="IsDuplicated">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxCheckBox ID="chckIsDuplicated" runat="server" CheckState="Unchecked">
                                            </dx:ASPxCheckBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem FieldName="FirstName">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxTextBox ID="txtFirstName" runat="server" Width="170px">
                                                <ValidationSettings ValidationGroup="generalData">
                                                    <RequiredField ErrorText="First name can't be empty" IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem FieldName="MiddleName">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxTextBox ID="txtMiddleName" runat="server" Width="170px">
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem FieldName="Photography.Photo" Caption="" RowSpan="3">
                                    <%--<dx:LayoutItem FieldName="Photography.Photo" Caption="" RowSpan="3">--%>
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxBinaryImage ID="ASPxFormLayoutPerson_E3" runat="server" StoreContentBytesInViewState="True">
                                            </dx:ASPxBinaryImage>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem FieldName="LastName">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxTextBox ID="txtLastName" runat="server" Width="170px">
                                                <ValidationSettings ValidationGroup="generalData">
                                                    <RequiredField ErrorText="Last name can't be empty" IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem FieldName="BirthDate">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxDateEdit ID="dtBirthDate" runat="server">
                                                <ValidationSettings>
                                                    <RequiredField ErrorText="Birth date can't be empty" IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxDateEdit>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem FieldName="IdGender" Caption="Gender">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxComboBox ID="cboGender" runat="server" DataSourceID="ObjectDataSourceGender" TextField="Name" ValueField="Id" ValueType="System.Int32">
                                                <ValidationSettings>
                                                    <RequiredField ErrorText="Gender can't be empty" IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxComboBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem FieldName="IdReligion" Caption="Religion">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxComboBox ID="cboReligion" runat="server" DataSourceID="ObjectDataSourceReligion" TextField="Name" ValueField="Id" ValueType="System.Int32">
                                                <ValidationSettings>
                                                    <RequiredField ErrorText="Religion can't be empty" IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxComboBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxButton ID="bttnGuardar" runat="server" Text="Guardar" OnClick="bttnGuardar_Click" Visible="False">
                                                <ClientSideEvents Click="function(s, e) {
//	PersonSave(s,e);
}" />
                                                <Image IconID="save_save_32x32">
                                                </Image>
                                            </dx:ASPxButton>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                            </Items>
                        </dx:LayoutGroup>
                        <dx:LayoutGroup Caption="Geographic data" ColCount="2">
                            <Items>
                                <dx:LayoutItem FieldName="IdState" Caption="State">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxComboBox ID="cboState" runat="server" DataSourceID="ObjectDataSourceState" TextField="Name" ValueField="Id" ValueType="System.Int32">
                                                <ValidationSettings>
                                                    <RequiredField ErrorText="State is mandatory" IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxComboBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem FieldName="AreaLocalitySector" Caption="Area/Locality/Sector">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxTextBox ID="txtAreaLocalitySector" runat="server" Width="170px">
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem FieldName="HouseBuildingApartment" Caption="House/Building/Apartment">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxTextBox ID="txtHouseBuildingApartment" runat="server" Width="170px">
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem FieldName="StreetRoadLane" Caption="Street/Road/Lane">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxTextBox ID="txtStreetRoadLane" runat="server" Width="170px">
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem FieldName="Landmark" Caption="Landmark">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxTextBox ID="txtLandmark" runat="server" Width="170px">
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem FieldName="VillageTownCity" Caption="Village/Town/City">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxTextBox ID="txtVillageTownCity" runat="server" Width="170px">
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem FieldName="CountryArea" Caption="CountryArea">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxTextBox ID="txtCountryArea" runat="server" Width="170px">
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem FieldName="PhoneNumber" Caption="PhoneNumber">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxTextBox ID="txtPhoneNumber" runat="server" Width="170px">
                                                <ValidationSettings>
                                                    <RequiredField ErrorText="Phone number can't be empty" IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem FieldName="Email" Caption="Email">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxTextBox ID="txtEmail" runat="server" Width="170px">
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                            </Items>
                        </dx:LayoutGroup>
                        <dx:LayoutGroup Caption="Biometric data" ColCount="2" Name="BiometricData">
                            <Items>
                                <dx:LayoutItem FieldName="IdIrisLeftEye" Caption="Iris left eye">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxLabel ID="lblIrisLeftEye" runat="server" ClientInstanceName="lblIrisLeftEye">
                                            </dx:ASPxLabel>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem FieldName="IdIrisRightEye" Caption="Iris right eye">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxLabel ID="lblIrisRightEye" runat="server" ClientInstanceName="lblIrisRightEye">
                                            </dx:ASPxLabel>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem FieldName="IdFingerPrintLeftHandThumb" Caption="FingerPrintLeftHandThumb">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxLabel ID="lblFingerPrintLeftHandThumb" runat="server" ClientInstanceName="lblFingerPrintLeftHandThumb">
                                            </dx:ASPxLabel>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem FieldName="IdFingerPrintRightHandThumb" Caption="FingerPrintRightHandThumb">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxLabel ID="lblFingerPrintRightHandThumb" runat="server" ClientInstanceName="lblFingerPrintRightHandThumb">
                                            </dx:ASPxLabel>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem FieldName="IdFingerPrintLeftHandIndex" Caption="FingerPrintLeftHandIndex">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxLabel ID="lblFingerPrintLeftHandIndex" runat="server" ClientInstanceName="lblFingerPrintLeftHandIndex">
                                            </dx:ASPxLabel>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem FieldName="IdFingerPrintRightHandIndex" Caption="FingerPrintRightHandIndex">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxLabel ID="lblFingerPrintRightHandIndex" runat="server" ClientInstanceName="lblFingerPrintRightHandIndex">
                                            </dx:ASPxLabel>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem FieldName="IdFingerPrintLeftHandMiddle" Caption="FingerPrintLeftHandMiddle">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxLabel ID="lblFingerPrintLeftHandMiddle" runat="server" ClientInstanceName="lblFingerPrintLeftHandMiddle">
                                            </dx:ASPxLabel>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem FieldName="IdFingerPrintRightHandMiddle" Caption="FingerPrintRightHandMiddle">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxLabel ID="lblFingerPrintRightHandMiddle" runat="server" ClientInstanceName="lblFingerPrintRightHandMiddle">
                                            </dx:ASPxLabel>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem FieldName="IdFingerPrintLeftHandRing" Caption="Fingerprint left hand ring">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxLabel ID="lblFingerPrintLeftHandRing" runat="server" ClientInstanceName="lblFingerPrintLeftHandRing">
                                            </dx:ASPxLabel>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem FieldName="IdFingerPrintRightHandRing" Caption="Fingerprint right hand ring">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxLabel ID="ASPxFormLayoutPerson_E22" runat="server">
                                            </dx:ASPxLabel>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem FieldName="IdFingerPrintLeftHandPinky" Caption="Fingerprint left hand pinky">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxLabel ID="ASPxFormLayoutPerson_E24" runat="server">
                                            </dx:ASPxLabel>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem FieldName="IdFingerPrintRightHandPinky" Caption="Fingerprint right hand pinky">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxLabel ID="ASPxFormLayoutPerson_E26" runat="server">
                                            </dx:ASPxLabel>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                            </Items>
                        </dx:LayoutGroup>
                        <dx:LayoutGroup Caption="Audit" ColCount="2" Name="Audit">
                            <Items>
                                <dx:LayoutItem FieldName="CreatedDate">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxLabel ID="ASPxFormLayout1_E33" runat="server">
                                            </dx:ASPxLabel>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem FieldName="CreatedBy">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxLabel ID="ASPxFormLayout1_E39" runat="server">
                                            </dx:ASPxLabel>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem FieldName="ModifyDate">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxLabel ID="ASPxFormLayout1_E36" runat="server">
                                            </dx:ASPxLabel>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem FieldName="ModifyBy">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxLabel ID="ASPxFormLayout1_E41" runat="server">
                                            </dx:ASPxLabel>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                            </Items>
                        </dx:LayoutGroup>
                    </Items>
                </dx:TabbedLayoutGroup>
            </Items>
        </dx:ASPxFormLayout>
</div>
    <asp:ObjectDataSource ID="ObjectDataSourcePerson" runat="server" DataObjectTypeName="AadhaarFramework.Code.Data.Entity.People.Person" 
        SelectMethod="GetById" TypeName="AadhaarFramework.Code.Data.Providers.People.PersonProvider" 
        UpdateMethod="Save">
        <SelectParameters>
            <asp:Parameter DefaultValue="" Name="pId" Type="Int64" />
        </SelectParameters>
    </asp:ObjectDataSource>


    <asp:ObjectDataSource ID="ObjectDataSourceGender" runat="server" SelectMethod="GetAll" TypeName="AadhaarFramework.Code.Data.Providers.People.GenderProvider"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSourceReligion" runat="server" SelectMethod="GetAll" TypeName="AadhaarFramework.Code.Data.Providers.People.ReligionProvider"></asp:ObjectDataSource>



    <dx:ASPxCallback ID="ASPxCallbackPerson" runat="server" ClientInstanceName="callbackPerson" OnCallback="ASPxCallbackPerson_Callback">
    </dx:ASPxCallback>




    <asp:ObjectDataSource ID="ObjectDataSourceState" runat="server" SelectMethod="GetAll" TypeName="AadhaarFramework.Code.Data.Providers.People.StateProvider"></asp:ObjectDataSource>





    