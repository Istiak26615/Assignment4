using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop
{
    public partial class CoffeeShop : Form
    {
        List<string> name = new List<string> { };
        List<int> contact = new List<int> { };
        List<string> address = new List<string> { };
        List<string> order = new List<string> { };
        List<int> quantity = new List<int> { };

        public CoffeeShop()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (contact.Contains(Convert.ToInt32(contactTextBox.Text)))
                {
                    MessageBox.Show("Phone Number must be unique");
                    return;
                }
                else
                {
                    contact.Add(Convert.ToInt32(contactTextBox.Text));
                }
                if (!String.IsNullOrEmpty(orderComboBox.Text))
                {
                    order.Add(orderComboBox.Text);
                }
                else
                {
                    MessageBox.Show("Please select any Item");
                    return;
                }

                if (!String.IsNullOrEmpty(quantityTextBox.Text))
                {
                    quantity.Add(Convert.ToInt32(quantityTextBox.Text));
                }
                else
                {
                    MessageBox.Show("Please insert the Quantity");
                    return;
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }

            name.Add(customerNameTextBox.Text);
            address.Add(addressTextBox.Text);
            addCustomer();
            MessageBox.Show("Saved");
            customerNameTextBox.Clear();
            contactTextBox.Clear();
            addressTextBox.Clear();
            orderComboBox.SelectedIndex = -1;
            quantityTextBox.Clear();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            showCustomer();
        }

        private void showCustomer()
        {
            string Message = "";
            for (int i = 0; i < name.Count(); i++)
            {
                Message += "Customer Name: " + name[i] + "\n" + "Customer Phone: " + contact[i] + "\n" + "Customer Address: " + address[i] + "\n" + "order: " + order[i] + "\n" + "Price: " + quantity[i] + "\n" + "\n";
            }

            itemRichTextBox.Text = Message;
        }

        private void addCustomer()
        {
            for (int i = 0; i < name.Count(); i++)
            {
                if (orderComboBox.SelectedItem.ToString() == "Black-120")
                {
                    quantity[i] = (quantity[i] * 120);
                }
                else if (orderComboBox.SelectedItem.ToString() == "Cold-100")
                {
                    quantity[i] = quantity[i] * 100;
                }
                else if (orderComboBox.SelectedItem.ToString() == "Hot-90")
                {
                    quantity[i] = quantity[i] * 90;
                }
                else if (orderComboBox.SelectedItem.ToString() == "Regular-80")
                {
                    quantity[i] = quantity[i] * 80;
                }
                else
                {
                    MessageBox.Show("Select an item");
                }
                itemRichTextBox.Text = "Customer Name: " + name[i] + "\n" + "Customer Phone: " + contact[i] + "\n" + "Customer Address: " + address[i] + "\n" + "order: " + order[i] + "\n" + "Price: " + quantity[i] + "\n" + "\n";
            }
        }
    }
}
