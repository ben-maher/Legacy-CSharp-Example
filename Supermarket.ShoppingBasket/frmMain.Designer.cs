namespace Supermarket.ShoppingBasket
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbProducts = new System.Windows.Forms.ComboBox();
            this.cmbOffers = new System.Windows.Forms.ComboBox();
            this.nmQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblOffer = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lstBasketItems = new System.Windows.Forms.ListView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtDistQuantity = new System.Windows.Forms.TextBox();
            this.lblDistQuantity = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblLatestPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nmQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbProducts
            // 
            this.cmbProducts.FormattingEnabled = true;
            this.cmbProducts.Location = new System.Drawing.Point(35, 31);
            this.cmbProducts.Name = "cmbProducts";
            this.cmbProducts.Size = new System.Drawing.Size(121, 21);
            this.cmbProducts.TabIndex = 0;
            this.cmbProducts.SelectedIndexChanged += new System.EventHandler(this.cmbProducts_SelectedIndexChanged);
            // 
            // cmbOffers
            // 
            this.cmbOffers.FormattingEnabled = true;
            this.cmbOffers.Location = new System.Drawing.Point(268, 32);
            this.cmbOffers.Name = "cmbOffers";
            this.cmbOffers.Size = new System.Drawing.Size(165, 21);
            this.cmbOffers.TabIndex = 1;
            // 
            // nmQuantity
            // 
            this.nmQuantity.Location = new System.Drawing.Point(439, 32);
            this.nmQuantity.Name = "nmQuantity";
            this.nmQuantity.Size = new System.Drawing.Size(120, 20);
            this.nmQuantity.TabIndex = 2;
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(35, 15);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(49, 13);
            this.lblProduct.TabIndex = 3;
            this.lblProduct.Text = "Products";
            // 
            // lblOffer
            // 
            this.lblOffer.AutoSize = true;
            this.lblOffer.Location = new System.Drawing.Point(265, 14);
            this.lblOffer.Name = "lblOffer";
            this.lblOffer.Size = new System.Drawing.Size(35, 13);
            this.lblOffer.TabIndex = 4;
            this.lblOffer.Text = "Offers";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(436, 13);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(46, 13);
            this.lblQuantity.TabIndex = 5;
            this.lblQuantity.Text = "Quantity";
            // 
            // lstBasketItems
            // 
            this.lstBasketItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstBasketItems.Location = new System.Drawing.Point(12, 59);
            this.lstBasketItems.Name = "lstBasketItems";
            this.lstBasketItems.Size = new System.Drawing.Size(815, 361);
            this.lstBasketItems.TabIndex = 6;
            this.lstBasketItems.UseCompatibleStateImageBehavior = false;
            this.lstBasketItems.View = System.Windows.Forms.View.Details;
            this.lstBasketItems.Resize += new System.EventHandler(this.lstBasketItems_Resize);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(565, 30);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(646, 30);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 8;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(727, 30);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtDistQuantity
            // 
            this.txtDistQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDistQuantity.Location = new System.Drawing.Point(67, 426);
            this.txtDistQuantity.Name = "txtDistQuantity";
            this.txtDistQuantity.Size = new System.Drawing.Size(100, 20);
            this.txtDistQuantity.TabIndex = 10;
            // 
            // lblDistQuantity
            // 
            this.lblDistQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDistQuantity.AutoSize = true;
            this.lblDistQuantity.Location = new System.Drawing.Point(12, 429);
            this.lblDistQuantity.Name = "lblDistQuantity";
            this.lblDistQuantity.Size = new System.Drawing.Size(52, 13);
            this.lblDistQuantity.TabIndex = 11;
            this.lblDistQuantity.Text = "No. Items";
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(690, 429);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(31, 13);
            this.lblTotal.TabIndex = 13;
            this.lblTotal.Text = "Total";
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotal.Location = new System.Drawing.Point(727, 426);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(100, 20);
            this.txtTotal.TabIndex = 12;
            // 
            // lblLatestPrice
            // 
            this.lblLatestPrice.AutoSize = true;
            this.lblLatestPrice.Location = new System.Drawing.Point(162, 16);
            this.lblLatestPrice.Name = "lblLatestPrice";
            this.lblLatestPrice.Size = new System.Drawing.Size(63, 13);
            this.lblLatestPrice.TabIndex = 15;
            this.lblLatestPrice.Text = "Latest Price";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(162, 32);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(100, 20);
            this.txtPrice.TabIndex = 14;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnExit.Location = new System.Drawing.Point(384, 426);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 16;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 455);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblLatestPrice);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblDistQuantity);
            this.Controls.Add(this.txtDistQuantity);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lstBasketItems);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblOffer);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.nmQuantity);
            this.Controls.Add(this.cmbOffers);
            this.Controls.Add(this.cmbProducts);
            this.Name = "FrmMain";
            this.Text = "Supermarket - Shopping Basket";
            ((System.ComponentModel.ISupportInitialize)(this.nmQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbProducts;
        private System.Windows.Forms.ComboBox cmbOffers;
        private System.Windows.Forms.NumericUpDown nmQuantity;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblOffer;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.ListView lstBasketItems;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtDistQuantity;
        private System.Windows.Forms.Label lblDistQuantity;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblLatestPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Button btnExit;
    }
}

