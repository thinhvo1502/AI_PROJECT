﻿using AI_PROJECT.BLL;
using AI_PROJECT.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AI_PROJECT.UI
{
    public partial class LoginForm : Form
    {
        private UserService _userService;
        public User AuthenticatedUser { get; private set; }

        public LoginForm(UserService userService)
        {
            InitializeComponent();
            ApplyCustomStyles();
            _userService = userService;

        }
        private void ApplyCustomStyles()
        {
            FormStyling.ApplyStyles(this);

            // Custom styles for LoginForm
            this.pnlMain.BorderStyle = BorderStyle.FixedSingle;

            this.btnLogin.BackColor = Color.FromArgb(0, 150, 136);
            this.btnLogin.ForeColor = Color.White;
            this.btnLogin.FlatStyle = FlatStyle.Flat;
            this.btnLogin.FlatAppearance.BorderSize = 0;

            this.btnRegister.BackColor = Color.FromArgb(41, 128, 185);
            this.btnRegister.ForeColor = Color.White;
            this.btnRegister.FlatStyle = FlatStyle.Flat;
            this.btnRegister.FlatAppearance.BorderSize = 0;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            User user = _userService.AuthenticateUser(username, password);
            if (user != null)
            {
                _userService.SetCurrentUser(user);
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                var mainForm = new MainForm(_userService);
                mainForm.FormClosed += (s, args) => this.Close();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var registerForm = new RegisterForm(_userService);
            registerForm.ShowDialog();
        }



    }
}
