using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AadhaarFramework.Code.Security;
using AadhaarFramework.Code.Data.Entity.Security;
public partial class index : System.Web.UI.Page
{
    private const string DEFAULT_PAGE = "~/Forms/xWebforms/Main.aspx";
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected override void OnPreInit(EventArgs e)
    {
        base.OnPreInit(e);
    }
    protected void bttnIniciarSesion_Click(object sender, EventArgs e)
    {
        //Try
        //   Dim S As New Authentication
        //    Dim Usuario As Usuario = S.Authenticate(txtUsuario.Text, txtContrasena.Text)
        //    If Usuario Is Nothing Then
        //        lblFeedback.Text = "Usuario y/o contrasena incorrecto"
        //        Return
        //    Else
        //        If Usuario.ReiniciaClaveAlIniciar Then
        //            SinergiaContext.IdUsuarioCambioPassword = Usuario.Id
        //            Response.Redirect(PASSWORD_CHANGE)
        //        Else
        //            Response.Redirect(CAMBIO_EMPRESA)
        //        End If
        //    End If
        //Catch ex As Exception
        //    lblFeedback.Text = ex.Message.ToString
        //End Try
        try
        {
            
            Authentication Authentication = new Authentication();
            User User = Authentication.Authenticate(txtUsuario.Text, txtContrasena.Text);
            if (User == null)
            {
                lblFeedback.Text = "Wrong username and/or password";
                return;
            }
            else
            {
                Response.Redirect(DEFAULT_PAGE);
            }

        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message.ToString();
        }
   
        
    }
}