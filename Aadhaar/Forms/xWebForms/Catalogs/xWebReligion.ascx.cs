using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_xWebForms_Catalogs_xWebReligion : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ASPxGridViewReligion_CustomErrorText(object sender, DevExpress.Web.ASPxGridViewCustomErrorTextEventArgs e)
    {
        if (e.Exception == null || e.Exception.InnerException == null) { return; }
        AadhaarFramework.Code.Data.Exceptions.BusinessRuleViolatedException BusinessRuleViolatedException = new AadhaarFramework.Code.Data.Exceptions.BusinessRuleViolatedException();
        BusinessRuleViolatedException = e.Exception.InnerException as AadhaarFramework.Code.Data.Exceptions.BusinessRuleViolatedException;
        if (BusinessRuleViolatedException != null) { e.ErrorText = e.Exception.InnerException.Message.ToString(); }
    }
}