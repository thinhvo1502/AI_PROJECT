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
            FormStyling.ApplyStyles(this);
            _userService = userService;
            }

            private void btnRegister_Click(object sender, EventArgs e)
            {
                try
                {
                    string role = rbAdmin.Checked ? "Admin" : "User";
                    _userService.RegisterUser(txtUsername.Text, txtPassword.Text, role);
                    MessageBox.Show("User registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
