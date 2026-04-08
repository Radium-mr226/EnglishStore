using EnglishStore.CustomUserControl;
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
    public partial class MainForm : Form
    {
        private List<Product> _productsList;
        private User _user;
        private bool IsGuest = false;
        private bool IsAdmin = false;
        private bool IsUser = false;
        public MainForm()
        {
            InitializeComponent();
            ShowProducts();
            IsGuest = true;
        }
        public MainForm(User user)
        {
            InitializeComponent();
            _user = user;
            labelTitle.Text = $"Добро пожаловать в магазин, {_user.Login}";
            ShowProducts();
            if (_user.Login == "admin")
                IsAdmin = true;
            else 
                IsUser = true;
        }

        public void RefreshBooks()
        {
            ClearProductsList();
            ShowProducts();
        }

        private void ShowProducts()
        {
            List<Product> _productsList = Program.context.Product.OrderBy(p => p.Name).ToList();
            foreach (Product prod in _productsList)
            {
                var product = new ProductUserControl(prod);
                flowLayoutPanel1.Controls.Add(product);
            }
        }

        private void ClearProductsList()
        {
            flowLayoutPanel1.Controls.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "englishStore_DubininRADataSet.Manufacturer". При необходимости она может быть перемещена или удалена.
            this.manufacturerTableAdapter.Fill(this.englishStore_DubininRADataSet.Manufacturer);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "englishStore_DubininRADataSet.Product". При необходимости она может быть перемещена или удалена.
            this.productTableAdapter.Fill(this.englishStore_DubininRADataSet.Product);
            // Очищаем ComboBox
            manufacturerIDComboBox.Items.Clear();

            // Добавляем "Все элементы"
            manufacturerIDComboBox.Items.Add("Все элементы");

            // Добавляем производителей
            foreach (var manufacturer in Program.context.Manufacturer )
            {
                manufacturerIDComboBox.Items.Add(manufacturer.Name);
            }

            manufacturerIDComboBox.SelectedIndex = 0;
            // Для получения ID при выборе нужно будет хранить отдельно
            if (IsGuest)
            {
                textBoxFind.Enabled = false;
                manufacturerIDComboBox.Enabled = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FindBooks();
        }

        private void FindBooks()
        {
            ClearProductsList();
            if (textBoxFind.Text.Length == 0 && manufacturerIDComboBox.SelectedIndex == 0 && SortComboBox.SelectedIndex == -1)
            {
                RefreshBooks();
                return;
            }
            else if (textBoxFind.Text.Length == 0 && manufacturerIDComboBox.SelectedIndex == 0 && SortComboBox.SelectedIndex != -1)
            {
                if (SortComboBox.SelectedIndex == 1)
                    _productsList = Program.context.Product.OrderBy(p => p.Price).ToList();
                else if (SortComboBox.SelectedIndex == 0)
                    _productsList = Program.context.Product.OrderByDescending(p => p.Price).ToList();
                foreach (Product prod in _productsList)
                {
                    var product = new ProductUserControl(prod);
                    flowLayoutPanel1.Controls.Add(product);
                }
            }
            else if (textBoxFind.Text.Length == 0)
            {
                if (manufacturerIDComboBox.SelectedIndex == 0)
                    RefreshBooks();
                else
                {
                    if (SortComboBox.SelectedIndex == 1)
                        _productsList = Program.context.Product.Where(p => p.ManufacturerID == (int)manufacturerIDComboBox.SelectedIndex).OrderBy(p => p.Price).ToList();
                    else if (SortComboBox.SelectedIndex == 0)
                        _productsList = Program.context.Product.Where(p => p.ManufacturerID == (int)manufacturerIDComboBox.SelectedIndex).OrderByDescending(p => p.Price).ToList();
                    else
                        _productsList = Program.context.Product.Where(p => p.ManufacturerID == (int)manufacturerIDComboBox.SelectedIndex).OrderBy(p => p.Name).ToList();


                    foreach (Product prod in _productsList)
                    {
                        var product = new ProductUserControl(prod);
                        flowLayoutPanel1.Controls.Add(product);
                    }
                }
            }
            else
            {
                ClearProductsList();
                if (manufacturerIDComboBox.SelectedIndex == 0)
                {
                    string FindText = textBoxFind.Text;
                    if (SortComboBox.SelectedIndex == 1)
                        _productsList = Program.context.Product.Where(p => p.Name.Contains(FindText)).OrderBy(p => p.Price).ToList();
                    else if (SortComboBox.SelectedIndex == 0)
                        _productsList = Program.context.Product.Where(p => p.Name.Contains(FindText)).OrderByDescending(p => p.Price).ToList();
                    else
                        _productsList = Program.context.Product.Where(p => p.Name.Contains(FindText)).OrderBy(p => p.Name).ToList();

                    foreach (Product prod in _productsList)
                    {
                        var product = new ProductUserControl(prod);
                        flowLayoutPanel1.Controls.Add(product);
                    }
                }
                else
                {
                    string FindText = textBoxFind.Text;
                    if (SortComboBox.SelectedIndex == 1)
                        _productsList = Program.context.Product.Where(p => p.Name.Contains(FindText) && p.ManufacturerID == manufacturerIDComboBox.SelectedIndex).OrderBy(p => p.Price).ToList();
                    else if (SortComboBox.SelectedIndex == 0)
                        _productsList = Program.context.Product.Where(p => p.Name.Contains(FindText) && p.ManufacturerID == manufacturerIDComboBox.SelectedIndex).OrderByDescending(p => p.Price).ToList();
                    else
                        _productsList = Program.context.Product.Where(p => p.Name.Contains(FindText) && p.ManufacturerID == manufacturerIDComboBox.SelectedIndex).OrderBy(p => p.Name).ToList();
                    foreach (Product prod in _productsList)
                    {
                        var product = new ProductUserControl(prod);
                        flowLayoutPanel1.Controls.Add(product);
                    }
                }
            }
        }


        private void manufacturerIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FindBooks();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            manufacturerIDComboBox.SelectedIndex = 0;

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            AutorizationForm autorizationForm = this.Owner as AutorizationForm;
            autorizationForm.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FindBooks();
        }
    }
}
