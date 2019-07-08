﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;

namespace Firma_Digital
{
    public partial class Login : MetroForm
    {        
        MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=ldfirmas;");

        public Login()
        {
            InitializeComponent();
        }

        private void MetroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void MetroLabel1_Click_1(object sender, EventArgs e)
        {

        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            //string pass = CalculateMD5Hash(txtPassword.Text);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM usuario WHERE ulogin='" + txtUsuario.Text + "'AND clave='" + CalculateMD5Hash(txtPassword.Text) + "' ", con);
            MySqlDataReader leer = cmd.ExecuteReader();
           
            if (leer.Read())
            {
                string estado = leer[3].ToString();
                if (estado == "1")
                {
                    this.Hide();
                    Form1 f2 = new Form1();
                    f2.Show();
                }
                else
                {
                    MetroMessageBox.Show(this, "USUARIO DESACTIVADO, CONTACTE CON SOPORTE", "Incorrecto");
                }
             
                
            }
            else
                MetroMessageBox.Show(this, "Usuario o clave incorrectos, intente nuevamente","Incorrecto");

            con.Close(); 

            
            

        }

        private string CalculateMD5Hash(string input)
        {
            // hashing
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();

        }
        private void MetroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {


        }
        public void RemoveText(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Ingrese usuario")
            {
                txtUsuario.Text = "";
            }
        }

        public void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
                txtUsuario.Text = "Ingrese usuario";
        }

        private void TxtPassword_Click(object sender, EventArgs e)
        {

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
