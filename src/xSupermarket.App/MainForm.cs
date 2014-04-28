using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using xSupermarket.Framework.DSL;
using xSupermarket.Framework.ExDSL;
using xSupermarket.Framework.Repo;

namespace xSupermarket.App
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AutoGenerateColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void buttonCategory_Click(object sender, EventArgs e)
        {
            this.bindingSource1.DataSource = new CategoryRepository().Find().List();
        }

        private void buttonSection_Click(object sender, EventArgs e)
        {
            this.bindingSource1.DataSource = new SectionRepository().Find().List();
        }

        private void buttonArea_Click(object sender, EventArgs e)
        {
            this.bindingSource1.DataSource = new ProductAreaRepository().Find().List();
        }

        private void buttonBasket_Click(object sender, EventArgs e)
        {
            this.bindingSource1.DataSource = new MarketbasketRepository().Find().List();
        }

        private void buttonEmployee_Click(object sender, EventArgs e)
        {
            this.bindingSource1.DataSource = new EmployeeRepository().Find().List();
        }

        private void buttonProduct_Click(object sender, EventArgs e)
        {
            this.bindingSource1.DataSource = new ProductRepository().Find().List();
        }

        private void buttonExDSL_Click(object sender, EventArgs e)
        {
            try
            {
                string dsl = this.textBoxInput.Text.Trim();
                if (string.IsNullOrWhiteSpace(dsl))
                {
                    this.textBoxOutput.Text = "输入点儿什么吧，亲";
                    return;
                }
                ExDSLParser parser = new ExDSLParser(dsl);
                ExDSLGenerator gen = new ExDSLGenerator(parser);
                object obj = gen.Gen();
                DslObject dObj = obj as DslObject;
                if (dObj != null)
                {
                    this.textBoxOutput.Text = dObj.GetOutput();
                }
                else
                {
                    this.textBoxOutput.Text = "语法错误，（＞﹏＜）";
                }
            }
            catch (Exception ex)
            {
                this.textBoxOutput.Text = "好像发生了什么错误，（＞﹏＜）\r\n" + ex.Message;
            }
        }
    }
}
