using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Basket;
using dataaccess.supermarket;

namespace Supermarket
{
    public partial class FrmMain : Form
    {
        private SupermarketFactory supermarketFactory;

        public FrmMain()
        {
            InitializeComponent();
            InitializeBasket();
            BuildUi();
        }

        public void InitializeBasket()
        {
            //Intialize a new Supermarket Factory
            supermarketFactory = new SupermarketFactory();
            //Bind Products and assign display and value members.
            cmbProducts.DataSource = supermarketFactory.Products;

            //Setting the display members of the ComboBoxes to give the User good usable information.
            cmbProducts.DisplayMember = "ProductName";
            cmbOffers.DisplayMember = "OfferDescription";

            lstBasketItems.Columns.Add("Item Name");
            lstBasketItems.Columns.Add("Quantity");
            lstBasketItems.Columns.Add("Offer");
            lstBasketItems.Columns.Add("Initial Price");
            lstBasketItems.Columns.Add("Amt Reduced");
            lstBasketItems.Columns.Add("Final Price");
            lstBasketItems.Columns.Add("Offer Description");
        }
        
        private void cmbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Get the currently selected Item frm the ComboBox and render a friendly price for them.
            Product _product = cmbProducts.SelectedItem as Product;
            if (_product == null) return;
            txtPrice.Text = $"£{_product.UnitPrice.ToString("0.00")}";

            //Bind the offers collection (unique for the product) to the offers ComboBox.
            List<Offer> _offers = supermarketFactory.GetOffersByProduct(_product);
            cmbOffers.DataSource = _offers;

            //Duo condition validating that offers is greater than 0 and that the ui element is disabled before re-enabling it.
            if (_offers.Count > 0)
            {
                if (!cmbOffers.Enabled) cmbOffers.Enabled = true;
                return;
            }
            //Destroy the old text set by the Datasource and disable the control.
            cmbOffers.Text = null;
            cmbOffers.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Product _product = cmbProducts.SelectedItem as Product;
            int _quantity = decimal.ToInt32(nmQuantity.Value);
            Offer _offer = cmbOffers.SelectedItem as Offer;
            if (_product == null)
            {
                MessageBox.Show("Please select a product");
                return;
            }
            if (_quantity < 1)
            {
                MessageBox.Show("Please select a quantity");
                return;
            }

            supermarketFactory.AddItemToBasket(_product, _quantity, _offer);
            BuildUi();
        }

        private void BuildUi()
        {
            lstBasketItems.Items.Clear();
            foreach (BasketItem _basketItem in supermarketFactory.shoppingBasket.BasketItems)
            {
                bool _hasOffer = _basketItem.Offer != null;
                ListViewItem _item = new ListViewItem(_basketItem.ProductName); //Product Name
                _item.SubItems.Add(_basketItem.Quantity.ToString()); //Product Quantity
                _item.SubItems.Add(_hasOffer ? _basketItem.Offer.ShortDescription : ""); //Offer Description
                _item.SubItems.Add($"£{_basketItem.LatestPrice.ToString("#0.00")}"); //Intial Price
                _item.SubItems.Add(_hasOffer ? _basketItem.Offer.DiscountPercentage.ToString() : ""); //Discount Applied
                _item.SubItems.Add(_hasOffer ? _basketItem.Offer.DiscountPercentage.ToString() : ""); //Final Price
                _item.SubItems.Add(_hasOffer ? _basketItem.Offer.OfferDescription : ""); // Not sure
                lstBasketItems.Items.Add(_item);
            }

            txtTotal.Text = $"£{supermarketFactory.shoppingBasket.BasketTotal.ToString("#0.00")}";
            txtDistQuantity.Text = supermarketFactory.shoppingBasket.BasketItems.Count.ToString();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstBasketItems.SelectedItems.Count < 1) return; //TODO error here

            foreach (ListViewItem _selectedItem in lstBasketItems.SelectedItems)
            {
                supermarketFactory.shoppingBasket.RemoveProduct(_selectedItem.Text);
            }
            
            BuildUi();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            supermarketFactory.shoppingBasket.ClearBasket();
            BuildUi();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
