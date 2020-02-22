using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vic.SuperStore.Services;
using Vic.SuperStore.Data.Entities;


namespace Vic.SuperStore.UI.WinFormApp
{
    public partial class Form1 : Form
    {
        private readonly ProductService _productService = new ProductService();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var product = _productService.GetProductById(id);
            labelIdValue.Text = product.Id.ToString();
            labelNameValue.Text = product.Name;
            labelPriceValue.Text = product.Price.ToString();




        }
    }
}
