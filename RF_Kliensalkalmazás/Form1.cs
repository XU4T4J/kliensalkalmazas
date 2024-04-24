
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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RF_Kliensalkalmazás
{
    public partial class Form1 : Form
    {
        public Api api;
        public static Api apicall()
        {
            string apiUrl = "http://20.234.113.211:8095/";
            string apikey = "1-99c18ed4-5034-453f-8b77-f077f81d6b89";

            Api proxy = new Api(apiUrl, apikey);
            return proxy;
        }

        public Dictionary<string, string> products = new Dictionary<string, string>();
        public Form1()
{
    InitializeComponent();

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

    List<string> selectedNames = new List<string>();
}
        

        public void Form1_Load(object sender, EventArgs e)
            { 
            listatoltes();
            }
        
        public void buttonUP_Click(object sender, EventArgs e)
            {
           
            

            }


        public void buttonDOWN_Click(object sender, EventArgs e)
        {
            int down = Convert.ToInt32(textBox1.Text);
        }


        public void listatoltes()
        {

        }
        public List<string> selectedIds = new List<string>();

        public void checkedListBoxProducts_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            List<string> selectedNames = new List<string>();

            string name = checkedListBoxProducts.Items[e.Index].ToString();

            if (e.NewValue == CheckState.Checked)
            {

                if (!selectedNames.Contains(name))
                {
                    selectedNames.Add(name);

                    if (products.ContainsValue(name))
        {
                        selectedIds.Add(products.FirstOrDefault(x => x.Value == name).Key);

                        listBox2.Items.Add(products.FirstOrDefault(x => x.Value == name).Key);
        }
                }
        

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
            
                    if (products.ContainsValue(name))
                    {
                        selectedIds.Remove(products.FirstOrDefault(x => x.Value == name).Key);

                        listBox2.Items.Remove(products.FirstOrDefault(x => x.Value == name).Key);
        }


                   
 
                }
                else
        {
                    MessageBox.Show("Fasz");
        }


                if (listBox1.Items.Contains(name))
        {
                    listBox1.Items.Remove(name);
                }
            }




            
        }

    }
        
}
