
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

        
        public Form1()
        {
            InitializeComponent();


            api = apicall();

            ApiResponse<List<ProductDTO>> DTO = api.ProductsFindAll();
            Dictionary<string, string> products = new Dictionary<string, string>();
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

            //int x = Convert.ToInt32(textBox1.Text);

            List<string> selectedNames = new List<string>();

            foreach (string sname in checkedListBoxProducts.SelectedItems) 
            { 
                selectedNames.Add(sname);
            }
            foreach (string nasde in selectedNames)
            {
                listBox1.Items.Add(nasde);
            }

        }

        private void checkedListBoxProducts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listatoltes();
        }
        
        private void buttonUP_Click(object sender, EventArgs e)
        {
            
            

        }


        private void buttonDOWN_Click(object sender, EventArgs e)
        {
            int down = Convert.ToInt32(textBox1.Text);
        }


        public void listatoltes()
        {
            
        }
    }
        
}
