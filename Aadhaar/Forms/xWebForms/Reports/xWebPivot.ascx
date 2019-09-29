<%@ Control Language="C#" AutoEventWireup="true" CodeFile="xWebPivot.ascx.cs" Inherits="Forms_xWebForms_Reports_xWebPivot" %>
<%@ Register assembly="DevExpress.Web.ASPxPivotGrid.v17.2, Version=17.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPivotGrid" tagprefix="dx" %>

<dx:ASPxPivotGrid ID="ASPxPivotGrid1" runat="server" ClientIDMode="AutoID" DataSourceID="ObjectDataSourceView">
    <Fields>
        <dx:PivotGridField ID="fieldAge" AreaIndex="0" FieldName="Age" Name="fieldAge" Options-ShowInFilter="True">
        </dx:PivotGridField>
        <dx:PivotGridField ID="fieldIsDesceased" AreaIndex="1" FieldName="IsDesceased" Name="fieldIsDesceased" Options-ShowInFilter="True">
        </dx:PivotGridField>
        <dx:PivotGridField ID="fieldIsDuplicated" AreaIndex="2" FieldName="IsDuplicated" Name="fieldIsDuplicated" Options-ShowInFilter="True">
        </dx:PivotGridField>
        <dx:PivotGridField ID="fieldCorrectionIndex" AreaIndex="3" FieldName="CorrectionIndex" Name="fieldCorrectionIndex" Options-ShowInFilter="True">
        </dx:PivotGridField>
        <dx:PivotGridField ID="fieldIsHandicapped" AreaIndex="4" FieldName="IsHandicapped" Name="fieldIsHandicapped" Options-ShowInFilter="True">
        </dx:PivotGridField>
        <dx:PivotGridField ID="fieldStateName" AreaIndex="5" FieldName="StateName" Name="fieldStateName" Options-ShowInFilter="True">
        </dx:PivotGridField>
        <dx:PivotGridField ID="fieldArea" AreaIndex="6" FieldName="Area" Name="fieldArea" Options-ShowInFilter="True">
        </dx:PivotGridField>
        <dx:PivotGridField ID="fieldLatitud" AreaIndex="7" FieldName="Latitud" Name="fieldLatitud" Options-ShowInFilter="True">
        </dx:PivotGridField>
        <dx:PivotGridField ID="fieldLongitud" AreaIndex="8" FieldName="Longitud" Name="fieldLongitud" Options-ShowInFilter="True">
        </dx:PivotGridField>
        <dx:PivotGridField ID="fieldPopulation" AreaIndex="9" FieldName="Population" Name="fieldPopulation" Options-ShowInFilter="True">
        </dx:PivotGridField>
        <dx:PivotGridField ID="fieldCountryZoneName" AreaIndex="10" FieldName="CountryZoneName" Name="fieldCountryZoneName" Options-ShowInFilter="True">
        </dx:PivotGridField>
        <dx:PivotGridField ID="fieldGenderName" AreaIndex="11" FieldName="GenderName" Name="fieldGenderName" Options-ShowInFilter="True">
        </dx:PivotGridField>
        <dx:PivotGridField ID="fieldReligionName" AreaIndex="12" FieldName="ReligionName" Name="fieldReligionName" Options-ShowInFilter="True">
        </dx:PivotGridField>
        <dx:PivotGridField ID="fieldEnrollerName" AreaIndex="13" FieldName="EnrollerName" Name="fieldEnrollerName" Options-ShowInFilter="True">
        </dx:PivotGridField>
        <dx:PivotGridField ID="fieldEnrollerIsEnabled" AreaIndex="14" FieldName="EnrollerIsEnabled" Name="fieldEnrollerIsEnabled" Options-ShowInFilter="True">
        </dx:PivotGridField>
        <dx:PivotGridField ID="fieldLanguageName" AreaIndex="15" FieldName="LanguageName" Name="fieldLanguageName" Options-ShowInFilter="True">
        </dx:PivotGridField>
    </Fields>
</dx:ASPxPivotGrid>
<asp:ObjectDataSource ID="ObjectDataSourceView" runat="server" SelectMethod="GetAll" TypeName="AadhaarFramework.Code.Data.Providers.Report.vwPopulationProvider"></asp:ObjectDataSource>

