
using Hotcakes.Commerce.Catalog;
using Hotcakes.Commerce.Marketing.PromotionQualifications;
using Hotcakes.CommerceDTO.v1;
using Hotcakes.CommerceDTO.v1.Catalog;
using Hotcakes.CommerceDTO.v1.Client;
using Hotcakes.CommerceDTO.v1.Contacts;
using Hotcakes.CommerceDTO.v1.Membership;
using Hotcakes.CommerceDTO.v1.Orders;
using Hotcakes.Web;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RF_Kliensalkalmazás
{
    public partial class Form1 : Form
    {
        private Api api;
        public static Api apicall()
        {
            string apiUrl = "http://20.234.113.211:8095/";
            string apikey = "1-99c18ed4-5034-453f-8b77-f077f81d6b89";

            Api proxy = new Api(apiUrl, apikey);
            return proxy;
        }

        Dictionary<string, string> products = new Dictionary<string, string>();
        public Form1()
        {
            InitializeComponent();

            apiadata();




        }
        public void apiadata(string searchText = null)
        {
            api = apicall();

            ApiResponse<List<ProductDTO>> DTO = api.ProductsFindAll();

            for (int i = 0; i < 100; i++)
            {
                string id = DTO.Content[i].Bvin.ToString();
                string name = DTO.Content[i].ProductName.ToString();

                products.Add(id, name);
            }

            foreach (string ne in products.Values)
            {
                checkedListBoxProducts.Items.Add(ne);
            }

        }

        private void buttonUP_Click(object sender, EventArgs e)
        {
            api = apicall();
            int up = Convert.ToInt32(textBox1.Text);
            foreach (var i in selectedIds)
            {
                var productId = i;
                var product = api.ProductsFind(productId).Content;
                var p = product.SitePrice;
                product.SitePrice = Convert.ToInt32(p * (1 + Convert.ToDecimal(up)/100));
                ApiResponse<ProductDTO> response = api.ProductsUpdate(product);
            }
            MessageBox.Show("Az árnövelés sikeres volt!");
        }


        private void buttonDOWN_Click(object sender, EventArgs e)
        {
            api = apicall();
            int down = Convert.ToInt32(textBox1.Text);
            foreach (var i in selectedIds)
            {
                var productId = i;
                var product = api.ProductsFind(productId).Content;
                var p = product.SitePrice;
                product.SitePrice = Convert.ToInt32(p * (1 - Convert.ToDecimal(down) / 100));
                ApiResponse<ProductDTO> response = api.ProductsUpdate(product);
            }

            List<ProductDTO> new_product_list = new List<ProductDTO>();

            foreach (var i in selectedIds)
            { 
                var updated_prod = api.ProductsFind(i).Content;
                new_product_list.Add(updated_prod);

            }
            dataGridView1.DataSource = new_product_list.ToList();

            MessageBox.Show("Az árcsökkentés sikeres volt");
        }



        List<string> selectedIds = new List<string>();
        List<string> selectedNames = new List<string>();
        private void checkedListBoxProducts_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            

            string name = checkedListBoxProducts.SelectedItem.ToString();
            string id = products.FirstOrDefault(x => x.Value == name).Key;
            if (e.NewValue == CheckState.Checked)
            {

                if (!selectedNames.Contains(name))
                {
                    selectedNames.Add(name);
                    selectedIds.Add(id);
                }
                else 
                { MessageBox.Show("Betöltés hiba"); }


                if (!listBox1.Items.Contains(name))
                {
                    listBox1.Items.Add(name);
                }
            }
            else if (e.NewValue == CheckState.Unchecked)
            {

                if (selectedNames.Contains(name))
                {
                    selectedNames.Remove(name);
                    selectedIds.Remove(id);
                }
                else
                {
                    MessageBox.Show("Remove hiba");
                }


                if (listBox1.Items.Contains(name))
                {
                    listBox1.Items.Remove(name);
                }
            }




        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox1, "");
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (!CheckPrec(textBox1.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox1, "Csak 5 és 90 közti számot adhatsz meg");
            }
        }

        private bool CheckPrec(string prec)
        {
            Regex r = new Regex("^(5|[6-9]|[1-8][0-9]|90)$");
            return r.IsMatch(prec);
        }
    }
        
}
