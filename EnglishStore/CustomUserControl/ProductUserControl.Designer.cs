namespace EnglishStore.CustomUserControl
{
    partial class ProductUserControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.ProductNameLabel = new System.Windows.Forms.Label();
            this.CostLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.IsActivatedlabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ProductNameLabel
            // 
            this.ProductNameLabel.Location = new System.Drawing.Point(29, 197);
            this.ProductNameLabel.Name = "ProductNameLabel";
            this.ProductNameLabel.Size = new System.Drawing.Size(178, 37);
            this.ProductNameLabel.TabIndex = 1;
            this.ProductNameLabel.Text = "Название";
            this.ProductNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CostLabel
            // 
            this.CostLabel.Location = new System.Drawing.Point(29, 234);
            this.CostLabel.Name = "CostLabel";
            this.CostLabel.Size = new System.Drawing.Size(178, 32);
            this.CostLabel.TabIndex = 2;
            this.CostLabel.Text = "Цена";
            this.CostLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(32, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(175, 175);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // IsActivatedlabel
            // 
            this.IsActivatedlabel.Location = new System.Drawing.Point(29, 266);
            this.IsActivatedlabel.Name = "IsActivatedlabel";
            this.IsActivatedlabel.Size = new System.Drawing.Size(178, 27);
            this.IsActivatedlabel.TabIndex = 3;
            this.IsActivatedlabel.Text = "Статус";
            this.IsActivatedlabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.IsActivatedlabel.Visible = false;
            // 
            // ProductUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.IsActivatedlabel);
            this.Controls.Add(this.CostLabel);
            this.Controls.Add(this.ProductNameLabel);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ProductUserControl";
            this.Size = new System.Drawing.Size(240, 314);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label ProductNameLabel;
        private System.Windows.Forms.Label CostLabel;
        private System.Windows.Forms.Label IsActivatedlabel;
    }
}
