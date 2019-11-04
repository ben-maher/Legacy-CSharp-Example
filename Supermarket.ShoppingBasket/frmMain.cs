using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Basket;
using dataaccess.supermarket;
using Supermarket.ShoppingBasket.Classes;

namespace Supermarket.ShoppingBasket
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

        /// <summary>
        /// This method will add the columns to the ListView set the datasource of the combo boxes and their display members.
        /// </summary>
        public void InitializeBasket()
        {
            //Intialize a new Supermarket Factory
            supermarketFactory = new SupermarketFactory();
            //Bind Products and assign display and value members.
            cmbProducts.DataSource = supermarketFactory.Products;

            //Setting the display members of the ComboBoxes to give the User good usable information.
            cmbProducts.DisplayMember = "ProductName";
            cmbOffers.DisplayMember = "OfferDescription";

            lstBasketItems.Columns.Add("Item Name", -2);
            lstBasketItems.Columns.Add("Quantity", -2);
            lstBasketItems.Columns.Add("Offer", -2);
            lstBasketItems.Columns.Add("Initial Price", -2);
            lstBasketItems.Columns.Add("Savings", -2);
            lstBasketItems.Columns.Add("Final Price", -2);
            lstBasketItems.Columns.Add("Offers Applied", -2);
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

        /// <summary>
        /// Event triggered when BtnAdd is clicked. This event does some client-side validation before sending the values off to be added to the basket
        /// and performing a UI refresh.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Product _product = cmbProducts.SelectedItem as Product;
            int _quantity = decimal.ToInt32(nmQuantity.Value);
            Offer _offer = cmbOffers.SelectedItem as Offer;
            if (_product == null)
            {
                MessageBox.Show("Please select a product", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (_quantity < 1)
            {
                MessageBox.Show("Please select a quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            supermarketFactory.AddItemToBasket(_product, _quantity, _offer);
            BuildUi();
        }

        /// <summary>
        /// Build the UI objects this function is typically used to re-render the ListView and to update the totals on the form.
        /// </summary>
        private void BuildUi()
        {
            lstBasketItems.Items.Clear();

            var _renders = supermarketFactory.BuildBasketRenders();
            foreach (BasketItemRender _basketItemRender in _renders)
            {
                ListViewItem _item = new ListViewItem(_basketItemRender.ProductName);
                _item.SubItems.Add(_basketItemRender.Quantity.ToString());
                _item.SubItems.Add(_basketItemRender.OfferDescription);
                _item.SubItems.Add($"£{_basketItemRender.InitialPrice.ToString("#0.00")}");
                _item.SubItems.Add($"£{_basketItemRender.Savings.ToString("#0.00")}");
                _item.SubItems.Add($"£{_basketItemRender.FinalPrice.ToString("#0.00")}");
                _item.SubItems.Add(_basketItemRender.OffersApplied);
                lstBasketItems.Items.Add(_item);
            }

            txtTotal.Text = $"£{_renders.Sum(r=> r.FinalPrice).ToString("#0.00")}";
            txtDistQuantity.Text = _renders.Count.ToString();
        }

        /// <summary>
        /// Event called when the remove button is clicked. Will validate items are selected before removing them from the basket.
        /// </summary>
        /// <param name="sender">Remove Button</param>
        /// <param name="e">EventArgs</param>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstBasketItems.SelectedItems.Count < 1)
            {
                MessageBox.Show("Please select something to remove from the basket", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

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

        /// <summary>
        /// BtnExit -> Onclick will close the form disposing of all local members.
        /// </summary>
        /// <param name="sender">The button control</param>
        /// <param name="e">EventArgs</param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Size the last column of a listview.
        /// </summary>
        /// <param name="lv">The target listview</param>
        private void SizeLastColumn(ListView lv)
        {
            lv.Columns[lv.Columns.Count - 1].Width = -2;
        }

        /// <summary>
        /// On-Resize event
        /// </summary>
        /// <param name="sender">The ListView that has resized.</param>
        /// <param name="e">EventArgs</param>
        private void lstBasketItems_Resize(object sender, EventArgs e)
        {
            SizeLastColumn((ListView)sender);
        }
    }
}
