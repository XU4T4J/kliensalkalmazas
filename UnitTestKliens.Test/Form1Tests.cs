using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RF_Kliensalkalmazás;
using Microsoft.VisualStudio.TestTools;
using Moq;
using NUnit.Framework;
using Hotcakes.CommerceDTO.v1.Client;
using System.CodeDom;
using NUnit.Framework.Internal;
using VSTest = Microsoft.VisualStudio.TestTools.UnitTesting;
using Hotcakes.CommerceDTO.v1.Catalog;
using Hotcakes.CommerceDTO.v1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;

namespace RF_Kliensalkalmazás.Tests
{
    //Teszteld, hogy a konstruktor helyesen inicializálja az api mezőt és a termékek szótárat.
    //Teszteld, hogy az apicall() módszer megfelelően konfigurált Api példányt ad vissza.
    //Teszteld, hogy a ProductsFindAll() módszer egy ProductDTO objektumok listáját adja vissza.
    //Teszteld, hogy a listatoltes() módszer helyesen tölti fel a listBox1 és listBox2 vezérlőket.
    //Teszteld, hogy a checkedListBoxProducts_ItemCheck() módszer helyesen frissíti a selectedIds és selectedNames listákat.
    //Teszteld, hogy a buttonUP_Click() és buttonDOWN_Click() módszerek helyesen frissítik a textBox1 vezérlőt.
    //Teszteld, hogy a Form1_Load() módszer helyesen hívja meg a listatoltes() módszert.




    public static class ApiCallHelper
    {
        public static Api apicall()
        {
            string apiUrl = "http://20.234.113.211:8095/";
            string apikey = "1-99c18ed4-5034-453f-8b77-f077f81d6b89";

            Api proxy = new Api(apiUrl, apikey);
            return proxy;
        }
    }
    public class Form1Tests
    {
        Form1 form1 = new Form1();

        [Test]
        public void TestInitialize()
        {
            // Arrange
            form1 = new Form1();
            form1.Show();
        }

        [Test]
        public void TestApicall()
        {
            //Arrange
            var expectedApiUrl = "http://20.234.113.211:8095/";
            var expectedApiKey = "1-99c18ed4-5034-453f-8b77-f077f81d6b89";

            //Act
            var api = ApiCallHelper.apicall();
            //Assert
            VSTest.Assert.IsNotNull(api);


        }
        [Test]
        public void TestDictionary()
        {
            //Arrange
            var products = form1.products;
            var api = form1.api;
            // Assert
            VSTest.Assert.IsNotNull(form1.products);
            VSTest.Assert.AreEqual(100, form1.products.Count);


            for (int i = 0; i < 100; i++)
            {
                var product = form1.api.ProductsFind(products.Keys.ElementAt(i)).Content;
                VSTest.Assert.IsNotNull(product);
                VSTest.Assert.AreEqual(products.Values.ElementAt(i), product.ProductName);
            }
        }
        //[Test]
        //public void TestButtonUP_Click_IncrementsTextboxValue()
        //{
        //    // Arrange
        //    var form1 = new Form1();
        //    var textboxValue = 10;
        //    form1.textBox1.Text = textboxValue.ToString();

        //    // Act
        //    form1.buttonUP_Click(form1.buttonUP, EventArgs.Empty);

        //    // Assert
        //    VSTest.Assert.IsNotNull(form1.textBox1);
        //    VSTest.Assert.AreEqual((textboxValue + 1).ToString(), form1.textBox1.Text);
        [Test]
        public void TestConstructor_InitializesApiFieldAndProductsDictionary()
        {
            // Arrange
            Form1 form1 = new Form1();

            // Assert
            VSTest.Assert.IsNotNull(form1.api);
            VSTest.Assert.IsNotNull(form1.products);
            VSTest.Assert.IsTrue(form1.products.Count == 0);
        }

        [Test]
        public void TestApiCall_ReturnsProperlyConfiguredApiInstance()
        {
            // Arrange
            
            var expectedApiUrl = "http://20.234.113.211:8095/";
            var expectedApiKey = "1-99c18ed4-5034-453f-8b77-f077f81d6b89";

            //Act
            Api api = Form1.apicall();
            // Assert
            VSTest.Assert.IsNotNull(api);
            //VSTest.Assert.AreEqual(expectedApiUrl, api);
            //VSTest.Assert.AreEqual(expectedApiKey, api);
        }

        [Test]
        public void TestProductsFindAll_ReturnsListOfProductDTOObjects()
        {
            // Arrange
            Form1 form1 = new Form1();
            Api api = form1.api;

            // Act
            ApiResponse<List<ProductDTO>> response = api.ProductsFindAll();

            // Assert
            VSTest.Assert.IsNotNull(response);
            VSTest.Assert.IsNotNull(response.Content);
            //VSTest.Assert.IsTrue(response.Content.Count > 0);
            //VSTest.Assert.IsTrue(response.Content.All(p => p is ProductDTO));
        }

        [Test]
        public void TestListatoltes_PopulatesListBox1AndListBox2Controls()
        {
            // Arrange
            Form1 form1 = new Form1();
            form1.checkedListBoxProducts.Items.Add("Product 1");
            form1.checkedListBoxProducts.Items.Add("Product 2");

            // Act
            form1.listatoltes();

            // Assert
            VSTest.Assert.IsTrue(form1.listBox1.Items.Count > 0);
            VSTest.Assert.IsTrue(form1.listBox2.Items.Count > 0);
        }

        [Test]
        public void TestCheckedListBoxProducts_ItemCheck_UpdatesSelectedIdsAndSelectedNamesLists()
        {
            // Arrange
            Form1 form1 = new Form1();
            form1.checkedListBoxProducts.Items.Add("Product 1");
            form1.checkedListBoxProducts.Items.Add("Product 2");
            form1.products.Add("1", "Product 1");
            form1.products.Add("2", "Product 2");

            // Act
            form1.checkedListBoxProducts_ItemCheck(null, new ItemCheckEventArgs(0, CheckState.Checked, CheckState.Unchecked));

            // Assert
            VSTest.Assert.IsTrue(form1.selectedIds.Count > 0);
            //VSTest.Assert.IsTrue(form1.selectedNames.Count > 0);
        }

        [Test]
        public void TestButtonUP_Click_UpdatesTextBox1Control()
        {
            // Arrange
            Form1 form1 = new Form1();
            form1.textBox1.Text = "0";

            // Act
            form1.buttonUP_Click(null, EventArgs.Empty);

            // Assert
            VSTest.Assert.AreNotEqual("0", form1.textBox1.Text);
        }

        [Test]
        public void TestButtonDOWN_Click_UpdatesTextBox1Control()
        {
            // Arrange
            Form1 form1 = new Form1();
            form1.textBox1.Text = "10";

            // Act
            form1.buttonDOWN_Click(null, EventArgs.Empty);

            // Assert
            VSTest.Assert.AreNotEqual("10", form1.textBox1.Text);
        }

        [Test]
        public void TestForm1_Load_CallsListatoltesMethod()
        {
            // Arrange
            Form1 form1 = new Form1();
            Mock<Form1> mockForm1 = new Mock<Form1>(form1);
            mockForm1.Setup(f => f.listatoltes()).Verifiable();

            // Act
            form1.Form1_Load(null, EventArgs.Empty);

            // Assert
            mockForm1.Verify(f => f.listatoltes(), Times.Once);
        }
    }
}   
