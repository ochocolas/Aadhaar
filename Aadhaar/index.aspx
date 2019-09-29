<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v17.2, Version=17.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.v17.2, Version=17.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Aadhaar</title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!--===============================================================================================-->
    <link rel="icon" type="image/png" href="images/icons/favicon.ico" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/bootstrap/css/bootstrap.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="fonts/font-awesome-4.7.0/css/font-awesome.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="fonts/Linearicons-Free-v1.0.0/icon-font.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/animate/animate.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/css-hamburgers/hamburgers.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/animsition/css/animsition.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/select2/select2.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/daterangepicker/daterangepicker.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="css/util.css">
    <link rel="stylesheet" type="text/css" href="css/main.css">
    <!--===============================================================================================-->
</head>
<body>
    <div class="limiter">
        <div class="container-login100">
            <div class="wrap-login100">
                <%--<div class="login100-form-title" style="background-image: url(images/bg-01.jpg);">--%>

                <form id="form1" runat="server">
                    <div class="login100-form-title" style="background-image: url(img/india-flag-a4.jpg);">
                        <span class="login100-form-title-1">Aadhaar					
					
                        </span>
                    </div>

                    <div class="wrap-input100 validate-input m-b-26" data-validate="Usuario es obligatorio">
                        <%--<span class="label-input100">Usuario</span>--%>
                        <%--<input class="input100" runat="server" type="text" name="txtUsuario" placeholder="Ingrese usuario">--%>
                        <%--class="input100"--%>
                        <dx:ASPxTextBox ID="txtUsuario"  runat="server" Width="100%" placeholder="Ingrese usuario">
                        </dx:ASPxTextBox>
                        <%--<span class="focus-input100"></span>--%>
                    </div>

                    <div class="wrap-input100 validate-input m-b-18" data-validate="La contraseña es obligatoria">
                        <%--<span class="label-input100">Contraseña</span>--%>
                        <%--<input class="input100" runat="server" type="password" name="txtContrasena" placeholder="Ingrese contraseña">--%>
                        <%--class="input100"--%>
                        <dx:ASPxTextBox ID="txtContrasena"  Password="true" runat="server" Width="100%" placeholder="Ingrese contraseña" type="password">
                        </dx:ASPxTextBox>
                        <%--<span class="focus-input100"></span>--%>
                    </div>

                    <div class="flex-sb-m w-full p-b-30">
                        <dx:ASPxLabel ID="lblFeedback" runat="server" Text="" Font-Size="Large" ForeColor="Red">
                        </dx:ASPxLabel>
                    </div>


                    <div class="container-login100-form-btn">
                        <dx:ASPxButton ID="bttnIniciarSesion" runat="server" Text="Iniciar sesión" class="login100-form-btn" OnClick="bttnIniciarSesion_Click">
                        </dx:ASPxButton>
                    </div>
                </form>
            </div>
        </div>
    </div>
    <%--			<button class="login100-form-btn">
							Iniciar sesión
						</button>--%>
    <!--===============================================================================================-->
    <script src="vendor/jquery/jquery-3.2.1.min.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/animsition/js/animsition.min.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/bootstrap/js/popper.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.min.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/select2/select2.min.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/daterangepicker/moment.min.js"></script>
    <script src="vendor/daterangepicker/daterangepicker.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/countdowntime/countdowntime.js"></script>
    <!--===============================================================================================-->
    <script src="js/main.js"></script>



</body>
</html>
