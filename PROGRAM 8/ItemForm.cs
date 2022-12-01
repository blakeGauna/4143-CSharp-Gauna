using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace button
{
    public partial class ItemForm : Form
    {
        
        public ItemForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            ID = idText.Text;
            Names = nameText.Text;
            Price = priceText.Text;
            Quantity = quanText.Text;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        public string ID   // property
        {
            get { return idText.Text; }   // get method
            set { idText.Text = value; }  // set method
        }
        public string Names   // property
        {
            get { return nameText.Text; }   // get method
            set { nameText.Text = value; }  // set method
        }
        public string Price   // property
        {
            get { return priceText.Text; }   // get method
            set { priceText.Text = value; }  // set method
        }
        public string Quantity   // property
        {
            get { return quanText.Text; }   // get method
            set { quanText.Text = value; }  // set method
        }
    }
}
