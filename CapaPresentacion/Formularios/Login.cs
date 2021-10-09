using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;


namespace CapaPresentacion.Formularios
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        #region FUNCIONALIDAD DE BOTONES CERRAR Y MINIMZAR

        //boton cerrar
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //BOTON MINIMIZAR
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion


        #region EFECTOS Y FUNCIONALIDADES DE TEXBOX USER Y PASSWORD

        //EFECTO PARA TEXBOX USER ----------------------------------------------//

        private void TxtUserName_Enter(object sender, EventArgs e)
        {
            if (TxtUserName.Text == "Nombre De usuario")
            {
                TxtUserName.Text = "";
            }
        }
        private void TxtUserName_Leave(object sender, EventArgs e)
        {
            if (TxtUserName.Text == "")
            {
                TxtUserName.Text = "Nombre De usuario";
            }
        }
        //EFECTO PARA TEXBOX PASS-----------------------------------------------//

        private void TxtPassword_Enter(object sender, EventArgs e)
        {
            if (TxtPassword.Text == "Contraseña")
            {
                TxtPassword.Text = "";
                TxtPassword.UseSystemPasswordChar = true;
            }
        }

        private void TxtPassword_Leave(object sender, EventArgs e)
        {
            if (TxtPassword.Text == "")
            {   
                TxtPassword.Text = "Contraseña";
                TxtPassword.UseSystemPasswordChar = false;
                
             // Cambia la propiedad de btn desenmascarar contraseña para que no aparezca si no hay texto alguno //
                btnInvisible.Visible = false;
                btnVisible.Visible = false;
            }   
        }//-----------------------------------------------------------------------//

        //Evento para que al presionar una tecla en el texbox PASS muestre el boton de desesmacarar Contraseña
        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnInvisible.Visible = true;
            btnVisible.Visible = true;
        }


        //FUNCIONALIDAD BTN DESENMASCARAR CONTRASEÑAS------------------------------//
        private void btnVisible_Click(object sender, EventArgs e)
        {
               TxtPassword.UseSystemPasswordChar = true;
               btnVisible.Visible = false;
               btnInvisible.Visible = true;
        }
        private void btnInvisible_Click(object sender, EventArgs e)
        {
            TxtPassword.UseSystemPasswordChar = false;
            btnVisible.Visible = true;
            btnInvisible.Visible = false;
        }
        //-----------------------------------------------------------------------//



        #endregion



        #region VALIDACION DE USUARIO , LOGIN Y LOGOUT

        //funcion para mostrar mensajes de errores
        private void msgError(string msg)
        {
            LblError.Text = "     " + msg;
            LblError.Visible = true;
        }
        //BOTONO INICIAR SESION CLICK

        private void btnAcceder_Click(object sender, EventArgs e)
        {
             //Validacion de login

            if (TxtUserName.Text != "Nombre De usuario") 
            {   
                if (TxtPassword.Text != "Contraseña") 
                {
                    UserModel user = new UserModel();
                    var validLogin = user.LoginUser(TxtUserName.Text,TxtPassword.Text);
                    if (validLogin == true)
                    {
                        Menu hub = new Menu();
                        hub.Show();
                        hub.FormClosed+=Logout;
                        this.Hide();
                        
                    }
                    else
                    {
                        msgError("Contraseña o usuario incorrecto,\n por favor intente de nuevo");
                        TxtPassword.Clear();
                        TxtUserName.Focus();
                    }
                }
                else msgError("por favor ingrese su contraseña");
            }
            else msgError("por favor ingresa tu nombre de usuario");

        }

        //Validacion de Logout
        private void Logout(object sender,FormClosedEventArgs e)
        {
            
            LblError.Visible = false;
            this.Show();
             
            //CODIGO PARA QUE AL CERRAR SESION LOS BOTONES Y LOS TEXBOX SE QUEDEN NO EN EL INICIO DE SESION
            btnInvisible.Visible = false;
            btnVisible.Visible = false;
            TxtUserName.Text = "Nombre De usuario";
            TxtPassword.Text = "Contraseña";
            TxtPassword.UseSystemPasswordChar = false;
        }

     


        #endregion












    }

}
