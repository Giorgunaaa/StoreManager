using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AddressBook.DAL;

namespace AddressBook.App
{
	public partial class LoginForm : Form
	{
		private readonly UserRepository _userRepository;

		public LoginForm()
		{
			InitializeComponent();
			_userRepository = new UserRepository();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			LocalStorage.Token =
				_userRepository.Login(txtEmail.Text, txtPassword.Text);

			if (LocalStorage.Token == null)
			{
				MessageBox.Show("Login failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			DialogResult = DialogResult.OK;
		}

		private void btnRegistration_Click(object sender, EventArgs e)
		{
				
		}

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void lblEmail_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
