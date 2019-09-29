using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_xWebForms_Catalogs_xWebPerson : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BindPerson();
    }

    protected void ASPxCallbackPerson_Callback(object source, DevExpress.Web.CallbackEventArgs e)
    {

        ObjectDataSourcePerson.Update();
        //if (e.Parameter == null || e.Parameter.Length == 0) { return; }
        // Session["SESSION_PERSON_ID"] = e.Parameter;
        //ObjectDataSourcePerson.SelectParameters["pId"].DefaultValue = e.Parameter;
        // ObjectDataSourcePerson.DataBind();

        //ASPxFormLayoutPerson.DataBind();
        // ASPxFormLayoutPerson.DataSourceID = "ObjectDataSourcePerson";

    }

    protected void ASPxFormLayoutPerson_Init(object sender, EventArgs e)
    {
        //ASPxFormLayoutPerson.DataBind();
    }

    protected void txtUIDSearch_ButtonClick(object source, DevExpress.Web.ButtonEditClickEventArgs e)
    {
        
    }
    private void BindPerson()
    {
        ObjectDataSourcePerson.SelectParameters["pId"].DefaultValue = txtUIDSearch.Text;

        ASPxFormLayoutPerson.DataBind();
    }

    protected void bttnGuardar_Click(object sender, EventArgs e)
    {
        ObjectDataSourcePerson.Update();
    }
}