using AddressBook.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddressBook.App
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			TokenManager.GetToken = () => LocalStorage.Token;

			LoginForm loginForm = new LoginForm();
			DialogResult result = loginForm.ShowDialog();

			if (result == DialogResult.OK)
			{
				Application.Run(new MainForm());
			}
		}
	}
}
