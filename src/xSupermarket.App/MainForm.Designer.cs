namespace xSupermarket.App
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.buttonExDSL = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonProduct = new System.Windows.Forms.Button();
            this.buttonEmployee = new System.Windows.Forms.Button();
            this.buttonBasket = new System.Windows.Forms.Button();
            this.buttonArea = new System.Windows.Forms.Button();
            this.buttonSection = new System.Windows.Forms.Button();
            this.buttonCategory = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOutput.Location = new System.Drawing.Point(10, 10);
            this.textBoxOutput.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.ReadOnly = true;
            this.textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxOutput.Size = new System.Drawing.Size(756, 399);
            this.textBoxOutput.TabIndex = 0;
            // 
            // textBoxInput
            // 
            this.textBoxInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxInput.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxInput.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxInput.Location = new System.Drawing.Point(10, 419);
            this.textBoxInput.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxInput.Multiline = true;
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(646, 100);
            this.textBoxInput.TabIndex = 1;
            this.textBoxInput.Text = "TOP Marketbasket 60;";
            // 
            // buttonExDSL
            // 
            this.buttonExDSL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExDSL.Location = new System.Drawing.Point(666, 419);
            this.buttonExDSL.Margin = new System.Windows.Forms.Padding(5);
            this.buttonExDSL.Name = "buttonExDSL";
            this.buttonExDSL.Size = new System.Drawing.Size(100, 100);
            this.buttonExDSL.TabIndex = 2;
            this.buttonExDSL.Text = "GoodLuck";
            this.buttonExDSL.UseVisualStyleBackColor = true;
            this.buttonExDSL.Click += new System.EventHandler(this.buttonExDSL_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(784, 562);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBoxOutput);
            this.tabPage1.Controls.Add(this.textBoxInput);
            this.tabPage1.Controls.Add(this.buttonExDSL);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(5);
            this.tabPage1.Size = new System.Drawing.Size(776, 529);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ExDSL";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonProduct);
            this.tabPage2.Controls.Add(this.buttonEmployee);
            this.tabPage2.Controls.Add(this.buttonBasket);
            this.tabPage2.Controls.Add(this.buttonArea);
            this.tabPage2.Controls.Add(this.buttonSection);
            this.tabPage2.Controls.Add(this.buttonCategory);
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(5);
            this.tabPage2.Size = new System.Drawing.Size(776, 529);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Database";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonProduct
            // 
            this.buttonProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonProduct.Location = new System.Drawing.Point(563, 419);
            this.buttonProduct.Margin = new System.Windows.Forms.Padding(5);
            this.buttonProduct.Name = "buttonProduct";
            this.buttonProduct.Size = new System.Drawing.Size(100, 100);
            this.buttonProduct.TabIndex = 10;
            this.buttonProduct.Text = "Product";
            this.buttonProduct.UseVisualStyleBackColor = true;
            this.buttonProduct.Click += new System.EventHandler(this.buttonProduct_Click);
            // 
            // buttonEmployee
            // 
            this.buttonEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonEmployee.Location = new System.Drawing.Point(453, 419);
            this.buttonEmployee.Margin = new System.Windows.Forms.Padding(5);
            this.buttonEmployee.Name = "buttonEmployee";
            this.buttonEmployee.Size = new System.Drawing.Size(100, 100);
            this.buttonEmployee.TabIndex = 9;
            this.buttonEmployee.Text = "Employee";
            this.buttonEmployee.UseVisualStyleBackColor = true;
            this.buttonEmployee.Click += new System.EventHandler(this.buttonEmployee_Click);
            // 
            // buttonBasket
            // 
            this.buttonBasket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonBasket.Location = new System.Drawing.Point(343, 419);
            this.buttonBasket.Margin = new System.Windows.Forms.Padding(5);
            this.buttonBasket.Name = "buttonBasket";
            this.buttonBasket.Size = new System.Drawing.Size(100, 100);
            this.buttonBasket.TabIndex = 8;
            this.buttonBasket.Text = "Basket";
            this.buttonBasket.UseVisualStyleBackColor = true;
            this.buttonBasket.Click += new System.EventHandler(this.buttonBasket_Click);
            // 
            // buttonArea
            // 
            this.buttonArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonArea.Location = new System.Drawing.Point(233, 419);
            this.buttonArea.Margin = new System.Windows.Forms.Padding(5);
            this.buttonArea.Name = "buttonArea";
            this.buttonArea.Size = new System.Drawing.Size(100, 100);
            this.buttonArea.TabIndex = 5;
            this.buttonArea.Text = "Area";
            this.buttonArea.UseVisualStyleBackColor = true;
            this.buttonArea.Click += new System.EventHandler(this.buttonArea_Click);
            // 
            // buttonSection
            // 
            this.buttonSection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSection.Location = new System.Drawing.Point(123, 419);
            this.buttonSection.Margin = new System.Windows.Forms.Padding(5);
            this.buttonSection.Name = "buttonSection";
            this.buttonSection.Size = new System.Drawing.Size(100, 100);
            this.buttonSection.TabIndex = 4;
            this.buttonSection.Text = "Section";
            this.buttonSection.UseVisualStyleBackColor = true;
            this.buttonSection.Click += new System.EventHandler(this.buttonSection_Click);
            // 
            // buttonCategory
            // 
            this.buttonCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCategory.Location = new System.Drawing.Point(13, 419);
            this.buttonCategory.Margin = new System.Windows.Forms.Padding(5);
            this.buttonCategory.Name = "buttonCategory";
            this.buttonCategory.Size = new System.Drawing.Size(100, 100);
            this.buttonCategory.TabIndex = 3;
            this.buttonCategory.Text = "Category";
            this.buttonCategory.UseVisualStyleBackColor = true;
            this.buttonCategory.Click += new System.EventHandler(this.buttonCategory_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(13, 10);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(753, 399);
            this.dataGridView1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "MainForm";
            this.Text = "xSupermarket";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Button buttonExDSL;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonProduct;
        private System.Windows.Forms.Button buttonEmployee;
        private System.Windows.Forms.Button buttonBasket;
        private System.Windows.Forms.Button buttonArea;
        private System.Windows.Forms.Button buttonSection;
        private System.Windows.Forms.Button buttonCategory;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}

