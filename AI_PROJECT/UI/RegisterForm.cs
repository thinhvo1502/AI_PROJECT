using AI_PROJECT.BLL;
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
    public partial class RegisterForm : Form
    {

            private UserService _userService;

            public RegisterForm(UserService userService)
            {
                InitializeComponent();
            ApplyCustomStyles();
            _userService = userService;
            }


        private void ApplyCustomStyles()
        {
            FormStyling.ApplyStyles(this);

            // Custom styles for RegisterForm
            this.pnlMain.BorderStyle = BorderStyle.FixedSingle;

            this.btnRegister.BackColor = Color.FromArgb(41, 128, 185);
            this.btnRegister.ForeColor = Color.White;
            this.btnRegister.FlatStyle = FlatStyle.Flat;
            this.btnRegister.FlatAppearance.BorderSize = 0;

            this.groupBoxRole.ForeColor = Color.FromArgb(52, 73, 94);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            string role = rbAdmin.Checked ? "Admin" : "User";

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                _userService.RegisterUser(username, password, role);
                MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    }
