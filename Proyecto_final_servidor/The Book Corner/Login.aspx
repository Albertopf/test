<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <section id="form" style="margin-top: 50px;"><!--form-->
		<div class="container">
			<div class="row">
				<div class="col-sm-4 col-sm-offset-1">
					<div class="login-form" style="margin-left: 40px;"><!--login form-->
						<h2>Accede a tu cuenta</h2>
                        <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate">
                            <LayoutTemplate>
                                <form action="#">
							        <asp:TextBox ID="UserName" runat="server" class="form-control" placeholder="Nombre"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="El nombre de usuario es obligatorio." ToolTip="El nombre de usuario es obligatorio." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
							        <asp:TextBox ID="Password" runat="server" TextMode="Password" class="form-control" placeholder="Contraseña"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="La contraseña es obligatoria." ToolTip="La contraseña es obligatoria." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
							        <span>
								        <asp:CheckBox ID="RememberMe" runat="server" Text="Recordarme" class="checkbox"/> 
                                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
							        </span>
							        <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Inicio de sesión" ValidationGroup="Login1" class="btn btn-warning" OnClick="LoginButton_Click"  />
						        </form>
                            </LayoutTemplate>
                        </asp:Login>
					</div>
                
				</div>
				<div class="col-sm-2">
					<h2 class="or">Or</h2>
				</div>
				<div class="col-sm-4">
					<div class="signup-form"><!--sign up form-->
						<h2>Regístrate</h2>
						<div class="form-group">
                            
                            <div class="form-group">
                                <input id="txtnomUsuario" type="text" placeholder="Nombre de usuario" runat="server" class="form-control"/>
                            </div>
                            <div class="form-group">
                                <input id="txtnombre" type="text" placeholder="Nombre y apellidos" runat="server" class="form-control"/>
                            </div>
                            <div class="form-group">
                                <input id="txtCorreo" type="text" placeholder="Correo electrónico" runat="server" class="form-control"/>
                            </div>
                            <div class="form-group">
                                <input id="Password1" type="password" placeholder="Contraseña" runat="server" class="form-control"/>
                            </div>
                            <div class="form-group">
                                <input id="Password2" type="password" placeholder="Confirma la contraseña" runat="server" class="form-control"/>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="btnRegistro" runat="server" Text="Registrarme" Class="btn btn-warning" OnClick="btnRegistro_Click" />
                            </div>
                            
							
							
							
						</div>
							
						
					</div><!--/sign up form-->
                    <asp:Label ID="lblMensajes" runat="server" Text=""></asp:Label>
				</div>
			</div>
		</div>
	</section><!--/form-->
</asp:Content>

