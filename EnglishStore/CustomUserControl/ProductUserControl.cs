using EnglishStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnglishStore.CustomUserControl
{
    public partial class ProductUserControl : UserControl
    {
        Product _product;
        public ProductUserControl(Product product)
        {
            InitializeComponent();
            _product = product;
            FillFields();
        }

        private void FillFields()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory; // bin\Debug\
            string projectPath = Directory.GetParent(baseDirectory).Parent.Parent.FullName; // Корень проекта
            string imagePath = Path.Combine(projectPath, "Resources", _product.Image.Trim());

            if (File.Exists(imagePath))
            {
                // Загружаем картинку
                pictureBox1.Image = System.Drawing.Image.FromFile(imagePath);
                pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage; // Масштабирование
            }
            else
            {
                // Если файла нет, можно загрузить изображение по умолчанию
                pictureBox1.Image = null;
            }
            ProductNameLabel.Text = _product.Name;
            CostLabel.Text = _product.Price.ToString();
            if (_product.IsActive == false)
            {
                IsActivatedlabel.Visible = true;
                IsActivatedlabel.Text = "Неактивен";
                this.BackColor = Color.Gray;
            }
        }
    }
}
