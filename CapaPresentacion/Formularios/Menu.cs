using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CapaComun.Cache;


namespace CapaPresentacion
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }
        
        #region ARRASTRAR FORMULARIO.
        //Evento para poder arrastrar el formulaRrio Menu----------------------------------------//ss
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void RelaeseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        //---------------------------------------------------------------------------------------------//
        
        // LLamado de los eventos que permiten arrastrar el formulario 
        private void PanelTopHead_MouseDown(object sender, MouseEventArgs e)
        {
            RelaeseCapture();
            SendMessage(this.Handle,0x112,0xf012,0);
        }
        #endregion


        #region FUNCIONALIDAD BOTONES CERRAR,MINIMZAR ETC.

        //Cerrar aplicacion
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir?", "¡ A L E R T A !", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        //Minimizar Menu
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        
        //Boton Maximixar
        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            BtnRestaurar.Visible = true;
            btnMaximizar.Visible = false;

            
        }

        //Boton Restaurar Tamaño original
        private void BtnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            BtnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }



        //CERRAR SESION
        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("¿Seguro que desea cerrar la sesion?", "¡ A L E R T A !", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }






        #endregion


        //Metodo para mostrar los datos de usuario al iniciar sesion
        private void DataUser()
        {
            LblNombre.Text = UserLoginCache.FirstName + "," + UserLoginCache.LastName;
            LblPosicion.Text = UserLoginCache.Position;
            LblMail.Text = UserLoginCache.Email;
            //LblWelcome.Text="Bienvenido "+UserLoginCache.FirstName + "," + UserLoginCache.LastName;
        }   
        

        //CARGAR LOS DATOS GENERALES DEL MENU/HUB
        private void Menu_Load(object sender, EventArgs e)
        {
            //CARGA LOS DATOS DEL USUARIO 
            DataUser();

            #region PRIVILEGIO DE USUARIOS
            //PRIVILEGIOS DE USUARIO
            if (UserLoginCache.Position == Positions.Empleado)
            {
                BtnDashboard.Enabled = false;
                BtnUsers.Enabled = false;
            }
            if (UserLoginCache.Position == Positions.Soporte)
            {
                BtnDashboard.Enabled = false;
            }
            #endregion


        }
        //MUESTRA INFORMACION DE LA CREACION

        #region APARTADO PARA MOSTRAR LOS NOMBRES DE LOS BOTONES DEL MENÚ
        //Muestra el Nombre del BOTON "LISTA DE AUTOS" Cuando el mouse esta encima
        private void BtnAUTOS_MouseEnter(object sender, EventArgs e)
        {
            LblNameAUTOS.Visible = true;
            
        }
        //Deja de mostrar el nombre del BOTON "LISTA DE AUTOS" 
        private void BtnAUTOS_MouseLeave(object sender, EventArgs e)
        {
            LblNameAUTOS.Visible = false;
            
        }
        //Nombre del 2DO boton
        private void BtnRegistroRent_MouseEnter(object sender, EventArgs e)
        {
            LblRentCar.Visible = true;
        }
        private void BtnRegistroRent_MouseLeave(object sender, EventArgs e)
        {
            LblRentCar.Visible = false;
        }
        //Nombre del 3ER boton
        private void BtnDevolucion_MouseEnter(object sender, EventArgs e)
        {
            LblDevolucion.Visible = true;
        }
        private void BtnDevolucion_MouseLeave(object sender, EventArgs e)
        {
            LblDevolucion.Visible = false;
        }
        //Nombre del 4TO boton
        private void BtnClients_MouseEnter(object sender, EventArgs e)
        {
            LblClients.Visible = true;
        }
        private void BtnClients_MouseLeave(object sender, EventArgs e)
        {
            LblClients.Visible = false;
        }
        //Nombre del 5TO boton
        private void BtnUsers_MouseEnter(object sender, EventArgs e)
        {
            LblUsers.Visible = true;
        }
        private void BtnUsers_MouseLeave(object sender, EventArgs e)
        {
            LblUsers.Visible = false;
        }
        //Nombre del 5TO boton
        private void BtnDashboard_MouseEnter(object sender, EventArgs e)
        {
            LblDashboard.Visible = true;
        }
        private void BtnDashboard_MouseLeave(object sender, EventArgs e)
        {
            LblDashboard.Visible = false;
        }


        #endregion

       
    }
}