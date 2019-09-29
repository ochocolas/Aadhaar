using DevExpress.Web.ASPxTreeList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_xWebForms_Main : System.Web.UI.Page
{
    private const string SESSION_LAST_CONTROL_LOADED_TARGET = "SESSION_LAST_CONTROL_LOADED_TARGET";
    private const string SESSION_LAST_CONTROL_LOADED_NAME = "SESSION_LAST_CONTROL_LOADED_NAME";
    protected void Page_Load(object sender, EventArgs e)
    {
    
    }

    protected override void OnInitComplete(EventArgs e)
    {
        base.OnInitComplete(e);
        if (Session[SESSION_LAST_CONTROL_LOADED_TARGET] != null)
        {
            string name = Session[SESSION_LAST_CONTROL_LOADED_NAME].ToString();
            this.LoadUserWebControl(Session[SESSION_LAST_CONTROL_LOADED_TARGET].ToString(),name);
        }
    }

    protected void ASPxTreeList_CustomFilterNode(object sender, DevExpress.Web.ASPxTreeList.TreeListCustomFilterNodeEventArgs e)
    {

    }

    protected void ASPxCallbackPanelMain_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
    {
        long NodeKey = long.Parse(e.Parameter);
        ASPxTreeList tree = null;
        tree = ASPxTreeList;
        TreeListNode SelectedNode = tree.FindNodeByKeyValue(NodeKey.ToString());
        if (SelectedNode != null)
        {

            string Target = SelectedNode.GetValue("Url").ToString();
            if (Target.Length == 0)
                return;
            if (Target.Substring(0,1) != "~") { Target = String.Concat("~", Target); }
            if (Target.Length == 0)
            {
                Session[SESSION_LAST_CONTROL_LOADED_TARGET] = null;
            }
            string name = Guid.NewGuid().ToString();
            this.LoadUserWebControl(Target,name);
        }
        
        //        Me.LoadUserWebControl(Target, Nombre, Nombre)      
    }

    private void LoadUserWebControl(string Target,string Name)
    {
        if (Target != null && Target.Length > 0)
        {
            try
            {
             
                System.Web.UI.Control control = Page.LoadControl(Target) as System.Web.UI.Control;
                control.ID =Name;
                control.EnableViewState = false;
                //if (ASPxCallbackPanelMain.Controls.Count > 1) { ASPxCallbackPanelMain.Controls.Clear(); }
                ASPxCallbackPanelMain.Controls.Clear();
                ASPxCallbackPanelMain.Controls.Add(control);
                Session[SESSION_LAST_CONTROL_LOADED_TARGET] = Target;
                Session[SESSION_LAST_CONTROL_LOADED_NAME] = Name;


            }
            catch (Exception ex)
            {

            }
        }
        //If pTarget Is Nothing OrElse pTarget.Length = 0 Then Throw New Exception("pTarget no puede ser nulo o vacio")
        //If pName Is Nothing OrElse pName.Length = 0 Then Throw New Exception("pName no puede ser nulo o vacio")
        //If pTitle Is Nothing OrElse pTitle.Length = 0 Then Throw New Exception("pTitle no puede ser nulo o vacio")
        //Try
        //    Dim control As System.Web.UI.Control = TryCast(Page.LoadControl(pTarget), System.Web.UI.Control)
        //    control.ID = pName
        //    control.EnableViewState = False
        //    'If ASPxCallbackPanelMain.Controls.Count > 1 Then ASPxCallbackPanelMain.Controls.Clear()
        //    ASPxCallbackPanelMain.Controls.Clear()
        //    ASPxCallbackPanelMain.Controls.Add(control)

        //    'If ASPxRoundPanelMain.Controls.Count > 0 Then ASPxRoundPanelMain.Controls.Clear()
        //    'ASPxRoundPanelMain.Controls.Add(control)
        //    'ASPxRoundPanelMain.HeaderText = pTitle

        //    Session(SESSION_LAST_CONTROL_LOADED_TARGET) = pTarget
        //    Session(SESSION_LAST_CONTROL_LOADED_NAME) = pName
        //    Session(SESSION_LAST_CONTROL_LOADED_TITLE) = pTitle

        //Catch ex As Exception
        //    Session("SESSION_LOAD_USER_CONTROL_ERROR") = ex.Message.ToString
        //    LoadUserWebControl(USER_CONTROL_EXCEPTION_USER_CONTROL_NOT_FOUND, "User control", "Not found")
        //    'Throw New Exception(String.Concat("Error al cargar el control web: ", ex.Message.ToString))
        //End Try
    }
}