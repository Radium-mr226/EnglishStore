using EnglishStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnglishStore.AppForms
{
    public partial class AutorizationForm : Form
    {
        public AutorizationForm()
        {
            InitializeComponent();
        }

        private void AutorizationForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "englishStore_DubininRADataSet.User". При необходимости она может быть перемещена или удалена.
            this.userTableAdapter.Fill(this.englishStore_DubininRADataSet.User);

        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            string username = loginTextBox.Text;
            string password = passwordTextBox.Text;

            try
            {
                List<User> users = Program.context.User.ToList();
                User u = users.FirstOrDefault(p => p.Login == username && p.Password == password);
                if (u != null)
                {
                    MainForm mainForm = new MainForm(u);
                    mainForm.Owner = this;
                    this.Hide();
                    passwordTextBox.Clear();
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        
        private void buttonGuest_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Owner = this;
            this.Hide();
            passwordTextBox.Clear();
            mainForm.Show();

        }
    }
}
