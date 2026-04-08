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
    public partial class HistoryForm : Form
    {
        Product _product;
        public HistoryForm(Product product)
        {
            InitializeComponent();
            _product = product;
        }

      

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "englishStore_DubininRADataSet.Sale". При необходимости она может быть перемещена или удалена.
            this.saleTableAdapter.Fill(this.englishStore_DubininRADataSet.Sale);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "englishStore_DubininRADataSet.Product". При необходимости она может быть перемещена или удалена.
            this.productTableAdapter.Fill(this.englishStore_DubininRADataSet.Product);

            saleBindingSource.DataSource = Program.context.Sale.Where(p => p.ProductID == _product.ID).OrderBy(p => p.SaleTime).ToList();

            manufacturerIDComboBox.Items.Clear();

            // Добавляем "Все элементы"
            manufacturerIDComboBox.Items.Add("Все элементы");

            // Добавляем производителей
            foreach (var manufacturer in Program.context.Manufacturer)
            {
                manufacturerIDComboBox.Items.Add(manufacturer.Name);
            }

            manufacturerIDComboBox.SelectedIndex = 0;
            // Для получения ID при выборе нужно будет хранить отдельно
            
        }
    }
}
